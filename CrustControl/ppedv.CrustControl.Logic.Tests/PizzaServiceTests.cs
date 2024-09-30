using Moq;
using ppedv.CrustControl.Model.Contracts;
using ppedv.CrustControl.Model.DomainModel;

namespace ppedv.CrustControl.Logic.Tests
{
    public class PizzaServiceTests
    {
        [Fact]
        public void GetMostOrderdPizzaOfMonth_3_Pizzas_Salami_was_most_ordered()
        {
            var ps = new PizzaService(new TestRepo());

            var result = ps.GetMostOrderdPizzaOfMonth(9);

            Assert.Equal("Salami", result.Name);
        }

        [Fact]
        public void GetMostOrderdPizzaOfMonth_3_Pizzas_Salami_was_most_ordered_moq()
        {
            var mock = new Mock<IRepository>();
            mock.Setup(x => x.Query<Order>()).Returns(() => {
                var order1 = new Order { Date = new DateTime(2024, 09, 01), Billing = new Customer { Name = "Fred" } };
                var order2 = new Order { Date = new DateTime(2024, 09, 01), Billing = new Customer { Name = "Fred" } };
                var order3 = new Order { Date = new DateTime(2024, 09, 01), Billing = new Customer { Name = "Fred" } };

                var p1 = new Pizza { Name = "Margherita" };
                p1.OrderItems.Add(new OrderItem { FoodItem = p1, Order = order1 });

                var p2 = new Pizza { Name = "Salami" };
                p2.OrderItems.Add(new OrderItem { FoodItem = p2, Order = order1 });
                p2.OrderItems.Add(new OrderItem { FoodItem = p2, Order = order1 });
                p2.OrderItems.Add(new OrderItem { FoodItem = p2, Order = order1 });

                var p3 = new Pizza { Name = "Hawai" };
                p3.OrderItems.Add(new OrderItem { FoodItem = p3, Order = order1 });
                p3.OrderItems.Add(new OrderItem { FoodItem = p3, Order = order1 });

                order1.Items = new List<OrderItem> { p1.OrderItems.First(), p2.OrderItems.First(), p3.OrderItems.First() };
                order2.Items = new List<OrderItem> { p2.OrderItems.Skip(1).First(), p3.OrderItems.Skip(1).First() };
                order3.Items = new List<OrderItem> { p2.OrderItems.Last() };

                return new List<Order> { order1, order2, order3 }.AsQueryable();
            });
            var ps = new PizzaService(mock.Object);

            var result = ps.GetMostOrderdPizzaOfMonth(9);

            Assert.Equal("Salami", result.Name);

            mock.Verify(x => x.Query<Order>(), Times.Exactly(1));
        }
    }

    class TestRepo : IRepository
    {
        public void Add<T>(T item) where T : Entity
        {
            throw new NotImplementedException();
        }

        public void Delete<T>(T item) where T : Entity
        {
            throw new NotImplementedException();
        }

        public T? GetById<T>(int id) where T : Entity
        {
            throw new NotImplementedException();
        }

        public IQueryable<T> Query<T>() where T : Entity
        {
            if (typeof(T) == typeof(Order))
            {
                var order1 = new Order { Date = new DateTime(2024, 09, 01), Billing = new Customer { Name = "Fred" } };
                var order2 = new Order { Date = new DateTime(2024, 09, 01), Billing = new Customer { Name = "Fred" } };
                var order3 = new Order { Date = new DateTime(2024, 09, 01), Billing = new Customer { Name = "Fred" } };

                var p1 = new Pizza { Name = "Margherita" };
                p1.OrderItems.Add(new OrderItem { FoodItem = p1, Order = order1 });

                var p2 = new Pizza { Name = "Salami" };
                p2.OrderItems.Add(new OrderItem { FoodItem = p2, Order = order1 });
                p2.OrderItems.Add(new OrderItem { FoodItem = p2, Order = order1 });
                p2.OrderItems.Add(new OrderItem { FoodItem = p2, Order = order1 });

                var p3 = new Pizza { Name = "Hawai" };
                p3.OrderItems.Add(new OrderItem { FoodItem = p3, Order = order1 });
                p3.OrderItems.Add(new OrderItem { FoodItem = p3, Order = order1 });

                order1.Items = new List<OrderItem> { p1.OrderItems.First(), p2.OrderItems.First(), p3.OrderItems.First() };
                order2.Items = new List<OrderItem> { p2.OrderItems.Skip(1).First(), p3.OrderItems.Skip(1).First() };
                order3.Items = new List<OrderItem> { p2.OrderItems.Last() };

                return new List<Order> { order1, order2, order3 }.AsQueryable().Cast<T>();
            }

            throw new NotImplementedException();
        }

        public int SaveAll()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T item) where T : Entity
        {
            throw new NotImplementedException();
        }
    }
}
