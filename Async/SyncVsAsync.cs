namespace Async
{
    internal static class SyncVsAsync
    {
        public static bool Busy = false;

        public static async Task<int> SynchronouslyCompletingTask(bool completeSync)
        {
            if (completeSync)
            {
                return 0;
            }

            await Task.Delay(1000); //Perform work.
            return 1;
        }

        public static async Task<int> AsyncCompletingTask()
        {
            await Task.Delay(1000);
            return 0;
        }

        public static async Task HandleRequestAsync(string name)
        {
            Console.WriteLine($"{name}: Entering");

            //await Task.Delay(1000);

            if (Busy)
            {
                Console.WriteLine($"{name}: ERROR — reentered while busy!");
                return;
            }

            Busy = true;   // Expect Busy to remain true until AFTER await

            Console.WriteLine($"{name}: await hit on {Environment.CurrentManagedThreadId}, returning and scheduling continuation");
            await SynchronouslyCompletingTask(false);

            Console.WriteLine($"{name}: Continuation run on {Environment.CurrentManagedThreadId}");

            Busy = false;

            Console.WriteLine($"{name}: Leaving");
        }

        static async Task PrintAndWait(TimeSpan delay)
        {
            var task1 = Task.Delay(2000);
            var task2 = Task.Delay(2000);

            await Task.WhenAll(task1, task2);
        }
    }
}
