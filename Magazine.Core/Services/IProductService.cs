using Magazine.Core.Models;

namespace Magazine.Core.Services;

public interface IProductService
{
    Task<Product> AddAsync(Product product);
    Task<Product?> RemoveAsync(Guid id);
    Task<Product?> EditAsync(Product product);
    Task<Product?> SearchAsync(Guid id);
}