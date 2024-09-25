using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using ppedv.CrustControl.Model.DomainModel;
using System.Reflection;

namespace ppedv.CrustControl.Data.Db.Tests
{
    public class EfContextTests
    {
        string conString = "Server=(localdb)\\mssqllocaldb;Database=CrustControl_TestDb;Trusted_Connection=true";

        [Fact]
        public void Can_create_db()
        {
            var con = new EfContext(conString);
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        public void Can_add_Pizza()
        {
            var pizza = new Pizza { Name = "TestPizza", Price = 12.34m };
            var con = new EfContext(conString);
            con.Database.EnsureCreated();

            con.Pizzas.Add(pizza);
            var row = con.SaveChanges();

            Assert.Equal(2, row);
        }

        [Fact]
        public void Can_read_Pizza()
        {
            var pizza = new Pizza { Name = $"Pizza_{Guid.NewGuid()}", Price = 13.33m };
            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Pizzas.Add(pizza);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Pizzas.Find(pizza.Id);

                Assert.NotNull(loaded);
                Assert.Equal(pizza.Name, loaded.Name);
            }
        }

        [Fact]
        public void Can_update_Pizza()
        {
            var pizza = new Pizza { Name = $"Pizza_{Guid.NewGuid()}", Price = 14.44m };
            var newName = $"NewPizza_{Guid.NewGuid()}";
            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Pizzas.Add(pizza);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Pizzas.Find(pizza.Id);
                loaded!.Name = newName;
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Pizzas.Find(pizza.Id);
                Assert.Equal(newName, loaded!.Name);
            }
        }

        [Fact]
        public void Can_delete_Pizza()
        {
            var pizza = new Pizza { Name = $"Pizza_{Guid.NewGuid()}", Price = 15.55m };

            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Pizzas.Add(pizza);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Pizzas.Find(pizza.Id);
                con.Pizzas.Remove(loaded!);
                var rows = con.SaveChanges();
                Assert.Equal(2, rows);
            }

            using (var con = new EfContext(conString))
            {
                var loaded = con.Pizzas.Find(pizza.Id);
                Assert.Null(loaded);
            }
        }

        [Fact]
        public void Can_add_Pizza_with_AutoFix()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new TypeRelay(typeof(Food), typeof(Pizza)));
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id)));

            var pizza = fix.Create<Pizza>();

            using (var con = new EfContext(conString))
            {
                con.Database.EnsureCreated();
                con.Pizzas.Add(pizza);
                con.SaveChanges();
            }

            using (var con = new EfContext(conString))
            {
                //var loaded = con.Pizzas.Find(pizza.Id); //LazyLoading aktiviert 

                var query = con.Pizzas.Where(x => x.Id == pizza.Id); //eager loading
                query = query.Include(x => x.Toppings);
                query = query.Include(x => x.OrderItems).ThenInclude(x => x.Order).ThenInclude(x => x.Billing);
                query = query.Include(x => x.OrderItems).ThenInclude(x => x.Order).ThenInclude(x => x.Delivery);
                var loaded = query.FirstOrDefault();    


                loaded.Should().BeEquivalentTo(pizza, x => x.IgnoringCyclicReferences());
            }
        }

        internal class PropertyNameOmitter : ISpecimenBuilder
        {
            private readonly IEnumerable<string> names;

            internal PropertyNameOmitter(params string[] names)
            {
                this.names = names;
            }

            public object Create(object request, ISpecimenContext context)
            {
                var propInfo = request as PropertyInfo;
                if (propInfo != null && names.Contains(propInfo.Name))
                    return new OmitSpecimen();

                return new NoSpecimen();
            }
        }

    }
}
