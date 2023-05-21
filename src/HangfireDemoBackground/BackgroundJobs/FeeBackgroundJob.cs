using Hangfire;
using Hangfire.Common;
using HangfireDemoBackground.Wrappers.Contracts;
using HangfireDemoBackground.Wrappers.Dtos;

namespace HangfireDemoBackground.BackgroundJobs.Contracts;

public class FeeBackgroundJob : IFeeBackgroundJob
{
    private readonly IFeeWrapper _feeWrapper;

    public FeeBackgroundJob(IFeeWrapper feeWrapper)
    {
        _feeWrapper = feeWrapper;
    }

    public Task BatchJobBackground(ProductFeeDto productFeeDto, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public async Task EnqueueBackgroundJob(ProductFeeDto productFeeDto, CancellationToken cancellation)
    {
        BackgroundJob.Enqueue(() => Console.WriteLine("Enqueue Background Job"));

        BackgroundJob.Enqueue("Enqueue", () => Console.WriteLine("Enqueue Background Job"));

        BackgroundJob.Enqueue(() => _feeWrapper.CreatetFeeAsync(productFeeDto, cancellation));

        await Task.Delay(1);
    }

    public Task JobCancellation(ProductFeeDto productFeeDto, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public async Task RecurringAddOrUpdate(ProductFeeDto productFeeDto, CancellationToken cancellation)
    {
        RecurringJob.AddOrUpdate("AddOrUpdate", () => Console.Write("Recurring Job AddOrUpdate"), Cron.Daily);

        RecurringJob.AddOrUpdate("AddOrUpdate 1", () => Console.Write("Recurring Job AddOrUpdate"), Cron.Yearly());

        string cronExp = "* * */8 * *";
        RecurringJob.AddOrUpdate("AddOrUpdate 2", () => _feeWrapper.CreatetFeeAsync(productFeeDto, cancellation), cronExp);

        string cronExp1 = "0 12 * */2";
        RecurringJob.AddOrUpdate("AddOrUpdate 3",
            () => _feeWrapper.CreatetFeeAsync(productFeeDto, cancellation),
            cronExp1,
            options: new RecurringJobOptions
            {
                TimeZone = TimeZoneInfo.Local
            });

        await Task.Delay(1);
    }

    public async Task RecurringRemoveIfExists()
    {
        RecurringJob.RemoveIfExists("AddOrUpdate");
        RecurringJob.RemoveIfExists("AddOrUpdate 1");
        RecurringJob.RemoveIfExists("AddOrUpdate 2");
        RecurringJob.RemoveIfExists("AddOrUpdate 3");

        await Task.Delay(1);
    }

    public Task RecurringTrigger(ProductFeeDto productFeeDto, CancellationToken cancellation)
    {
        throw new NotImplementedException();
    }

    public async Task ScheduleBackgroundJob(ProductFeeDto productFeeDto, CancellationToken cancellation)
    {
        BackgroundJob.Schedule(() => Console.WriteLine("Schedule Background Job"), TimeSpan.FromDays(1));

        BackgroundJob.Schedule("Schedule",
            () => _feeWrapper.CreatetFeeAsync(productFeeDto, cancellation), TimeSpan.FromSeconds(5));

        await Task.Delay(1);
    }
}
