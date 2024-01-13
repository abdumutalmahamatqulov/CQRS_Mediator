using System.ComponentModel.DataAnnotations;

namespace CQRS_Mediator.Models.RegisterViewModel;

public class RegisterViewModel
{
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ERole Role { get; set; }
}
