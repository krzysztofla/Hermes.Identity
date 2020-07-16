using Hermes.Identity.DbConfiguration;
using Hermes.Identity.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Hermes.Identity.WebApi.DbConfiguration
{
    public class SqlAzConnectionContext : DbContext, ISqlAzConnectionContext
    {
        public DbSet<User> Users { get; set; }

        public SqlAzConnectionContext(DbContextOptions<SqlAzConnectionContext> options)
            : base(options)
        { 

        }

        public void GetConnection() => new DbContextOptionsBuilder<SqlAzConnectionContext>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}