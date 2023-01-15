using Bank.Application.Features.Queries.Accounts.GetByIdAccount;
using Bank.Application.Features.Queries.Transactions.GetByIdTransaction;
using Bank.Application.Features.Queries.Users.GetByIdUser;

namespace Bank.Application.DTOs;

public class UserTransactionDto
{
    public UserDto User { get; set; }
    public TransactionDto Transaction { get; set; }
    public AccountDto Account { get; set; }
}