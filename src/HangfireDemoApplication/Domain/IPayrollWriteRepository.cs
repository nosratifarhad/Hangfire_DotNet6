using HangfireDemoApplication.Domain.Entitys;

namespace HangfireDemoApplication.Domain;

public interface IPayrollWriteRepository
{
    Task CreateUserPayrollAsync(User user);

}
