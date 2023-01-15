using MediatR;

namespace Bank.Application.Features.Queries.Accounts.GetAllAccounts;

public class GetAllAccountQuery:IRequest<List<AccountListDto>>
{
    
}