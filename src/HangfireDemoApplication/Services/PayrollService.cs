using HangfireDemoApplication.Services.Contract;
using HangfireDemoBackground.BackgroundJobs.Contracts;

namespace HangfireDemoApplication.Services;

public class PayrollService : IPayrollService
{
    private readonly IPayrollCalculatorJob _payrollCalculatorJob;
    private readonly IPayrollDirectDepositJob _payrollDirectDepositJob;

    public PayrollService(IPayrollCalculatorJob payrollCalculatorJob, IPayrollDirectDepositJob payrollDirectDepositJob)
    {
        _payrollCalculatorJob = payrollCalculatorJob;
        _payrollDirectDepositJob = payrollDirectDepositJob;
    }

    public Task CalculatePayroll()
    {
        throw new NotImplementedException();
    }

    public Task MonthlyPayrollDirectDeposit()
    {
        throw new NotImplementedException();
    }

    public Task PayrollDirectDeposit(int userId)
    {
        throw new NotImplementedException();
    }

    private Task CalculatePayrollByEnqueueJob() => _payrollCalculatorJob.CalculatePayrollByEnqueueJob();

    private Task CalculatePayrollByScheduleJob() => _payrollCalculatorJob.CalculatePayrollByScheduleJob();

    private Task CalculatePayrollByRecurringJob() => _payrollCalculatorJob.CalculatePayrollByRecurringJob();

    private Task CalculatePayrollByTrigger() => _payrollCalculatorJob.CalculatePayrollByTrigger();

    private Task CalculatePayrollByBatchJob() => _payrollCalculatorJob.CalculatePayrollByBatchJob();

    private Task RecurringRemoveIfExists() => _payrollCalculatorJob.RecurringRemoveIfExists();
}
