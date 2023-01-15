using AutoMapper;
using Bank.Application.Interfaces.Repositories;
using Bank.Domain.Models;
using MediatR;

namespace Bank.Application.Features.Queries.Accounts.GetAllAccounts;

public class GetAllAccountQueryHandler : IRequestHandler<GetAllAccountQuery, List<AccountListDto>>
{
    private readonly IAccountRepository _accountRepository;
    private readonly IMapper _mapper;

    public GetAllAccountQueryHandler(IAccountRepository accountRepository, IMapper mapper)
    {
        _accountRepository = accountRepository;
        _mapper = mapper;
    }

    public async Task<List<AccountListDto>> Handle(GetAllAccountQuery request, CancellationToken cancellationToken)
    {
        var accounts = await _accountRepository.GetAllAsync();

        return _mapper.Map<List<Account>, List<AccountListDto>>(accounts);
    }
}