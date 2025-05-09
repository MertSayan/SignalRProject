﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalRDto.NotificationDtos;
using System.Text;

namespace SignalRWebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/Notification")]
	public class NotificationController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public NotificationController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		[HttpGet]
		[Route("Index")]
		public async Task<IActionResult> Index()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7155/api/Notifications");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(jsonData);
				return View(values);
			}
			return View();
		}

		[HttpGet]
		[Route("CreateNotification")]
		public async Task<IActionResult> CreateNotification()
		{
			return View();
		}
		[HttpPost]
		[Route("CreateNotification")]
		public async Task<IActionResult> CreateNotification(CreateNotificationDto createNotificationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(createNotificationDto);
			StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PostAsync("https://localhost:7155/api/Notifications", stringContent);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Notification", new { area = "Admin" });
			}
			return View();
		}
		[Route("DeleteNotification/{id}")]
		public async Task<IActionResult> DeleteNotification(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.DeleteAsync($"https://localhost:7155/api/Notifications?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Notification", new { area = "Admin" });
			}
			return View();
		}

		[HttpGet]
		[Route("UpdateNotification/{id}")]
		public async Task<IActionResult> UpdateNotification(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7155/api/Notifications/ById?id={id}");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<UpdateNotificationDto>(jsonData);
				return View(values);
			}
			return View();
		}
		[HttpPost]
		[Route("UpdateNotification/{id}")]
		public async Task<IActionResult> UpdateNotification(UpdateNotificationDto updateNotificationDto)
		{
			var client = _httpClientFactory.CreateClient();
			var jsonData = JsonConvert.SerializeObject(updateNotificationDto);
			StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
			var responseMessage = await client.PutAsync("https://localhost:7155/api/Notifications", content);
			if (responseMessage.IsSuccessStatusCode)
			{
				return RedirectToAction("Index", "Notification", new { area = "Admin" });
			}
			return View();
		}
		[Route("NotificationChangeToRead/{id}")]
		public async Task<IActionResult> NotificationChangeToRead(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync("https://localhost:7155/api/Notifications/UpdateNotificationToRead?id="+id);
			
			return RedirectToAction("Index", "Notification", new { area = "Admin" });
		}
		[Route("NotificationChangeToNotRead/{id}")]
		public async Task<IActionResult> NotificationChangeToNotRead(int id)
		{
			var client = _httpClientFactory.CreateClient();
			await client.GetAsync("https://localhost:7155/api/Notifications/UpdateNotificationToNotRead?id=" + id);

			return RedirectToAction("Index", "Notification", new { area = "Admin" });
		}
	}
}
