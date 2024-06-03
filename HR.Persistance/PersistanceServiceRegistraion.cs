using HR.Application.Persistance.Contracts;
using HR.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.Persistance
{
    public static class PersistanceServiceRegistraion
    {
        public static IServiceCollection ConfigurePersistanceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LeaveManagmentDBContext>(cfg =>
            cfg.UseSqlServer(configuration.GetConnectionString("ConnectionString")));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
            services.AddScoped<ILeaveAllocationRepositroy, LeaveAllocationRepository>();

            return services;

        }
    }
}
