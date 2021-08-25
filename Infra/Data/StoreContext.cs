using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data
{
    public class StoreContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public StoreContext( DbContextOptions<StoreContext> options) : base(options)
        {
        }
    }
}