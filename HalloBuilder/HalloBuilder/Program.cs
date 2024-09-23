using HalloBuilder;

Console.WriteLine("Hello, World!");
var schrank1 = new Schrank.Builder().SetTüren(2).SetOberfläche(Oberfläche.Lackiert).SetFarbe("Grün").Build();
var schrank2 = new Schrank.Builder().SetTüren(2).SetFarbe("Blau").Build();
Console.ReadLine();