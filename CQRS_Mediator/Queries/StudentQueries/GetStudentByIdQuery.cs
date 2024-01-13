using CQRS_Mediator.Models;
using MediatR;

namespace CQRS_Mediator.Queries.StudentQueries;

public class GetStudentByIdQuery : IRequest<Student>
{
    public int Id { get; set; }
}
