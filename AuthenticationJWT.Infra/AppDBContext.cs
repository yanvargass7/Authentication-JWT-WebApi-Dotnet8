using AuthenticationJWT.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AuthenticationJWT.Infra
{
    public class AppDBContext : DbContext
    {
        public AppDBContext() { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
                optionsBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"), optionsBuilder => optionsBuilder.EnableRetryOnFailure());
            }
        }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
        public DbSet<User> User { get; set; }
    }
}