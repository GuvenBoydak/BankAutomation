using Bank.Application.Interfaces.Repositories;
using Bank.Domain.Models;
using Bank.Persistence.Context;

namespace Bank.Persistence.Repositories;

public class UserRepository:GenericRepository<User>,IUserRepository
{
    public UserRepository(BankDbContext db) : base(db)
    {
    }
}