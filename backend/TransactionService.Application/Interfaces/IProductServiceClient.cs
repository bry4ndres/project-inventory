namespace TransactionService.Application.Interfaces
{
    public interface IProductServiceClient
    {
        Task<int> GetStockAsync(int productId);
        Task UpdateStockAsync(int productId, int quantity);
    }
}
