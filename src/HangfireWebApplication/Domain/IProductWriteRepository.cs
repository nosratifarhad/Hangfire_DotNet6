using HangfireWebApplication.Domain.Entitys;

namespace HangfireWebApplication.Domain;

public interface IProductWriteRepository
{
    Task<int> CreateProductAsync(Product product);

    Task UpdateProductAsync(Product product);

    Task DeleteProductAsync(int productId);
}
