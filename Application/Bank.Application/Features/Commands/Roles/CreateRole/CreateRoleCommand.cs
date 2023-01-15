using MediatR;

namespace Bank.Application.Features.Commands.Roles.CreateRole;

public class CreateRoleCommand : IRequest
{
    public string Name { get; set; }
}