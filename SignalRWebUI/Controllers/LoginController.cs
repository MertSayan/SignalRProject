using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDto.IdentityDtos;
using System.Text;

namespace SignalRWebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public LoginController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(CreateLoginDto createLoginDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createLoginDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7155/api/Logins", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Default");
			}

			return View();
		}
	}
}
