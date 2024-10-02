using Moq;
using ppedv.CrustControl.Model.Contracts.Data;
using ppedv.CrustControl.Model.DomainModel;

namespace ppedv.CrustControl.Logic.Tests
{
    public class PizzaServiceTests
    {
        [Fact]
        public void GetMostOrderdPizzaOfMonth_3_Pizzas_Salami_was_most_ordered()
        {
            var ps = new PizzaService(new TestUnitOfWork());

            var result = ps.GetMostOrderdPizzaOfMonth(9);

            Assert.Equal("Salami", result.Name);
        }

        [Fact]
        public void GetMostOrderdPizzaOfMonth_3_Pizzas_Salami_was_most_ordered_moq()
        {
            var orderRepoMock = new Mock<IRepository<Order>>();
            orderRepoMock.Setup(x => x.Query()).Returns(() =>
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

                return new List<Order> { order1, order2, order3 }.AsQueryable();
            });

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.OrderRepo).Returns(orderRepoMock.Object);

            var ps = new PizzaService(uowMock.Object);

            var result = ps.GetMostOrderdPizzaOfMonth(9);

            Assert.Equal("Salami", result.Name);

            orderRepoMock.Verify(x => x.Query(), Times.Exactly(1));
        }
    }

    class TestUnitOfWork : IUnitOfWork
    {
        public IRepository<Pizza> PizzaRepo => throw new NotImplementedException();
        public IRepository<Order> OrderRepo => new OrderRepo();
        public ICustomerRepository CustomerRepo => throw new NotImplementedException();
        public IRepository<Topping> ToppingRepo => throw new NotImplementedException();
        public int SaveAll()
        {
            throw new NotImplementedException();
        }
    }

    class OrderRepo : IRepository<Order>
    {

        public void Add(Order item)
        {
            throw new NotImplementedException();
        }


        public void Delete(Order item)
        {
            throw new NotImplementedException();
        }


        public void Update(Order item)
        {
            throw new NotImplementedException();
        }

        Order? IRepository<Order>.GetById(int id)
        {
            throw new NotImplementedException();
        }

        IQueryable<Order> IRepository<Order>.Query()
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

            return new List<Order> { order1, order2, order3 }.AsQueryable();
        }
    }


}
