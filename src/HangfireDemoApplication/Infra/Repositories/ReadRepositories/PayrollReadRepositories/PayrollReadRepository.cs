using HangfireDemoApplication.Domain;
using HangfireDemoApplication.Domain.Entitys;

namespace HangfireDemoApplication.Infra.Repositories.ReadRepositories.PayrollReadRepositories;

public class PayrollReadRepository : IPayrollReadRepository
{
    public async Task<IEnumerable<User>> GetUserPayrollsAsync()
    {
        return await Task.Run(async () => Enumerable.Empty<User>());
    }
}
