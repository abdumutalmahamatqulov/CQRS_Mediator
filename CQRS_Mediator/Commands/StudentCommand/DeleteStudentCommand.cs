using MediatR;

namespace CQRS_Mediator.Commands.StudentCommand;

public class DeleteStudentCommand : IRequest<int>
{
    public int Id { get; set; }
}
