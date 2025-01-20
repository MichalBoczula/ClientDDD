using Client.Domian.RichDomainStyle.AggregatesModel.ClientAggregate;
using Client.Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Client.Infrastructure.Context
{
    public class ClientDbContext : DbContext
    {
        public DbSet<RichAddress> Clients => Set<RichAddress>();

        public ClientDbContext(DbContextOptions<ClientDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}