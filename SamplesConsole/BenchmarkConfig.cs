using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;

namespace PerformanceBenchmarks
{
    public class BenchmarkConfig : ManualConfig
    {
        public BenchmarkConfig()
        {
            AddDiagnoser(new MemoryDiagnoser(new MemoryDiagnoserConfig(true)));
            AddDiagnoser(ThreadingDiagnoser.Default);

            this.WithOptions(ConfigOptions.JoinSummary);
            //this.WithOrderer(new DefaultOrderer(SummaryOrderPolicy.FastestToSlowest, MethodOrderPolicy.Declared));
        }
    }
}
