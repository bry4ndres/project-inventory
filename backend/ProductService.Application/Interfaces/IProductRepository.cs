using ProductService.Domain.Entities;

namespace ProductService.Application.Interfaces
{
    public interface IProductRepository
    {
        Task AddAsync(Product product);
        Task UpdateAsync(Product product);
        Task<IEnumerable<Product>> GetAllAsync();
        Task DeleteAsync(Product id);
        Task<Product?> GetByIdAsync(int id);
    }
}
