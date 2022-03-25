using BenchmarkDotNet.Attributes;
using PerformanceBenchmarks.TestSubjects;

namespace PerformanceBenchmarks
{
    [Config(typeof(BenchmarkConfig))]
    public class StringBenchmarks
    {
        private static readonly StringTests subject = new StringTests();

        [Benchmark(Baseline = true)]
        public string GetFullStringNormally()
        {
            return subject.GetFullStringNormally();
        }

        [Benchmark]
        public string GetFullStringWithStringBuilder()
        {
            return subject.GetFullStringWithStringBuilder();
        }

        [Benchmark]
        public string GetFullStringWithStringBuilderConcatenation()
        {
            return subject.GetFullStringWithStringBuilderConcatenation();

        }
    }
}
