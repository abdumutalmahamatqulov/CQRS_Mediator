using CQRS_Mediator.Commands.StudentCommand;
using CQRS_Mediator.Interfaces;
using CQRS_Mediator.Models;
using MediatR;

namespace CQRS_Mediator.Handlers.StudentHandler;

public class CreateStudentHandler : IRequestHandler<CreateStudentCommand, Student>
{
    private readonly IStudentRepository _studentRepository;

    public CreateStudentHandler(IStudentRepository studentRepository)
        => _studentRepository = studentRepository;

    public async Task<Student> Handle(CreateStudentCommand command, CancellationToken cancellationToken)
    {
        var studentDetails = new Student()
        {
            StudentName = command.StudentName,
            StudentEmail = command.StudentEmail,
            StudentAddress = command.StudentAddress,
            StudentAge = command.StudentAge
        };
        return await _studentRepository.AddStudentAsync(studentDetails);
    }
}
