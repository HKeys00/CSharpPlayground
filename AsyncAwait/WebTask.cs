using System.Security.Policy;

namespace AsyncAwait
{
    internal class WebTask
    {
        public static async Task PerformComplicatedTaskAsync()
        {
            Console.WriteLine("PERFORMING TASK");
            await Task.Delay(1000);
            Console.WriteLine("DONE");
        }

        public static void PerformComplicatedTaskSync()
        {
            Console.WriteLine("PERFORMING TASK");
            Task.Delay(1000).Wait();
            Console.WriteLine("DONE");
        }

        public static async Task<string> ReturnStringAsync()
        {
            Console.WriteLine("RETURNING STRING");
            await Task.Delay(1000);
            Console.WriteLine("DONE");

            return "STRING RETURNED";
        }

        public static void ReturnString(Action<string> action)
        {
            ///PERFORM TASK
            action.Invoke("DONE");
        }

        public static async Task DemoCompletedAsync()
        {
            Console.WriteLine("Before first await");
            await Task.FromResult(10);
            Console.WriteLine("Between awaits");
            await Task.Delay(1000);
            Console.WriteLine("After second await");
        }

        public static async Task ThrowError()
        {
            await Task.Delay(1000);
            throw new Exception();
        }

        public static async Task CancelTask(CancellationToken token)
        {
            await Task.Delay(50000, token);
        }
    }
}
