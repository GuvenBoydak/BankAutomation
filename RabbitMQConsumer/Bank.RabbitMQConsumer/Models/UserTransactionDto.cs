namespace Bank.RabbitMQConsumer.Models;

public class UserTransactionDto
{
    public UserDto User { get; set; }
    public TransactionDto Transaction { get; set; }
    public AccountDto Account { get; set; }
}