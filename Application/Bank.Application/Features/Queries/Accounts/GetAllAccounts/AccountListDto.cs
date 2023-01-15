namespace Bank.Application.Features.Queries.Accounts.GetAllAccounts;

public class AccountListDto
{
    public Guid Id { get; set; }
    public string AccountNo { get; set; }
    public decimal Balance { get; set; }
    public DateTime LastActivty { get; set; }
    public bool IsBlocked { get; set; }
    public Guid UserId { get; set; }
}