using CQRS_Mediator.Models;
using MediatR;

namespace CQRS_Mediator.Queries.StudentQueries;

public class GetStudentListQuery : IRequest<List<Student>>
{
}
