using Async;

Console.WriteLine("=== Starting ===");

// Simulate two events triggering around the same time
await SyncVsAsync.HandleRequestAsync("A").ConfigureAwait(false);
await SyncVsAsync.HandleRequestAsync("B");

//await Task.WhenAll(t1, t2);

Console.WriteLine("=== Done ===");