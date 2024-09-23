// See https://aka.ms/new-console-template for more information
using DecoPattern;

Console.WriteLine("Hello, World!");


var brot = new Käse(new Salami(new Salami(new Brot())));


Console.WriteLine($"{brot.Name} {brot.Price}");

var json = System.Text.Json.JsonSerializer.Serialize(brot);
Console.WriteLine(json);