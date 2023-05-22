using HangfireDemoBackground.BackgroundJobs.Contracts;

namespace HangfireDemoBackground.BackgroundJobs;

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
