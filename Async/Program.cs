using Async;
using BenchmarkDotNet.Running;

Console.WriteLine("=== Starting ===");

// Simulate two events triggering around the same time

var task1 = SyncVsAsync.HandleRequestAsync("A");
var task2 = SyncVsAsync.HandleRequestAsync("B");

await task1;
await task2;


var summary = BenchmarkRunner.Run<Benchmark>();

Console.WriteLine("=== Done ===");