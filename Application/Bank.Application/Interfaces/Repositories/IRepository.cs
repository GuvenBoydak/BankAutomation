using System.Linq.Expressions;
using Bank.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Bank.Application.Interfaces.Repositories;

public interface IRepository<T> where  T :BaseEntity
{
    DbSet<T> Table { get; }

    Task<T> GetById(Guid id);
    
    IQueryable<T> Where(Expression<Func<T,bool>> filter);

    Task<List<T>> GetAllAsync();

    Task AddAsync(T entity);

    Task DeleteAsync(Guid id);

    void Update(T entity);
}