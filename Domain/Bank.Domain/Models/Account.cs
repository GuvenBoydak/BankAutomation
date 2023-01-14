namespace Bank.Domain.Models;

public class Account : BaseEntity
{
    public Account()
    {
        LastActivty = DateTime.Now;
    }

    public string AccountNo { get; set; }
    public decimal Balance { get; set; }
    public DateTime LastActivty { get; set; }
    public bool IsBlocked { get; set; }
    public Guid UserId { get; set; }

    //Relational property
    public User User { get; set; }

    public List<Transaction> Transactions { get; set; }
}