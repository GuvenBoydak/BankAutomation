using Bank.Application.Interfaces.Repositories;
using Bank.Application.Interfaces.UnitOfWork;
using MediatR;

namespace Bank.Application.Features.Commands.Roles.DeleteRole;

public class DeleteRoleCommandHandler : AsyncRequestHandler<DeleteRoleCommand>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;

    public DeleteRoleCommandHandler(IUnitOfWork unitOfWork, IRoleRepository roleRepository)
    {
        _unitOfWork = unitOfWork;
        _roleRepository = roleRepository;
    }

    protected override async Task Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        await _roleRepository.DeleteAsync(request.Id);
        await _unitOfWork.SaveChangesAsync();
    }
}