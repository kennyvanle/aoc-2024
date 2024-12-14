using System.Diagnostics;
using System.Reflection;
using Common;
using Microsoft.Extensions.DependencyInjection;

var serviceCollection = new ServiceCollection();
var solverType = typeof(ISolver);
var assembly = Assembly.Load("AoC2024");

var solverImplementations = assembly.GetTypes().Where(t => solverType.IsAssignableFrom(t));

foreach (var implementation in solverImplementations)
{
    serviceCollection.AddTransient(solverType, implementation);
}

serviceCollection.AddTransient<CompositeSolver>();

var serviceProvider = serviceCollection.BuildServiceProvider();
var compositeSolver = serviceProvider.GetService<CompositeSolver>() ?? new CompositeSolver([]);

Stopwatch stopwatch = new();
stopwatch.Start();

compositeSolver.Solve();

stopwatch.Stop();
var elapsedTime = stopwatch.Elapsed;
Console.WriteLine($"Total Execution Time: {elapsedTime}");