using Hangfire;
using Hangfire.Storage;
using HangfireDemoConsoleApplication.BackgroundJobs.Contracts;
using HangfireDemoConsoleApplication.Wrappers.Contracts;

namespace HangfireDemoConsoleApplication.BackgroundJobs;

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
        BackgroundJob.Enqueue("CalculateFeeByEnqueueJob_Enqueue_type",
            () => _payrollWrapper.CalculatePayrollAsync());

        await Task.Delay(1);
    }

    public async Task CalculatePayrollByScheduleJob()
    {
        BackgroundJob.Schedule("CalculateFeeByScheduleJob_schedule_Type",
        () => _payrollWrapper.CalculatePayrollAsync(), TimeSpan.FromSeconds(10));

        await Task.Delay(1);
    }

    public async Task CalculatePayrollByRecurringJob()
    {
        //Cron.Daily
        //Cron.Yearly()
        //string cronExp = "* * */8 * *";

        RecurringJob.AddOrUpdate("CalculateFeeByRecurring_AddOrUpdate_Type",
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
