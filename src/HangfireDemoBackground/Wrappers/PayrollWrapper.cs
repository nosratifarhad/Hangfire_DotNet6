using HangfireDemoBackground.Wrappers.Contracts;

namespace HangfireDemoBackground.Wrappers;

public class PayrollWrapper : IPayrollWrapper
{
    public async Task CalculatePayrollAsync()
    {
        Console.WriteLine("send request to payroll system");
        Task.Delay(1000).Wait();
    }

    public async Task MonthlyPayrollDirectDeposit()
    {
        Console.WriteLine("send request to payroll system");
        Task.Delay(1000).Wait();
    }

    public async Task PayrollDirectDeposit(int userId)
    {
        Console.WriteLine("send request to payroll system");
        Task.Delay(1000).Wait();
    }

}
