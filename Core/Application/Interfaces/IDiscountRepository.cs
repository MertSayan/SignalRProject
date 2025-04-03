using Domain;

namespace Application.Interfaces
{
	public interface IDiscountRepository
    {
        Task ChangeStatusToTrue(int id);
        Task ChangeStatusToFalse(int id);
        Task<List<Discount>> GetListByStatusTrue();
    }
}
