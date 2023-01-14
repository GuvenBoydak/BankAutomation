namespace Bank.Domain.Models;

public class Transaction : BaseEntity
{
    public string SenderAccontNo { get; set; }
    public string RecipientAccoundNo { get; set; }
    public decimal Amount { get; set; }
    public string? Description { get; set; }
    public Guid SenderAccountId { get; set; }
    public Guid RecipientAccountId { get; set; }
    public Guid SenderUserId { get; set; }
    public Guid RecipientrUserId { get; set; }

    //Relational property
    public User User { get; set; }
    public Account Account { get; set; }
}