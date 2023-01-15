using Bank.Application.Features.Queries.Transactions.GetAllTransactions;
using MediatR;

namespace Bank.Application.Features.Queries.Transactions.GetAllTransactionBySenderAccountId;

public class GetAllTransactionBySenderAccountIdQuery:IRequest<List<TransactionListDto>>
{
    public Guid SenderAccountId { get; set; }
}