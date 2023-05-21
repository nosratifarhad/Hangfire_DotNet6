using Hangfire;
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


        await Task.Delay(1);
    }

    public Task RecurringRemoveIfExists(ProductFeeDto productFeeDto, CancellationToken cancellation)
    {
        throw new NotImplementedException();
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
