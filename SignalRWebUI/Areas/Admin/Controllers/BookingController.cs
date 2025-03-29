using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDto.BookingDtos;
using System.Text;

namespace SignalRWebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Booking")]
	public class BookingController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public BookingController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
        [HttpGet]
        [Route("Index")]
		public async Task<IActionResult> Index()
        {
            var client=_httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7155/api/Bookings");
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData=await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBookingDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
		[Route("CreateBooking")]
		public async Task<IActionResult> CreateBooking()
        {
            return View();
        }
		[HttpPost]
		[Route("CreateBooking")]
		public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData=JsonConvert.SerializeObject(createBookingDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("https://localhost:7155/api/Bookings", stringContent);
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index","Booking",new {area="Admin"});
            }
            return View();
        }
		[Route("DeleteBooking/{id}")]
		public async Task<IActionResult> DeleteBooking(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7155/api/Bookings?id={id}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Booking", new { area = "Admin" });
            }
            return View();
        }

		[HttpGet]
		[Route("UpdateBooking/{id}")]
		public async Task<IActionResult> UpdateBooking(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7155/api/Bookings/ById?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateBookingDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateBooking/{id}")]
		public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateBookingDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7155/api/Bookings", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Booking", new { area = "Admin" });
			}
			return View();
		}
	}
}
