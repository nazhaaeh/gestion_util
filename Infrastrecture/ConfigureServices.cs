
using Infrastrecture.Interfaces;
using Infrastrecture.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastrecture;

public static class ConfigureServices
{
    public static IServiceCollection AddinfrastrectureSevices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DBcontexAppt>(option => option.UseSqlServer(configuration.GetConnectionString("coxString")));

        services.AddScoped < IUserRepository,UserRepository> ();
 





        return services;
    }
}
