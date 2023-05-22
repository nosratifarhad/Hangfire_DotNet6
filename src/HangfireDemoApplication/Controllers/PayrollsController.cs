using HangfireDemoApplication.Services.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HangfireDemoApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PayrollsController : ControllerBase
    {
        #region Fields
        private readonly IPayrollService _payrollService;

        #endregion Fields

        #region Ctor
        public PayrollsController(IPayrollService payrollService)
        {
            _payrollService = payrollService;
        }

        #endregion Ctor

        [HttpGet("/api/payrolls")]
        public async Task<IActionResult> GetPayrolls()
        {
            await _payrollService.CalculatePayroll();

            return Ok();
        }

    }
}
