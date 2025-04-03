using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDto.DiscountDtos;
using System.Text;

namespace SignalRWebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Discount")]
	public class DiscountController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public DiscountController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7155/api/Discounts");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultDiscountDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		[Route("CreateDiscount")]
		public async Task<IActionResult> CreateDiscount()
		{
			return View();
		}
		[HttpPost]
		[Route("CreateDiscount")]
		public async Task<IActionResult> CreateDiscount(CreateDiscountDto createDiscountDto)
		{
			//createDiscountDto.Status = false;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createDiscountDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7155/api/Discounts", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Discount", new { area = "Admin" });
			}
			return View();
		}
		[Route("DeleteDiscount/{id}")]
		public async Task<IActionResult> DeleteDiscount(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7155/api/Discounts?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Discount", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		[Route("UpdateDiscount/{id}")]
		public async Task<IActionResult> UpdateDiscount(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7155/api/Discounts/ById?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateDiscountDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateDiscount/{id}")]
		public async Task<IActionResult> UpdateDiscount(UpdateDiscountDto updateDiscountDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateDiscountDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7155/api/Discounts", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Discount", new { area = "Admin" });
			}
			return View();
		}

        [Route("ChangeDiscountStatusToTrue/{id}")]
        public async Task<IActionResult> ChangeDiscountStatusToTrue(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.GetAsync("https://localhost:7155/api/Discounts/ChangeDiscountStatusToTrue?id="+id);
			return RedirectToAction("Index", "Discount", new { area = "Admin" });
        }

        [Route("ChangeDiscountStatusToFalse/{id}")]
        public async Task<IActionResult> ChangeDiscountStatusToFalse(int id)
        {
            var client = _httpClientFactory.CreateClient();
			await client.GetAsync("https://localhost:7155/api/Discounts/ChangeDiscountStatusToFalse?id="+id);

            return RedirectToAction("Index", "Discount", new { area = "Admin" });
        }
    }
}
