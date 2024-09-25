using Microsoft.EntityFrameworkCore;
using ppedv.CrustControl.Model.DomainModel;

namespace ppedv.CrustControl.Data.Db
{
    public class EfContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Food> Foods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Topping> Toppings { get; set; }

        string conString;

        public EfContext(string conString)
        {
            this.conString = conString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString).UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasMany(x => x.BillingOrder).WithOne(x => x.Billing);
            modelBuilder.Entity<Order>().HasOne(x => x.Delivery).WithMany(x => x.DeliveryOrder);

            //https://learn.microsoft.com/en-us/ef/core/modeling/inheritance
            modelBuilder.Entity<Food>().UseTptMappingStrategy();

        }
    }
}
