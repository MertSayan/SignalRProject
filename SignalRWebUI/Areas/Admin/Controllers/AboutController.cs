using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDto.AboutDtos;
using System.Text;

namespace SignalRWebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/About")]
	public class AboutController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public AboutController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7155/api/Abouts");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		[Route("UpdateAbout/{id}")]
		public async Task<IActionResult> UpdateAbout(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7155/api/Abouts/ById?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateAbout/{id}")]
		public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateAboutDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7155/api/Abouts", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "About", new { area = "Admin" });
			}
			return View();
		}
	}
}
