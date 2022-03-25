using BenchmarkDotNet.Attributes;
using PerformanceBenchmarks.TestSubjects;
using System.Collections.Concurrent;

namespace PerformanceBenchmarks
{
    [MemoryDiagnoser]
    [MaxColumn, MinColumn]
    [Config(typeof(BenchmarkConfig))]
    public class DictionaryBenchmarks
    {
        ThreadSafeDictionary<Guid, string> tsd = new ThreadSafeDictionary<Guid, string>();
        ConcurrentDictionary<Guid, string> concurrentDictionary = new ConcurrentDictionary<Guid, string>();

        [IterationCleanup]
        public void Cleanup()
        {
            tsd.Clear();
            concurrentDictionary.Clear();
        }

        [Benchmark(Baseline = true)]
        public void AddOrUpdateThreadSafeDictionary()
        {
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = 10;
            Parallel.For(0, 10000, i =>
            {
                tsd.AddorUpdate(Guid.NewGuid(), "test value");
            });
        }

        [Benchmark]
        public void AddOrUpdateConcurrentDictionary()
        {
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = 10;
            Parallel.For(0, 10000, i =>
            {
                concurrentDictionary.AddOrUpdate(Guid.NewGuid(), "test value", (key, val) => "test value");
            });
        }

    }
}
