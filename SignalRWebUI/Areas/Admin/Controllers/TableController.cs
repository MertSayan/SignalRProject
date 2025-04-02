using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDto.TableDtos;
using System.Text;

namespace SignalRWebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Table")]
	public class TableController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public TableController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7155/api/Tables");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultTableDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		[Route("CreateTable")]
		public async Task<IActionResult> CreateTable()
		{
			return View();
		}
		[HttpPost]
		[Route("CreateTable")]
		public async Task<IActionResult> CreateTable(CreateTableDto createTableDto)
		{
			createTableDto.Status = false;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createTableDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7155/api/Tables", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Table", new { area = "Admin" });
			}
			return View();
		}
		[Route("DeleteTable/{id}")]
		public async Task<IActionResult> DeleteTable(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7155/api/Tables?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Table", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		[Route("UpdateTable/{id}")]
		public async Task<IActionResult> UpdateTable(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7155/api/Tables/ById?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateTableDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateTable/{id}")]
		public async Task<IActionResult> UpdateTable(UpdateTableDto updateTableDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateTableDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7155/api/Tables", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Table", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet("TableListBystatus")]
		[Route("TableListBystatus")]
		public async Task<IActionResult> TableListBystatus()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7155/api/Tables");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultTableDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
