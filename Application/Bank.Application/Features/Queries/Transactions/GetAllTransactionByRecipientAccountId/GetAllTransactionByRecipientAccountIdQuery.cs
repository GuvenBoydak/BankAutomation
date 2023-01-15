using Bank.Application.Features.Queries.Transactions.GetAllTransactions;
using MediatR;

namespace Bank.Application.Features.Queries.Transactions.GetAllTransactionByRecipientAccountId;

public class GetAllTransactionByRecipientAccountIdQuery : IRequest<List<TransactionListDto>>
{
    public Guid RecipientAccountId { get; set; }
}