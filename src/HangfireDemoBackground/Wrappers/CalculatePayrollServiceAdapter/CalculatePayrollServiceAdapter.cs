using HangfireDemoBackground.Wrappers.CalculatePayrollServiceAdapter.Contracts;
using Microsoft.Extensions.Logging;

namespace HangfireDemoBackground.Wrappers.CalculatePayrollServiceAdapter;

public class CalculatePayrollServiceAdapter : ICalculatePayrollServiceAdapter
{

    private readonly ILogger<CalculatePayrollServiceAdapter> _logger;

    public CalculatePayrollServiceAdapter(ILogger<CalculatePayrollServiceAdapter> logger)
    {
        _logger = logger;
    }

    public async Task CalculatePayrollAsync()
    {
        _logger.LogInformation("Calculate Payroll By Accountant Service");
        Task.Delay(1000).Wait();
    }

    public async Task MonthlyPayrollDirectDeposit()
    {
        _logger.LogInformation("send request to payroll system");

        Task.Delay(1000).Wait();
    }

}
