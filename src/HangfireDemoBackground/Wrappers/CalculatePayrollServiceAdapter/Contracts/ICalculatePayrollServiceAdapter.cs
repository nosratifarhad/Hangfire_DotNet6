namespace HangfireDemoBackground.Wrappers.CalculatePayrollServiceAdapter.Contracts;

public interface ICalculatePayrollServiceAdapter
{
    Task CalculatePayrollAsync();

    Task MonthlyPayrollDirectDeposit();

}
