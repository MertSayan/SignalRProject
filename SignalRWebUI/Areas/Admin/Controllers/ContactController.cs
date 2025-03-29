using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDto.ContactDtos;
using System.Text;

namespace SignalRWebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Contact")]
	public class ContactController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public ContactController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7155/api/Contacts");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		[Route("CreateContact")]
		public async Task<IActionResult> CreateContact()
		{
			return View();
		}
		[HttpPost]
		[Route("CreateContact")]
		public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createContactDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7155/api/Contacts", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Contact", new { area = "Admin" });
			}
			return View();
		}
		[Route("DeleteContact/{id}")]
		public async Task<IActionResult> DeleteContact(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7155/api/Contacts?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Contact", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		[Route("UpdateContact/{id}")]
		public async Task<IActionResult> UpdateContact(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7155/api/Contacts/ById?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateContact/{id}")]
		public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateContactDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7155/api/Contacts", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Contact", new { area = "Admin" });
			}
			return View();
		}
	}
}
