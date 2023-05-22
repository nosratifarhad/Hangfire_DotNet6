namespace HangfireDemoBackground.BackgroundJobs.Contracts;

public interface IPayrollCalculatorJob
{
    Task CalculatePayrollByEnqueueJob();

    Task CalculatePayrollByScheduleJob();

    Task CalculatePayrollByRecurringJob();

    Task CalculatePayrollByTrigger();

    Task CalculatePayrollByBatchJob();

    Task RecurringRemoveIfExists();

}
