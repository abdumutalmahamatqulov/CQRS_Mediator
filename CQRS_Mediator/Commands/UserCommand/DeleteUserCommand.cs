using MediatR;

namespace CQRS_Mediator.Commands.UserCommand;

public class DeleteUserCommand : IRequest<int>
{
    public string Id { get; set; }
}
