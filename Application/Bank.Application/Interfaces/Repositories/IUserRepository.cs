using Bank.Domain.Models;

namespace Bank.Application.Interfaces.Repositories;

public interface IUserRepository:IRepository<User>
{
    Task<User?> GetByEmailAsync(string email);
}