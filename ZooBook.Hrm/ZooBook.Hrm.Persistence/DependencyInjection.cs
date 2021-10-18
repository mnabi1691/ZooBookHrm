using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;
using ZooBook.Hrm.Application.Interfaces;
using ZooBook.Hrm.Configuration;

namespace ZooBook.Hrm.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IHostEnvironment currentEnvironment)
        {
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ConnectionStrings connectionStrings =
               serviceProvider.GetService(typeof(ConnectionStrings))
               as ConnectionStrings;

            if (currentEnvironment.IsEnvironment("Test"))
            {
                services.AddDbContext<HrmDbContext>(options =>
                    options.UseInMemoryDatabase("EmployeeRecordsTestDb"));
            }
            else
            {
                services.AddDbContext<HrmDbContext>(options =>
             options.UseSqlServer(connectionStrings.DatabaseConnectionString));
            }

            services.AddScoped<IHrmDbContext>(provider => provider.GetService<HrmDbContext>());
            return services;
        }
    }
}
