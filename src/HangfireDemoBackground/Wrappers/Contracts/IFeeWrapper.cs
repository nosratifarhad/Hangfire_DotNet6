using HangfireDemoBackground.Wrappers.Dtos;

namespace HangfireDemoBackground.Wrappers.Contracts;

public interface IFeeWrapper
{
    Task CreatetFeeAsync(ProductFeeDto productFeeDto, CancellationToken cancellation);

    Task UpdateFeeAsync(ProductFeeDto productFeeDto, CancellationToken cancellation);

    Task RemoveFeeAsync(ProductFeeDto productFeeDto, CancellationToken cancellation);

}
