using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Client.Infrastructure.Context
{
    public class ClientDbContextFactory : IDesignTimeDbContextFactory<ClientDbContext>
    {
        public ClientDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<ClientDbContext>();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) 
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = config.GetConnectionString("ClientDatabase");

            builder.UseSqlServer(connectionString);

            return new ClientDbContext(builder.Options);
        }
    }
}
