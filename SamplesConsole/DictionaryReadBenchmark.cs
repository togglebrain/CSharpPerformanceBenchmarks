using BenchmarkDotNet.Attributes;

namespace PerformanceBenchmarks
{
    [MemoryDiagnoser]
    [MaxColumn, MinColumn]
    [Config(typeof(BenchmarkConfig))]
    public class DictionaryReadBenchmark
    {
    }
}
