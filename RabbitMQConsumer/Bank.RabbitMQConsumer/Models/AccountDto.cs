namespace Bank.RabbitMQConsumer.Models;

public class AccountDto
{
    public Guid Id { get; set; }
    public string AccountNo { get; set; }
    public decimal Balance { get; set; }
    public DateTime LastActivty { get; set; }
    public bool IsBlocked { get; set; }
    public Guid UserId { get; set; }
}