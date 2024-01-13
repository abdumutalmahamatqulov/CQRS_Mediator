using CQRS_Mediator.Dto_s;
using CQRS_Mediator.Models;
using MediatR;

namespace CQRS_Mediator.Commands.UserCommand;

public class CreateUserCommand : IRequest<UserDto>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ERole Role { get; set; }
    public CreateUserCommand(string name, string email, string password, ERole role)
    {
        Name = name;
        Password = password;
        Email = email;
        Role = role;
    }
}
