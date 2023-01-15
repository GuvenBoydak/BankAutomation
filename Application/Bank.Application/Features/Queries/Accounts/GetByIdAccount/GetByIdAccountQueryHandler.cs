using AutoMapper;
using Bank.Application.Interfaces.Repositories;
using Bank.Domain.Models;
using MediatR;

namespace Bank.Application.Features.Queries.Accounts.GetByIdAccount;

public class GetByIdAccountQueryHandler : IRequestHandler<GetByIdAccountQuery, AccountDto>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public GetByIdAccountQueryHandler(IMapper mapper, IAccountRepository accountRepository)
    {
        _mapper = mapper;
        _accountRepository = accountRepository;
    }

    public async Task<AccountDto> Handle(GetByIdAccountQuery request, CancellationToken cancellationToken)
    {
        var account = await _accountRepository.GetById(request.Id);

        return _mapper.Map<Account, AccountDto>(account);
    }
}