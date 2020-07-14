using Hermes.Identity.Models;
using Microsoft.EntityFrameworkCore;

namespace Hermes.Identity.WebApi.DbConfiguration
{
    public class SqlAzConnectionContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public SqlAzConnectionContext(DbContextOptions<SqlAzConnectionContext> options)
            : base(options)
        { 

        }

        public void GetConnection() => new DbContextOptionsBuilder<SqlAzConnectionContext>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:hermes-identity.database.windows.net,1433;Initial Catalog=HermesIdentityDb;Persist Security Info=False;User ID=hermes;Password=Admin1234;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}