using CQRS_Mediator.Dto_s;
using CQRS_Mediator.Models;
using MediatR;

namespace CQRS_Mediator.Queries.UserQueries;

public class GetUserListQuery : IRequest<List<UserDto>>
{
}
