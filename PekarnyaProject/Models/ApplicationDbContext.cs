using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PekarnyaProject.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Це твоя таблиця продуктів у базі

        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
    }
}