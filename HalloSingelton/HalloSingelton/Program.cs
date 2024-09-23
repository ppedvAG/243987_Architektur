using HalloSingelton;

Console.WriteLine("Hello, World!");


//for (int i = 0; i < 10_000_000; i++)
Parallel.For(0, 10, i =>
{
    Logger.Instance.LogInfo($"Hello Logger {i}");
});



