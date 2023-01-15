using AutoMapper;
using Bank.Application.Interfaces.Repositories;
using Bank.Application.Interfaces.UnitOfWork;
using Bank.Domain.Models;
using MediatR;

namespace Bank.Application.Features.Commands.Accounts.UpdateAccount;

public class UpdateAccountCommandHandler : AsyncRequestHandler<UpdateAccountCommand>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateAccountCommandHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    protected override async Task Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = _mapper.Map<UpdateAccountCommand, Account>(request);

        _accountRepository.Update(account);
        await _unitOfWork.SaveChangesAsync();
    }
}