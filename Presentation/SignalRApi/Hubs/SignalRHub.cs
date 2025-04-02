using Application.Features.Mediatr.Notifications.Queries;
using Application.Interfaces;
using Domain;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Persistence.Context;

namespace SignalRApi.Hubs
{
	public class SignalRHub:Hub
	{
		private readonly ICategoryRepository _categoryRepository;
		private readonly IProductRepository _productRepository;
		private readonly IOrderRepository _orderRepository;
		private readonly IMoneyCaseRepository _moneyCaseRepository;
		private readonly ITableRepository _tableRepository;
		private readonly IGenericRepository<Booking> _bookingRepository;
		private readonly IMediator _mediator;
		private readonly INotificationRepository _notificationRepository;
		private readonly IGenericRepository<Table> _genericTableRepository;



        public SignalRHub(ICategoryRepository categoryRepository, IProductRepository productRepository, IOrderRepository orderRepository, IMoneyCaseRepository moneyCaseRepository, ITableRepository tableRepository, IGenericRepository<Booking> bookingRepository, IMediator mediator, INotificationRepository notificationRepository, IGenericRepository<Table> genericTableRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _moneyCaseRepository = moneyCaseRepository;
            _tableRepository = tableRepository;
            _bookingRepository = bookingRepository;
            _mediator = mediator;
            _notificationRepository = notificationRepository;
            _genericTableRepository = genericTableRepository;
        }

		public static int clientCount { get; set; } = 0;
        public async Task TakeDashboardCount()
		{
			var categoryCount = await _categoryRepository.GetCategoryCount();
			var productCount = await _productRepository.GetProductCount();
			var activeCategoryCount = await _categoryRepository.GetActiveCategoryCount();
			var passiveCategoryCount = await _categoryRepository.GetPassiveCategoryCount();
			var corbaCount = await _productRepository.GetProductCountByCategoryName("Çorba");
			var tatliCount = await _productRepository.GetProductCountByCategoryName("Tatlı");
			var avgPrice = await _productRepository.GetProductPriceAvg();
			var maxPrice = await _productRepository.GetProductByMaxPrice();
			var minPrice = await _productRepository.GetProductByMinPrice();
			var avgSweetPrice = await _productRepository.GetProductPriceAvgByCategoryName("Tatlı");
			var orderCount = await _orderRepository.GetTotalOrderCount();
			var activeOrderCount = await _orderRepository.GetActiveOrderCount();
			var lastOrderPrice = await _orderRepository.GetLastOrderPrice();
			var totalMoneyCaseAmounth = await _moneyCaseRepository.GetTotalMoneyCaseAmount();
			var tableCount=await _tableRepository.GetTableCount();




			var dashboardCount = new
			{
				CategoryCount=categoryCount,
				ProductCount = productCount,
				ActiveCategoryCount = activeCategoryCount,
				PassiveCategoryCount = passiveCategoryCount,
				ÇorbaCount = corbaCount,
				TatlıCount = tatliCount,
				AvgPrice = avgPrice.ToString("0.00") + "tl",
				MaxPrice = maxPrice,
				MinPrice = minPrice,
				AvgSweetPrice = avgSweetPrice.ToString("0.00") + " tl",
				OrderCount = orderCount,
				ActiveOrderCount = activeOrderCount,
				LastOrderPrice = lastOrderPrice.ToString("0.00") + " tl",
				TotalMoneyCaseAmounth = totalMoneyCaseAmounth.ToString("0.00") + " tl",
				TableCount=tableCount,
			};

			await Clients.All.SendAsync("ReceiveDashboardCounts", dashboardCount);
		}

		public async Task SendProgressBar()
		{
            var totalMoneyCaseAmounth = await _moneyCaseRepository.GetTotalMoneyCaseAmount();
            var activeOrderCount = await _orderRepository.GetActiveOrderCount();
            var tableCount = await _tableRepository.GetTableCount();

            var dashboardCount = new
            {
                TotalMoneyCaseAmounth = totalMoneyCaseAmounth.ToString("0.00") + " tl",
                ActiveOrderCount = activeOrderCount,
                TableCount = tableCount,
            };
            await Clients.All.SendAsync("ReceiveProgressBar", dashboardCount);
        }
		
		public async Task GetBookingList()
		{
			var value=await _bookingRepository.GetListAllAsync();


			await Clients.All.SendAsync("ReceiveBookingList",value);
		}

		public async Task SendNotification()
		{
			

			var notReadNotificationCount = await _notificationRepository.GetNotificationCountByNotRead();
			var notificationListNotRead = await _notificationRepository.GetAllNotificationByNotRead();

			var notifications = new
			{
				NotReadNotificationCount=notReadNotificationCount,
				NotificationListNotRead=notificationListNotRead,
			};

			await Clients.All.SendAsync("ReceiveNotification", notifications);
		}

		public async Task GetMenuTableStatus()
		{
			var value = await _genericTableRepository.GetListAllAsync();
			await Clients.All.SendAsync("ReceiveMenuTableStatus", value);
		}

		public async Task SendMessage(string user,string message)
		{
			await Clients.All.SendAsync("ReceiveMessage", user, message);
		}

        public override async Task OnConnectedAsync()
        {
			clientCount++;
			await Clients.All.SendAsync("ReceiveClientCount",clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
			clientCount--;
			await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
