using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDto.FeatureDtos;
using System.Text;

namespace SignalRWebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Feature")]
	public class FeatureController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public FeatureController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7155/api/Features");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		[Route("CreateFeature")]
		public async Task<IActionResult> CreateFeature()
		{
			return View();
		}
		[HttpPost]
		[Route("CreateFeature")]
		public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createFeatureDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7155/api/Features", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Feature", new { area = "Admin" });
			}
			return View();
		}
		[Route("DeleteFeature/{id}")]
		public async Task<IActionResult> DeleteFeature(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7155/api/Features?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Feature", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		[Route("UpdateFeature/{id}")]
		public async Task<IActionResult> UpdateFeature(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7155/api/Features/ById?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateFeatureDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateFeature/{id}")]
		public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateFeatureDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7155/api/Features", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Feature", new { area = "Admin" });
			}
			return View();
		}
	}
}
