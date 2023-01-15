using Bank.Application.Features.Queries.Accounts.GetByIdAccount;
using MediatR;

namespace Bank.Application.Features.Queries.Transactions.GetByIdTransaction;

public class GetByIdTransactionQuery : IRequest<TransactionDto>
{
    public Guid Id { get; set; }
}