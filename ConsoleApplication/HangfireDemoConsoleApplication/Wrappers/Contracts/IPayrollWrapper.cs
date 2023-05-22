namespace HangfireDemoConsoleApplication.Wrappers.Contracts;

public interface IPayrollWrapper
{
    Task CalculatePayrollAsync();

    Task MonthlyPayrollDirectDeposit();

    Task PayrollDirectDeposit(int userId);

}
