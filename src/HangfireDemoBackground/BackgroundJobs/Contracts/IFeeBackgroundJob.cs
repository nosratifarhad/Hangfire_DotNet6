using HangfireDemoBackground.Wrappers.Dtos;

namespace HangfireDemoBackground.BackgroundJobs.Contracts;

public interface IFeeBackgroundJob
{
    Task EnqueueBackgroundJob(ProductFeeDto productFeeDto, CancellationToken cancellation);

    Task ScheduleBackgroundJob(ProductFeeDto productFeeDto, CancellationToken cancellation);

    Task RecurringAddOrUpdate(ProductFeeDto productFeeDto, CancellationToken cancellation);

    Task RecurringRemoveIfExists();

    Task RecurringTrigger(ProductFeeDto productFeeDto, CancellationToken cancellation);

    Task JobCancellation(ProductFeeDto productFeeDto, CancellationToken cancellation);

    Task BatchJobBackground(ProductFeeDto productFeeDto, CancellationToken cancellation);

    //BackgroundJob

}
