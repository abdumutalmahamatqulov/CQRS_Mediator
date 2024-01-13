using CQRS_Mediator.Interfaces;
using CQRS_Mediator.Models;
using CQRS_Mediator.Queries.StudentQueries;
using MediatR;

namespace CQRS_Mediator.Handlers.StudentHandler;

internal sealed record GetStudentListHandler : IRequestHandler<GetStudentListQuery, List<Student>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentListHandler(IStudentRepository studentRepository)
        => _studentRepository = studentRepository;

    public async Task<List<Student>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        => await _studentRepository.GetStudentListAsync();
}
