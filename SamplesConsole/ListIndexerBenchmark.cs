using BenchmarkDotNet.Attributes;
using System.Collections.Immutable;

namespace PerformanceBenchmarks
{
    [MemoryDiagnoser]
    [MaxColumn, MinColumn]
    [Config(typeof(BenchmarkConfig))]
    public class ListIndexerBenchmark
    {
        private static readonly IList<string> testList = new List<string>();
        private static readonly int itemCount = 10000;
        private static ImmutableList<string> testIEnumerable;

        [IterationSetup]
        public void Setup()
        {
            for (int i = 0; i < itemCount; i++)
            {
                testList.Add("Test data " + i);
            }
            testIEnumerable = ImmutableList.Create<string>(testList.ToArray());
        }

        [IterationCleanup]
        public void Cleanup()
        {
            testList.Clear();
        }

        [Benchmark(Baseline = true)]
        public void EnumerateIList()
        {
            string val;
            for (int i = 0; i < itemCount; i++)
            {
                val = testList[i];
            }
        }

        [Benchmark]
        public void EnumerateIListForEach()
        {
            string val;

            foreach (var item in testList)
            {
                val = item;
            }
        }

        [Benchmark]
        public void EnumerateEnumerable()
        {
            string val;
            for (int i = 0; i < itemCount; i++)
            {
                val = testIEnumerable[i];
            }
        }


        [Benchmark]
        public void EnumerateEnumerableForEach()
        {
            string val;
            foreach (var item in testIEnumerable)
            {
                val = item;
            }
        }
    }
}
