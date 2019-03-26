using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Motorista.Infra.Data.Context
{
    public class MotoristaDbContextFactory : IDesignTimeDbContextFactory<MotoristaContext>
    {
        public MotoristaContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MotoristaContext>();
            IConfigurationRoot configuration = new ConfigurationBuilder()
              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
              .AddJsonFile(@"appsettings.json")
              .Build();

            builder.UseSqlServer(configuration.GetConnectionString("MotoristaConnectionString"));
            return new MotoristaContext(builder.Options);
        }
    }
}
