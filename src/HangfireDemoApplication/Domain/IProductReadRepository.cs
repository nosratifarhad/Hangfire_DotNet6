using HangfireDemoApplication.Domain.Entitys;

namespace HangfireDemoApplication.Domain;

public interface IProductReadRepository
{
    Task<Product> GetProductAsync(int productId);

    Task<IEnumerable<Product>> GetProductsAsync();

    Task<bool> IsExistProductAsync(int productId);
}
