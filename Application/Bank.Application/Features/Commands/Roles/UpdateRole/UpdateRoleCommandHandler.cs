using AutoMapper;
using Bank.Application.Interfaces.Repositories;
using Bank.Application.Interfaces.UnitOfWork;
using Bank.Domain.Models;
using MediatR;

namespace Bank.Application.Features.Commands.Roles.UpdateRole;

public class UpdateRoleCommandHandler : AsyncRequestHandler<UpdateRoleCommand>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    protected override async Task Handle(UpdateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = _mapper.Map<UpdateRoleCommand, Role>(request);

        _roleRepository.Update(role);
        await _unitOfWork.SaveChangesAsync();
    }
}