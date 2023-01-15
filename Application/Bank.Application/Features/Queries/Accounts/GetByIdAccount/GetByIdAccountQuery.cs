using MediatR;

namespace Bank.Application.Features.Queries.Accounts.GetByIdAccount;

public class GetByIdAccountQuery:IRequest<AccountDto>
{
    public Guid Id { get; set; }
}