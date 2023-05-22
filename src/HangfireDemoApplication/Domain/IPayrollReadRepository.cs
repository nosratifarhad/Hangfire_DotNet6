using HangfireDemoApplication.Domain.Entitys;

namespace HangfireDemoApplication.Domain;

public interface IPayrollReadRepository
{
    Task<IEnumerable<User>> GetUserPayrollsAsync();

}
