using HangfireDemoApplication.Domain;
using HangfireDemoApplication.Domain.Entitys;

namespace HangfireDemoApplication.Infra.Repositories.WriteRepositories.PayrollWriteRepositories;

public class PayrollWriteRepository : IPayrollWriteRepository
{
    public async Task CreateUserPayrollAsync(User user)
    {
        Task.Delay(1000);
    }

}
