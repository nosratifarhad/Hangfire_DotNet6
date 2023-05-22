namespace HangfireDemoConsoleApplication.BackgroundJobs.Contracts;

public interface IPayrollDirectDepositJob
{
    Task MonthlyPayrollDirectDeposit();

    Task PayrollDirectDeposit(int userId);
}
