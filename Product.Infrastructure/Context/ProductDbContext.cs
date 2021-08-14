using Microsoft.EntityFrameworkCore;
using Product.Core.Entities;
using Product.Infrastructure.Persistance.Configuration;
using System.Reflection;

namespace Product.Infrastructure.Context
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<ProductModel> Product { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
