using Domain;

namespace Application.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllProductWithCategories();
        Task<int> GetProductCount();
        Task<int> GetProductCountByCategoryName(string categoryName);
        Task<decimal> GetProductPriceAvg();
        Task<string> GetProductByMaxPrice();
        Task<string> GetProductByMinPrice();
        Task<decimal> GetProductPriceAvgByCategoryName(string categoryName);
    }
}
