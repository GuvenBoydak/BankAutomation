using MediatR;

namespace Bank.Application.Features.Commands.Transactions.CreateTransaction;

public class CreateTransactionCommand : IRequest
{
    public string SenderAccontNo { get; set; }
    public string RecipientAccoundNo { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public Guid SenderAccountId { get; set; }
    public Guid RecipientAccountId { get; set; }
    public Guid SenderUserId { get; set; }
    public Guid RecipientrUserId { get; set; }
}