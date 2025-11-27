using Async;

Console.WriteLine("=== Starting ===");

// Simulate two events triggering around the same time

var task1 = SyncVsAsync.HandleRequestAsync("A");
SyncVsAsync.Busy = true;
var task2 = SyncVsAsync.HandleRequestAsync("B");
SyncVsAsync.Busy = false;
await task1;
await task2;

while (true)
{

}
Console.WriteLine("=== Done ===");