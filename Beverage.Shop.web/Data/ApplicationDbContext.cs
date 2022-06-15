using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.entites;

namespace Beverage.Shop.web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<FruitAndSpice> FruitsAndSpices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}