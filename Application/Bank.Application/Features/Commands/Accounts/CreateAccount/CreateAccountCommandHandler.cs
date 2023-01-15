using System.Security.Claims;
using AutoMapper;
using Bank.Application.Interfaces.Repositories;
using Bank.Application.Interfaces.UnitOfWork;
using Bank.Domain.Models;
using MediatR;

namespace Bank.Application.Features.Commands.Accounts.CreateAccount;

public class CreateAccountCommandHandler : AsyncRequestHandler<CreateAccountCommand>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateAccountCommandHandler(IAccountRepository accountRepository, IUnitOfWork unitOfWork, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    protected override async Task Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var account = _mapper.Map<CreateAccountCommand, Account>(request);

        await _accountRepository.AddAsync(account);
        await _unitOfWork.SaveChangesAsync();
    }
}