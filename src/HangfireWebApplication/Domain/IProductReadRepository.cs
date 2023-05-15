using HangfireWebApplication.Domain.Entitys;

namespace HangfireWebApplication.Domain;

public interface IProductReadRepository
{
    Task<Product> GetProductAsync(int productId);

    Task<IEnumerable<Product>> GetProductsAsync();

    Task<bool> IsExistProductAsync(int productId);
}
