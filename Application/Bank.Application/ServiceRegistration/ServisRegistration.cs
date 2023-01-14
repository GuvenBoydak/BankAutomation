using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Bank.Application.ServiceRegistration;

public static class ServisRegistration
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ServisRegistration));
    }
}