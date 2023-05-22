namespace HangfireDemoApplication.Services.Contract;

public interface IPayrollService
{
    Task CalculatePayroll();

    Task MonthlyPayrollDirectDeposit();

    Task PayrollDirectDeposit(int userId);

}
