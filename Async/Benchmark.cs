using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace Async
{
    [MemoryDiagnoser]
    public class Benchmark
    {

        public Benchmark()
        {        }
        
        [Benchmark]
        public async ValueTask ValueTaskCompleteMostOfTheTime()
        {
            for (int i = 0; i < 100_000; i++)
            {
                await FetchDataValueTask(i);
            }
        }
        [Benchmark]
        public async Task TaskCompleteMostOfTheTime()
        {
            for (int i = 0; i < 100_000; i++)
            {
                await FetchDataTask(i);
            }
        }

        private async ValueTask<int> FetchDataValueTask(int i)
        {
            if (i > 0) //Assume this is cache logic
            {
                return i;
            }

            await Task.Delay(100);
            return i;
        }
        private async Task<int> FetchDataTask(int i)
        {
            if (i > 0) //Assume this is cache logic
            {
                return i;
            }

            await Task.Delay(100);
            return i;
        }
    }
}
