using Hangfire;
using Hangfire.Storage;
using HangfireDemoBackground.BackgroundJobs.Contracts;
using HangfireDemoBackground.Wrappers.CalculatePayrollServiceAdapter.Contracts;

namespace HangfireDemoBackground.BackgroundJobs;

public class PayrollCalculatorJob : ICalculatorPayrollJob
{
    #region Fields

    private readonly ICalculatePayrollServiceAdapter _payrollWrapper;

    #endregion Fields

    #region Ctor

    public PayrollCalculatorJob(ICalculatePayrollServiceAdapter payrollWrapper)
    {
        _payrollWrapper = payrollWrapper;
    }

    #endregion Ctor

    public async Task EnqueueJob()
    {
        string jobId =
             BackgroundJob.Enqueue("calculatefeebyenqueuejob_enqueue_type",
            () => _payrollWrapper.CalculatePayrollAsync());

        await Task.Delay(1);
    }

    public async Task ScheduleJob()
    {
        string jobId =
            BackgroundJob.Schedule("calculatefeebyschedulejob_schedule_type",
         () => _payrollWrapper.CalculatePayrollAsync(),
         TimeSpan.FromSeconds(10));

        await Task.Delay(1);
    }

    public async Task RecurringJob()
    {
        //Cron.Daily
        //Cron.Yearly()
        //string cronExp = "* * */8 * *";

        Hangfire.RecurringJob.AddOrUpdate("calculatefeebyrecurring_addorupdate_type",
            () => _payrollWrapper.CalculatePayrollAsync(),
            Cron.Daily);

        await Task.Delay(1);
    }

    public Task CalculatePayrollByTrigger()
    {
        throw new NotImplementedException();
    }

    public Task CalculatePayrollByBatchJob()
    {
        throw new NotImplementedException();
    }

    public async Task RecurringRemoveIfExists()
    {
        using (var connection = JobStorage.Current.GetConnection())
        {
            //JobData jobData13 = connection.GetJobData("29");
            //BackgroundJob.Delete("29");

            foreach (var recurringJob in connection.GetRecurringJobs())
            {
                Hangfire.RecurringJob.RemoveIfExists(recurringJob.Id);
            }
        }

        await Task.Delay(1);
    }

    public async Task RemoveJob(string jobId)
    {
        BackgroundJob.Delete(jobId);
    }
}
