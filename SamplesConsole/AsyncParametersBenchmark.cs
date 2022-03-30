using BenchmarkDotNet.Attributes;
using PerformanceBenchmarks.TestSubjects;

namespace PerformanceBenchmarks
{

    [MemoryDiagnoser]
    [MaxColumn, MinColumn]
    [Config(typeof(BenchmarkConfig))]
    public class AsyncParametersBenchmark
    {
        public static readonly AsyncParameters asyncParamsHelper = new AsyncParameters();

        [Benchmark(Baseline = true)]
        public async Task AsyncMethodParamsPassedInline()
        {
            asyncParamsHelper.PerformCalculation(await asyncParamsHelper.GetAPICount(),
                await asyncParamsHelper.GetDBCount());
        }

        [Benchmark]
        public async Task AsyncMethodParamsEvaluatedBeforehand()
        {
            Task<int> count1 = asyncParamsHelper.GetAPICount();
            Task<int> count2 = asyncParamsHelper.GetDBCount();
            int c1 = await count1;
            int c2 = await count2;
            asyncParamsHelper.PerformCalculation(c1, c2);
        }
    }
}
