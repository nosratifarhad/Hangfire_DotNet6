using HangfireDemoConsoleApplication.BackgroundJobs.Contracts;

namespace HangfireDemoConsoleApplication.BackgroundJobs;

public class PayrollDirectDepositJob : IPayrollDirectDepositJob
{
    public Task MonthlyPayrollDirectDeposit()
    {
        throw new NotImplementedException();
    }

    public Task PayrollDirectDeposit(int userId)
    {
        throw new NotImplementedException();
    }
}
