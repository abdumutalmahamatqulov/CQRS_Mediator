using CQRS_Mediator.Dto_s;
using CQRS_Mediator.FluentValidation;
using CQRS_Mediator.Models;
using CQRS_Mediator.Models.LoginViewModel;
using CQRS_Mediator.Models.RegisterViewModel;

namespace IdentityDbContext1.Services;
public interface IAuthService
{
    public Task<User> Register(RegisterViewModel request);
    public Task<string> Login(LoginViewModel userDto);
    public Task<List<User>> UserList();
}
