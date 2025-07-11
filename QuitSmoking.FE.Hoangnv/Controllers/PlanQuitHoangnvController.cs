using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuitSmoking.Repositories.HoangNV.Models;
using QuitSmoking.Repositories.HoangNV.ModelExtentions;

namespace QuitSmoking.FE.Hoangnv.Controllers
{
    public class PlanQuitHoangnvController : Controller
    {
        private string APIEndPoint = "https://localhost:7280/api/";
        public async Task<IActionResult> Index(int? id, string? search, int? currentPage, int? pageSize)
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
   
        public async Task<IActionResult> Create(int? id)
        {
            ViewBag.PlanId = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PlanQuitMethodHoangNv model)
        {
            // Lấy userId từ cookie và gán vào model
            var userIdString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "UserId").Value;
            
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                var jsonContent = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(APIEndPoint + "PlanQuitHoangnv", jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, "Tạo method thất bại: " + error);
                    return View(model);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                var response = await httpClient.GetAsync(APIEndPoint + $"PlanQuitHoangnv/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<PlanQuitMethodHoangNv>(content);
                    if (model != null)
                    {
                        ViewData["PlanQuitHoangnv"] = model;
                        return View(model);
                    }
                }
            }
            return await Index(1,null,1,10);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PlanQuitMethodHoangNv model)
        {
            // Lấy userId từ cookie và gán vào model
            var userIdString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "UserId").Value;
           
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                var jsonContent = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(APIEndPoint + $"PlanQuitHoangnv/{model.PlanQuitMethodHoangNvid}", jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, "Cập nhật kế hoạch thất bại: " + error);
                    return View(model);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                var response = await httpClient.GetAsync(APIEndPoint + $"CreatePlanHoangnv/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<PlanQuitMethodHoangNv>(content);
                    if (model != null)
                    {
                        return View(model);
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int CreatePlanQuitSmokingHoangNvid)
        {
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                var response = await httpClient.DeleteAsync(APIEndPoint + $"PlanQuitHoangnv/{CreatePlanQuitSmokingHoangNvid}");
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, "Xóa kế hoạch thất bại: " + error);
                    // Lấy lại model để hiển thị lại view
                    return await Delete(CreatePlanQuitSmokingHoangNvid);
                }
            }
        }

        
    }
}
