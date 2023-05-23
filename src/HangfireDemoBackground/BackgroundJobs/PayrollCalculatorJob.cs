using Hangfire;
using Hangfire.Storage;
using HangfireDemoBackground.BackgroundJobs.Contracts;
using HangfireDemoBackground.Wrappers.Contracts;

namespace HangfireDemoBackground.BackgroundJobs;

public class PayrollCalculatorJob : IPayrollCalculatorJob
{
    #region Fields

    private readonly IPayrollWrapper _payrollWrapper;

    #endregion Fields

    #region Ctor

    public PayrollCalculatorJob(IPayrollWrapper payrollWrapper)
    {
        _payrollWrapper = payrollWrapper;
    }

    #endregion Ctor

    public async Task CalculatePayrollByEnqueueJob()
    {
        string jobId =
             BackgroundJob.Enqueue("calculatefeebyenqueuejob_enqueue_type",
            () => _payrollWrapper.CalculatePayrollAsync());

        //BackgroundJob.Delete(jobId);

        await Task.Delay(1);
    }

    public async Task CalculatePayrollByScheduleJob()
    {
        string jobId =
            BackgroundJob.Schedule("calculatefeebyschedulejob_schedule_type",
         () => _payrollWrapper.CalculatePayrollAsync(), TimeSpan.FromSeconds(10));

        //BackgroundJob.Delete(jobId);

        await Task.Delay(1);
    }

    public async Task CalculatePayrollByRecurringJob()
    {
        //Cron.Daily
        //Cron.Yearly()
        //string cronExp = "* * */8 * *";

        RecurringJob.AddOrUpdate("calculatefeebyrecurring_addorupdate_type",
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
                RecurringJob.RemoveIfExists(recurringJob.Id);
            }
        }

        await Task.Delay(1);
    }

}
