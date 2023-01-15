using MediatR;

namespace Bank.Application.Features.Queries.Transactions.GetAllTransactions;

public class GetAllTransactionQuery:IRequest<List<TransactionListDto>>
{
}