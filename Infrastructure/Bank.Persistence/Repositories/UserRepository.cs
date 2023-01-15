using Bank.Application.Interfaces.Repositories;
using Bank.Domain.Models;
using Bank.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Bank.Persistence.Repositories;

public class UserRepository:GenericRepository<User>,IUserRepository
{
    public UserRepository(BankDbContext db) : base(db)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await Table.FirstOrDefaultAsync(x => x.Email == email);
    }
}