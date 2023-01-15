namespace Bank.Application.Features.Queries.Transactions.GetAllTransactions;

public class TransactionListDto
{
    public Guid Id { get; set; }
    public string SenderAccontNo { get; set; }
    public string RecipientAccoundNo { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public Guid SenderAccountId { get; set; }
    public Guid RecipientAccountId { get; set; }
    public Guid SenderUserId { get; set; }
    public Guid RecipientrUserId { get; set; }
}