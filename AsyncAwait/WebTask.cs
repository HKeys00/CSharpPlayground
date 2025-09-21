using System.Diagnostics;
using System.Security.Policy;

namespace AsyncAwait
{
    internal class WebTask
    {
        public static async void PerformComplicatedTaskAsync(object sender, EventArgs e)
        {
            Debug.WriteLine("PERFORMING TASK");
            await Task.Delay(1000);
            Debug.WriteLine("DONE");
        }

        public static void PerformComplicatedTaskSync(object sender, EventArgs e)
        {
            Debug.WriteLine("PERFORMING TASK");
            Task.Delay(1000).Wait();
            Debug.WriteLine("DONE");
        }

        public static async Task<string> ReturnStringAsync()
        {
            Debug.WriteLine("RETURNING STRING");
            await Task.Delay(1000);
            Debug.WriteLine("DONE");

            return "STRING RETURNED";
        }

        public static void ReturnString(Action<string> action)
        {
            ///PERFORM TASK
            action.Invoke("DONE");
        }

        public static async Task DemoCompletedAsync()
        {
            Debug.WriteLine("Before first await");
            await Task.FromResult(100);
            Debug.WriteLine("Between awaits");
            await Task.Delay(1000);
            Debug.WriteLine("After second await");
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
