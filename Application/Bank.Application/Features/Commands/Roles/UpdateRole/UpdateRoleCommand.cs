using MediatR;

namespace Bank.Application.Features.Commands.Roles.UpdateRole;

public class UpdateRoleCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}