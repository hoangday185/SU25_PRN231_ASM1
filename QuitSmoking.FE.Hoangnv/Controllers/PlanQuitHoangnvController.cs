using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuitSmoking.Repositories.HoangNV.Models;
using QuitSmoking.Repositories.HoangNV.ModelExtentions;

namespace QuitSmoking.FE.Hoangnv.Controllers
{
    public class PlanQuitHoangnvController : Controller
    {
        private string APIEndPoint = "https://localhost:7280/api/";
        public async Task<IActionResult> Index(string? search, int? currentPage, int? pageSize, int? id)
        {
             int page = currentPage ?? 1;
            int size = pageSize ?? 5;
            string query = $"?page={page}&pageSize={size}";

             if (id.HasValue)
            {
                query += $"&createPlanId={id.Value.ToString()}";
            }

            if (!string.IsNullOrEmpty(search))
            {
                query += $"&search={System.Net.WebUtility.UrlEncode(search.Trim())}";
            }
           
             using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                using (var response = await httpClient.GetAsync(APIEndPoint + "PlanQuitHoangnv" + query))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<PaginationResult<PlanQuitMethodHoangNv>>(content);
                        if (result != null)
                        {
                            ViewData["PlanQuitMethodHoangnv"] = result;
                            return View(result);
                        }
                    }
                }
            }
            return View(new PaginationResult<PlanQuitMethodHoangNv> { Items = new List<PlanQuitMethodHoangNv>() });
        }
    }
}
