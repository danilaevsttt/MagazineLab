using Magazine.Core.Models;
using Magazine.Core.Services;

namespace Magazine.WebApi.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new();

    public Task<Product> AddAsync(Product product)
    {
        _products.Add(product);
        return Task.FromResult(product);
    }

    public Task<Product?> RemoveAsync(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product != null)
            _products.Remove(product);
        return Task.FromResult(product);
    }

    public Task<Product?> EditAsync(Product product)
    {
        var existing = _products.FirstOrDefault(p => p.Id == product.Id);
        if (existing != null)
        {
            existing.Name = product.Name;
            existing.Definition = product.Definition;
            existing.Price = product.Price;
            existing.Image = product.Image;
        }
        return Task.FromResult(existing);
    }

    public Task<Product?> SearchAsync(Guid id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        return Task.FromResult(product);
    }
}