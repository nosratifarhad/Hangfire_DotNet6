namespace HangfireDemoApplication.Services.Contract;

public interface IJobManagesService
{
    Task CreateJobForCalculatePayroll();

    Task CreateScheduleJobForCalculatePayroll();

    Task CreateRecurringJobForCalculatePayroll();

    Task CreateTriggerJobForCalculatePayroll();

    Task CreateBatchJobForCalculatePayroll();

    Task RemoveJobAllJobs();

    Task RemoveJob(string jobId);
}
