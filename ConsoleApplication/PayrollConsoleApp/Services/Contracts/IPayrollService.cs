namespace PayrollConsoleApp.Services.Contracts;

public interface IPayrollService
{
    Task CalculatePayroll();

    Task MonthlyPayrollDirectDeposit();

    Task PayrollDirectDeposit(int userId);
    
}
