using System.Reflection;
using Core.Entities;
using Infra.Data.Config;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class StoreContext : DbContext
    {

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductBrand> ProductBrands { get; set; }
        public DbSet<ProductType> ProductTypes { get; set; }
        public StoreContext( DbContextOptions<StoreContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly()) ;
        }
    }
}