using Application.Interfaces;
using Domain;
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


        public SignalRHub(ICategoryRepository categoryRepository, IProductRepository productRepository, IOrderRepository orderRepository, IMoneyCaseRepository moneyCaseRepository, ITableRepository tableRepository, IGenericRepository<Booking> bookingRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _moneyCaseRepository = moneyCaseRepository;
            _tableRepository = tableRepository;
            _bookingRepository = bookingRepository;
        }


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
    }
}
