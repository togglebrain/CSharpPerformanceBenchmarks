using BenchmarkDotNet.Attributes;

namespace PerformanceBenchmarks
{
    [MemoryDiagnoser]
    [MaxColumn, MinColumn]
    [Config(typeof(BenchmarkConfig))]
    public class ParallelForVsTaskBenchmark
    {
        private static readonly List<int> someNumbers = new List<int>();
        private static readonly int itemCount = 10000;

        [IterationCleanup]
        public void Cleanup()
        {
            someNumbers.Clear();
        }

        [IterationSetup]
        public void Setup()
        {
            for (int i = 0; i < itemCount; i++)
            {
                someNumbers.Add(i);
            }
        }


        [Benchmark]
        public void ParallelForListOperation()
        {
            //With Parallel.ForEach, there is a Partitioner
            //which gets created to avoid making more tasks than necessary
            //This can provide significantly better overall performance,
            //especially if the loop body has a small amount of work per item.
            Parallel.ForEach(someNumbers, x =>
            {
                x = 2 * 3;
            });
        }

        [Benchmark]
        public void TaskRunListOperation()
        {
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < itemCount; i++)
            {
                //Parameter has to be passed to the task like this
                //otherwise value of i changes before task is executed.
                int c = i;
                //Task.Run will always make a single task per item
                tasks.Add(Task.Run(() =>
                {
                    someNumbers[c] = 2 * 3;
                }));
            }

            Task.WaitAll(tasks.ToArray());
        }
    }
}
