using CQRS_Mediator.Models;

namespace CQRS_Mediator.Dto_s;

public class UserDto
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ERole Role { get; set; }
}
