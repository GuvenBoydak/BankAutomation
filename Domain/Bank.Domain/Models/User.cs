namespace Bank.Domain.Models;

public class User : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public byte[] PasswordHash { get; set; }
    public byte[] PasswordSalt { get; set; }
    public Guid RoleId { get; set; }

    //Relational property
    public Role Role { get; set; }
    public List<Account> Accounts { get; set; }
    public List<Transaction> Transactions { get; set; }
}