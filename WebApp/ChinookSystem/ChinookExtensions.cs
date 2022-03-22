using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ChinookSystem.DAL;
#endregion

namespace ChinookSystem.BLL
{
    public static class ChinookExtensions
    {

        public static void ChinookSystemBackendDependencies(this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            //register the DbContext class in Chinook iwth the service collection
            services.AddDbContext<Chinook2018Context>(options);

            //add any services that you create iun the class library
            //using .AddTransient<T>(...)
            services.AddTransient<AboutServices>((serviceProvider) =>
            {
                var context = serviceProvider.GetRequiredService<Chinook2018Context>();
                //create an instance of the service and return the instance
                return new AboutServices(context);

            });
        }

    }
}
