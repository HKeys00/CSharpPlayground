using Async;
using BenchmarkDotNet.Running;

Console.WriteLine("=== Starting ===");

// Simulate two events triggering around the same time

var task1 = SyncVsAsync.HandleRequestAsync("A");
var task2 = SyncVsAsync.HandleRequestAsync("B");

await task1;
await task2;

var m = ReferenceEquals(task1, task2);
var l = m;
//var summary = BenchmarkRunner.Run<Benchmark>();
Console.WriteLine(m);
await SyncVsAsync.AwaitHeavyWork();
Console.WriteLine("Between");
await SyncVsAsync.RunHeavyWork();


Console.ReadLine();