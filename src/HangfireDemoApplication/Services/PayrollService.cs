﻿using HangfireDemoApplication.Services.Contract;

namespace HangfireDemoApplication.Services;

public class PayrollService : IPayrollService
{
    public Task CalculatePayroll()
    {
        throw new NotImplementedException();
    }

    public Task MonthlyPayrollDirectDeposit()
    {
        throw new NotImplementedException();
    }

    public Task PayrollDirectDeposit(int userId)
    {
        throw new NotImplementedException();
    }
}
