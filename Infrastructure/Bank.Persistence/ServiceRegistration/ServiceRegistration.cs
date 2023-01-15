using Bank.Application.Interfaces.Repositories;
using Bank.Application.Interfaces.UnitOfWork;
using Bank.Persistence.Context;
using Bank.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Persistence.ServiceRegistration;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection service)
    {
        service.AddDbContext<BankDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));

        service.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
        service.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        service.AddScoped<IUserRepository, UserRepository>();
        service.AddScoped<IAccountRepository, AccountRepository>();
        service.AddScoped<IRoleRepository, RoleRepository>();
        service.AddScoped<ITransactionRepository, TransactionRepository>();
        
        return service;
    }
}