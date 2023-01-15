using Bank.Application.Features.Queries.Transactions.GetAllTransactions;
using MediatR;

namespace Bank.Application.Features.Queries.Transactions.GetAllTransactionBySenderUserId;

public class GetAllTransactionBySenderUserIdQuery:IRequest<List<TransactionListDto>>
{
    public Guid Id { get; set; }
}