using HangfireDemoBackground.Wrappers.Contracts;
using HangfireDemoBackground.Wrappers.Dtos;

namespace HangfireDemoBackground.Wrappers;

public class FeeWrapper : IFeeWrapper
{
    public async Task CreatetFeeAsync(ProductFeeDto productFeeDto, CancellationToken cancellation)
    {
        await Task.Run(() => { Console.WriteLine("Createt Fee ."); });
    }

    public async Task RemoveFeeAsync(ProductFeeDto productFeeDto, CancellationToken cancellation)
    {
        await Task.Run(() => { Console.WriteLine("Update Fee ."); });
    }

    public async Task UpdateFeeAsync(ProductFeeDto productFeeDto, CancellationToken cancellation)
    {
        await Task.Run(() => { Console.WriteLine("Remove Fee ."); });
    }
}
