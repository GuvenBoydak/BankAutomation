using AutoMapper;
using Bank.Application.Interfaces.Repositories;
using Bank.Application.Interfaces.UnitOfWork;
using Bank.Domain.Models;
using MediatR;

namespace Bank.Application.Features.Commands.Roles.CreateRole;

public class CreateRoleCommandHandler : AsyncRequestHandler<CreateRoleCommand>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateRoleCommandHandler(IRoleRepository roleRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    protected override async Task Handle(CreateRoleCommand request, CancellationToken cancellationToken)
    {
        var role = _mapper.Map<CreateRoleCommand, Role>(request);

        await _roleRepository.AddAsync(role);
        await _unitOfWork.SaveChangesAsync();
    }
}