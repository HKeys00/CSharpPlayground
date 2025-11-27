using Async;

Console.WriteLine("=== Starting ===");

// Simulate two events triggering around the same time

var task1 = SyncVsAsync.HandleRequestAsync("A");
await task1;

while (true)
{

}
Console.WriteLine("=== Done ===");