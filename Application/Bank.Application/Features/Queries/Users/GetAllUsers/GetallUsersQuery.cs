using MediatR;

namespace Bank.Application.Features.Queries.Users.GetAllUsers;

public class GetallUsersQuery : IRequest<List<UserListDto>>
{
}