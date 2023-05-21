using HangfireDemoApplication.InputModels.ProductInputModels;
using HangfireDemoApplication.ViewModels.ProductViewModels;

namespace HangfireDemoApplication.Services.Contract
{
    public interface IProductService
    {
        Task<int> CreateProductAsync(CreateProductInputModel inputModel);

        Task UpdateProductAsync(UpdateProductInputModel inputModel);

        Task DeleteProductAsync(int productId);

        ValueTask<ProductViewModel> GetProductAsync(int productId);

        ValueTask<IEnumerable<ProductViewModel>> GetProductsAsync();

    }
}
