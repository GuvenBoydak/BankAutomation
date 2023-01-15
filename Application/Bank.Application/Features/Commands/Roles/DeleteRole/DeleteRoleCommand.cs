using MediatR;

namespace Bank.Application.Features.Commands.Roles.DeleteRole;

public class DeleteRoleCommand : IRequest
{
    public Guid Id { get; set; }
}