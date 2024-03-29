﻿using CQRS_Mediator.Models;
using MediatR;

namespace CQRS_Mediator.Commands.UserCommand;

public class UpdateUserCommand : IRequest<int>
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Id { get; set; }
    public ERole Role { get; set; }

    public UpdateUserCommand(string id, string name, string email, string password, ERole role)
    {
        Id = id;
        Name = name;
        Email = email;
        Password = password;
        Role = role;
    }
}
