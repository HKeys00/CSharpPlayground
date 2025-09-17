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
    }
}
