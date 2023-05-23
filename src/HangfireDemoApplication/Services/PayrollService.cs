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

    public async Task CalculatePayroll()
    {
        await CalculatePayrollByEnqueueJob();
        await CalculatePayrollByScheduleJob();
        await CalculatePayrollByRecurringJob();
        //await CalculatePayrollByTrigger();
        //await CalculatePayrollByBatchJob();
    }

    public async Task MonthlyPayrollDirectDeposit()
    {
    }

    public async Task PayrollDirectDeposit(int userId)
    {
    }

    private Task CalculatePayrollByEnqueueJob() => _payrollCalculatorJob.CalculatePayrollByEnqueueJob();

    private Task CalculatePayrollByScheduleJob() => _payrollCalculatorJob.CalculatePayrollByScheduleJob();

    private Task CalculatePayrollByRecurringJob() => _payrollCalculatorJob.CalculatePayrollByRecurringJob();

    private Task CalculatePayrollByTrigger() => _payrollCalculatorJob.CalculatePayrollByTrigger();

    private Task CalculatePayrollByBatchJob() => _payrollCalculatorJob.CalculatePayrollByBatchJob();

    private Task RecurringRemoveIfExists() => _payrollCalculatorJob.RecurringRemoveIfExists();
}
