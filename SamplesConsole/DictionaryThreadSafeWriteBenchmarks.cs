using BenchmarkDotNet.Attributes;
using PerformanceBenchmarks.TestSubjects;
using System.Collections.Concurrent;

namespace PerformanceBenchmarks
{
    [MemoryDiagnoser]
    [MaxColumn, MinColumn]
    [Config(typeof(BenchmarkConfig))]
    //[SimpleJob(BenchmarkDotNet.Engines.RunStrategy.Throughput)]
    public class DictionaryThreadSafeWriteBenchmarks
    {
        private static readonly ThreadSafeDictionary<int, string> tsd = new ThreadSafeDictionary<int, string>();
        private static readonly ConcurrentDictionary<int, string> concurrentDictionary = new ConcurrentDictionary<int, string>();
        private static readonly int addorupdateIterationCount = 1000;
        private static readonly int addorupdateMaxParallelism = 10;
        private static readonly Random random = new Random();

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
            parallelOptions.MaxDegreeOfParallelism = addorupdateMaxParallelism;
            Parallel.For(0, addorupdateIterationCount, parallelOptions, i =>
            {
                //Get keys only from 1 to 10 to make sure there are existing key updates in the test
                tsd.AddorUpdate(random.Next(0, 10), "test value");
            });
        }


        [Benchmark]
        public void AddOrUpdateConcurrentDictionary()
        {
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = addorupdateMaxParallelism;
            Parallel.For(0, addorupdateIterationCount, parallelOptions, i =>
            {
                //Get keys only from 1 to 10 to make sure there are existing key updates in the test
                concurrentDictionary.AddOrUpdate(random.Next(0, 10), "test value", (key, val) => "test value");
            });
        }

        [Benchmark]
        public void AddOrUpdateAllNewKeysThreadSafeDictionary()
        {
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = addorupdateMaxParallelism;
            Parallel.For(0, addorupdateIterationCount, parallelOptions, i =>
             {
                 tsd.AddorUpdate(random.Next(0, addorupdateIterationCount), "test value");
             });
        }

        [Benchmark]
        public void AddOrUpdateAllNewKeysConcurrentDictionary()
        {
            ParallelOptions parallelOptions = new ParallelOptions();
            parallelOptions.MaxDegreeOfParallelism = addorupdateMaxParallelism;
            Parallel.For(0, addorupdateIterationCount, parallelOptions, i =>
            {
                concurrentDictionary.AddOrUpdate(random.Next(0, addorupdateIterationCount), "test value", (key, val) => "test value");
            });
        }

    }
}
