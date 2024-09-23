using System.Data.Common;

Console.WriteLine("Hello, World!");

string conStringSQL = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=true";
string conStringSQLITE = @"Data Source=C:\DB\Northwind.sqlite";

DbProviderFactory factory = null;
string conString = "";
if (DateTime.Now.DayOfWeek != DayOfWeek.Wednesday)
{
    factory = Microsoft.Data.SqlClient.SqlClientFactory.Instance;
    conString = conStringSQL;
}
else
{
    factory = Microsoft.Data.Sqlite.SqliteFactory.Instance;
    conString = conStringSQLITE;
}

DbConnection con = factory.CreateConnection();
con.ConnectionString = conString;
con.Open();
Console.WriteLine("Db open");

DbCommand cmd = factory.CreateCommand();
cmd.Connection = con;
cmd.CommandText = "SELECT COUNT(*) FROM Employees";

var rowCount = cmd.ExecuteScalar();

Console.WriteLine($"Employees: {rowCount}");