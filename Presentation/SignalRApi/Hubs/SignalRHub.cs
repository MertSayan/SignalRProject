using Application.Interfaces;
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


        public SignalRHub(ICategoryRepository categoryRepository, IProductRepository productRepository, IOrderRepository orderRepository, IMoneyCaseRepository moneyCaseRepository, ITableRepository tableRepository)
        {
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
            _moneyCaseRepository = moneyCaseRepository;
            _tableRepository = tableRepository;
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
	}
}
