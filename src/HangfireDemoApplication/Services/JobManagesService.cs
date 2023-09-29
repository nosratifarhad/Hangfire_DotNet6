using HangfireDemoApplication.Services.Contract;
using HangfireDemoBackground.BackgroundJobs.Contracts;

namespace HangfireDemoApplication.Services
{
    public class JobManagesService : IJobManagesService
    {
        #region Fields

        private readonly ICalculatorPayrollJob _calculatorPayrollJob;
        private readonly ILogger<JobManagesService> _logger;

        #endregion Fields

        #region Ctor

        public JobManagesService(ICalculatorPayrollJob calculatorPayrollJob, ILogger<JobManagesService> logger)
        {
            _calculatorPayrollJob = calculatorPayrollJob;
            _logger = logger;
        }

        #endregion Ctor

        public async Task CreateJobForCalculatePayroll()
        {
            _logger.LogInformation("Calculate Payroll By Enqueue Job");
            await _calculatorPayrollJob.EnqueueJob();
        }

        public async Task CreateRecurringJobForCalculatePayroll()
        {
            _logger.LogInformation("Calculate Payroll By Recurring Job");
            await _calculatorPayrollJob.RecurringJob();
        }

        public async Task CreateScheduleJobForCalculatePayroll()
        {
            _logger.LogInformation("Calculate Payroll By Schedule Job");
            await _calculatorPayrollJob.ScheduleJob();
        }

        public async Task CreateTriggerJobForCalculatePayroll()
        {
            _logger.LogInformation("Calculate Payroll By Trigger Job");
            await _calculatorPayrollJob.CalculatePayrollByTrigger();
        }

        public async Task CreateBatchJobForCalculatePayroll()
        {
            _logger.LogInformation("Calculate Payroll By Batch Job");
            await _calculatorPayrollJob.CalculatePayrollByBatchJob();
        }

        public async Task RemoveJobAllJobs()
        {
            _logger.LogInformation("Recurring Remove All Jobs If Exists");
            await _calculatorPayrollJob.RecurringRemoveIfExists();
        }

        public async Task RemoveJob(string jobId)
        {
            _logger.LogInformation($"Recurring Remove Job ({jobId}) If Exists");
            await _calculatorPayrollJob.RemoveJob(jobId);
        }
    }
}
