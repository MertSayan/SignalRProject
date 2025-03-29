using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDto.TestimonialDtos;
using System.Text;

namespace SignalRWebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Testimonial")]
	public class TestimonialController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public TestimonialController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7155/api/Testimonials");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		[Route("CreateTestimonial")]
		public async Task<IActionResult> CreateTestimonial()
		{
			return View();
		}
		[HttpPost]
		[Route("CreateTestimonial")]
		public async Task<IActionResult> CreateTestimonial(CreateTestimonialDto createTestimonialDto)
		{
			createTestimonialDto.Status = true;
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createTestimonialDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7155/api/Testimonials", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
			}
			return View();
		}
		[Route("DeleteTestimonial/{id}")]
		public async Task<IActionResult> DeleteTestimonial(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7155/api/Testimonials?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		[Route("UpdateTestimonial/{id}")]
		public async Task<IActionResult> UpdateTestimonial(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7155/api/Testimonials/ById?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateTestimonialDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateTestimonial/{id}")]
		public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialDto updateTestimonialDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateTestimonialDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7155/api/Testimonials", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
			}
			return View();
		}
	}
}
