using Bank.Application.Interfaces.UnitOfWork;
using Bank.Persistence.Context;

namespace Bank.Persistence.UnitOfWork;

public class UnitOfWork:IUnitOfWork
{
    private readonly BankDbContext _db;

    public UnitOfWork(BankDbContext db)
    {
        _db = db;
    }

    public async Task SaveChangesAsync()
    {
        await _db.SaveChangesAsync();
        await _db.SaveChangesAsync();
    }
}