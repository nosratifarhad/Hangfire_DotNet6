using HangfireDemoApplication.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangfireDemoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobManagesController : ControllerBase
    {

        private readonly IJobManagesService _jobManagesService;

        public JobManagesController(IJobManagesService jobManagesService)
        {
            _jobManagesService = jobManagesService;
        }

        [HttpPost("/api/jobmanages/create-enqueue-job-calculate-payroll")]
        public async Task<IActionResult> CreateJobForCalculatePayroll()
        {
            await _jobManagesService.CreateJobForCalculatePayroll();

            return Ok();
        }

        [HttpPost("/api/jobmanages/create-schedule-job-calculate-payroll")]
        public async Task<IActionResult> CreateScheduleJobForCalculatePayroll()
        {
            await _jobManagesService.CreateScheduleJobForCalculatePayroll();

            return Ok();
        }

        [HttpPost("/api/jobmanages/create-recurring-job-calculate-payroll")]
        public async Task<IActionResult> CreateRecurringJobForCalculatePayroll()
        {
            await _jobManagesService.CreateRecurringJobForCalculatePayroll();

            return Ok();
        }

        [HttpPost("/api/jobmanages/create-trigger-job-calculate-payroll")]
        public async Task<IActionResult> CreateTriggerJobForCalculatePayroll()
        {
            await _jobManagesService.CreateTriggerJobForCalculatePayroll();

            return Ok();
        }

        [HttpPost("/api/jobmanages/create-batch-job-calculate-payroll")]
        public async Task<IActionResult> CreateBatchJobForCalculatePayroll()
        {
            await _jobManagesService.CreateBatchJobForCalculatePayroll();

            return Ok();
        }

        [HttpPost("/api/jobmanages/remove-job-all-jobs")]
        public async Task<IActionResult> RemoveJobAllJobs()
        {
            await _jobManagesService.RemoveJobAllJobs();

            return Ok();
        }

        [HttpPost("/api/jobmanages/remove-job-all-jobs/{jobId}")]
        public async Task<IActionResult> RemoveJobJob(string jobId)
        {
            await _jobManagesService.RemoveJob(jobId);

            return Ok();
        }

    }
}
