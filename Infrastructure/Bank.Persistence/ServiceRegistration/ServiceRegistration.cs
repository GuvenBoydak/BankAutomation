using Bank.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Persistence.ServiceRegistration;

public static class ServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection service)
    {
        service.AddDbContext<BankDbContext>(opt => opt.UseSqlServer(Configuration.ConnectionString));

        return service;
    }
}