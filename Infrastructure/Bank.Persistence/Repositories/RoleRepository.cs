using Bank.Application.Interfaces.Repositories;
using Bank.Domain.Models;
using Bank.Persistence.Context;

namespace Bank.Persistence.Repositories;

public class RoleRepository:GenericRepository<Role>,IRoleRepository
{
    public RoleRepository(BankDbContext db) : base(db)
    {
    }
}