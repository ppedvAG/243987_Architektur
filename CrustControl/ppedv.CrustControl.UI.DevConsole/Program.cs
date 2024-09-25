using Autofac;
using ppedv.CrustControl.Data.Db;
using ppedv.CrustControl.Logic;
using ppedv.CrustControl.Model.Contracts;
using ppedv.CrustControl.Model.DomainModel;
using System.Reflection;

Console.WriteLine("*** Crust Control v0.1 ***");

string conString = "Server=(localdb)\\mssqllocaldb;Database=CrustControl_TestDb;Trusted_Connection=true";



//manual DI
//IRepository repo = new EfContextRepositoryAdapter(conString);

//DI per Reflection
//var pathToRepo = @"C:\Users\Fred\source\repos\ppedvAG\243987_Architektur\CrustControl\ppedv.CrustControl.Data.Db\bin\Debug\net8.0\ppedv.CrustControl.Data.Db.dll";
//var ass = Assembly.LoadFrom(pathToRepo);
//var typeMitRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IRepository)));
//var repo = Activator.CreateInstance(typeMitRepo,conString) as IRepository;

//DI per AutoFac
var builder = new ContainerBuilder();
builder.RegisterType<PizzaService>();
builder.Register(x => new EfContextRepositoryAdapter(conString)).As<IRepository>();
var container = builder.Build();

var repo = container.Resolve<IRepository>();
//PizzaService ps = new PizzaService(repo);
PizzaService ps = container.Resolve<PizzaService>();

foreach (var item in repo.GetAll<Pizza>())
{
    Console.WriteLine($"{item.Name} {item.Price}");
}

var mostOrdered = ps.GetMostOrderdPizzaOfMonth(DateTime.Now.Month);
Console.WriteLine($"Most ordered: {mostOrdered.Name}");