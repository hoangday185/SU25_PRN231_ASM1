using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using QuitSmoking.Repositories.HoangNV.Models;
using QuitSmoking.Repositories.HoangNV.ModelExtentions;


namespace QuitSmoking.FE.Hoangnv.Controllers
{
    public class CreatePlanHoangnvController : Controller
    {

        private string APIEndPoint = "https://localhost:7280/api/";
        public async Task<IActionResult> Index(string? title, int? currentPage, int? pageSize, bool? isActive)
        {
            int page = currentPage ?? 1;
            int size = pageSize ?? 5;
            string query = $"?page={page}&pageSize={size}";
            if (!string.IsNullOrEmpty(title))
            {
                query += $"&title={System.Net.WebUtility.UrlEncode(title.Trim())}";
            }
            if (isActive.HasValue)
            {
                query += $"isActive={isActive.Value.ToString().ToLower()}";
            }

            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                using (var response = await httpClient.GetAsync(APIEndPoint + "CreatePlanHoangnv" + query))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        var result = JsonConvert.DeserializeObject<PaginationResult<CreatePlanQuitSmokingHoangNv>>(content);
                        if (result != null)
                        {
                            ViewData["CreatePlanHoangnv"] = result;
                            return View(result);
                        }
                    }
                }
            }
            return View(new PaginationResult<CreatePlanQuitSmokingHoangNv> { Items = new List<CreatePlanQuitSmokingHoangNv>() });
        }

        [HttpGet]
        public IActionResult Create(){
            ViewData["Title"] = "Create new plan";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePlanQuitSmokingHoangNv model)
        {
            // Lấy userId từ cookie và gán vào model
            var userIdString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "UserId").Value;
            if (!string.IsNullOrEmpty(userIdString) && int.TryParse(userIdString, out int userId))
            {
                model.UserAccountHoangNvid = userId;
                model.UserAccountHoangNv = null;
            }
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                var jsonContent = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(APIEndPoint + "CreatePlanHoangnv", jsonContent);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, "Tạo kế hoạch thất bại: " + error);
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
                var response = await httpClient.GetAsync(APIEndPoint + $"CreatePlanHoangnv/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<CreatePlanQuitSmokingHoangNv>(content);
                    if (model != null)
                    {
                        ViewData["CreatePlanHoangnv"] = model;
                        return View(model);
                    }
                }
            }
            return await Index(null, 1, 10, null);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CreatePlanQuitSmokingHoangNv model)
        {
            // Lấy userId từ cookie và gán vào model
            var userIdString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "UserId").Value;
            if (!string.IsNullOrEmpty(userIdString) && int.TryParse(userIdString, out int userId))
            {
                model.UserAccountHoangNvid = userId;
                model.UserAccountHoangNv = null;
            }
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                var jsonContent = new StringContent(JsonConvert.SerializeObject(model), System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(APIEndPoint + $"CreatePlanHoangnv/{model.CreatePlanQuitSmokingHoangNvid}", jsonContent);
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
                    var model = JsonConvert.DeserializeObject<CreatePlanQuitSmokingHoangNv>(content);
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
                var response = await httpClient.DeleteAsync(APIEndPoint + $"CreatePlanHoangnv/{CreatePlanQuitSmokingHoangNvid}");
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

        [HttpGet]
        public async Task<IActionResult> Detail(int id)
        {
            using (var httpClient = new HttpClient())
            {
                var tokenString = HttpContext.Request.Cookies.FirstOrDefault(c => c.Key == "TokenString").Value;
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + tokenString);
                var response = await httpClient.GetAsync(APIEndPoint + $"CreatePlanHoangnv/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<CreatePlanQuitSmokingHoangNv>(content);
                    if (model != null)
                    {
                        return View("Detail", model);
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
