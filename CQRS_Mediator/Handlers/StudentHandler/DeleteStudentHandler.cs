using CQRS_Mediator.Commands.StudentCommand;
using CQRS_Mediator.Interfaces;
using MediatR;

namespace CQRS_Mediator.Handlers.StudentHandler;

internal sealed record DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, int>
{
    private readonly IStudentRepository _studentRepository;

    public DeleteStudentHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<int> Handle(DeleteStudentCommand command, CancellationToken cancellationToken)
    {
        var studentDetails = await _studentRepository.GetStudentByIdAsync(command.Id);
        if (studentDetails == null)
            return default;

        return await _studentRepository.DeleteStudentAsync(studentDetails.Id);
    }
}
