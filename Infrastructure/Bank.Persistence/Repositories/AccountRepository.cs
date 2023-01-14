using Bank.Application.Interfaces.Repositories;
using Bank.Domain.Models;
using Bank.Persistence.Context;

namespace Bank.Persistence.Repositories;

public class AccountRepository:GenericRepository<Account>,IAccountRepository
{
    public AccountRepository(BankDbContext db) : base(db)
    {
    }
}