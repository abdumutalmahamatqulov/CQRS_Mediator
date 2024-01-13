using CQRS_Mediator.Interfaces;
using CQRS_Mediator.Models;
using CQRS_Mediator.Queries.StudentQueries;
using MediatR;

namespace CQRS_Mediator.Handlers.StudentHandler;

public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Student>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentByIdHandler(IStudentRepository studentRepository)
        => _studentRepository = studentRepository;

    public async Task<Student> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        => await _studentRepository.GetStudentByIdAsync(query.Id);
}
