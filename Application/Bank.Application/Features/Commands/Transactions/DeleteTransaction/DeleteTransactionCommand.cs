using MediatR;

namespace Bank.Application.Features.Commands.Transactions.DeleteTransaction;

public class DeleteTransactionCommand:IRequest
{
    public Guid Id { get; set; }
}