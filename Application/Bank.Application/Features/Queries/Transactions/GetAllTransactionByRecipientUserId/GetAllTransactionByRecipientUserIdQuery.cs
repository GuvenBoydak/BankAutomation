using Bank.Application.Features.Queries.Transactions.GetAllTransactions;
using MediatR;

namespace Bank.Application.Features.Queries.Transactions.GetAllTransactionByRecipientUserId;

public class GetAllTransactionByRecipientUserIdQuery : IRequest<List<TransactionListDto>>
{
    public Guid Id { get; set; }
}