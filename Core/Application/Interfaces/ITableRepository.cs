namespace Application.Interfaces
{
    public interface ITableRepository
    {
        Task<int> GetTableCount();
    }
}
