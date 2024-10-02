using ppedv.CrustControl.Data.Db;
using ppedv.CrustControl.Logic;
using ppedv.CrustControl.Model.Contracts.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string conString = "Server=(localdb)\\mssqllocaldb;Database=CrustControl_TestDb;Trusted_Connection=true";

builder.Services.AddSingleton<PizzaService>();
builder.Services.AddTransient<IRepository>(x => new EfContextRepositoryAdapter(conString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
