namespace HangfireDemoBackground.BackgroundJobs.Contracts;

public interface ICalculatorPayrollJob
{
    Task EnqueueJob();

    Task ScheduleJob();

    Task RecurringJob();

    Task CalculatePayrollByTrigger();

    Task CalculatePayrollByBatchJob();

    Task RecurringRemoveIfExists();

    Task RemoveJob(string jobId);
}
