using Bank.Application.Interfaces.Repositories;
using Bank.Domain.Models;
using Bank.Persistence.Context;

namespace Bank.Persistence.Repositories;

public class TransactionRepository:GenericRepository<Transaction>,ITransactionRepository
{
    public TransactionRepository(BankDbContext db) : base(db)
    {
    }
}