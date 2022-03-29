// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using PerformanceBenchmarks;

public class Program
{

    static void Main(string[] args)
    {
        /*
         * Quick Run: Uncomment individual/multiple lines below to run selective tests
         */
        //var res = BenchmarkRunner.Run<StringBenchmarks>();
        //var resDict = BenchmarkRunner.Run<DictionaryThreadSafeWriteBenchmarks>();
        //var resAsyncParams = BenchmarkRunner.Run<AsyncParametersBenchmark>();
        //var resListEnumeration = BenchmarkRunner.Run<ListIndexerBenchmark>();
        //var resParallelForVsTask = BenchmarkRunner.Run<ParallelForVsTaskBenchmark>();



        /*
         * Run All: Uncomment lines below to run all tests (might take a while to execute)
         */
        BenchmarkRunner.Run(new[]{
            BenchmarkConverter.TypeToBenchmarks( typeof(StringBenchmarks)),
            BenchmarkConverter.TypeToBenchmarks( typeof(DictionaryThreadSafeWriteBenchmarks)),
            BenchmarkConverter.TypeToBenchmarks( typeof(AsyncParametersBenchmark))
            });
    }

}