// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using PerformanceBenchmarks;

public class Program
{

    static void Main(string[] args)
    {
        //var res = BenchmarkRunner.Run<StringBenchmarks>();
        //var resDict = BenchmarkRunner.Run<DictionaryBenchmarks>();
        //var resAsyncParams = BenchmarkRunner.Run<AsyncParametersBenchmark>();
        //var resListEnumeration = BenchmarkRunner.Run<ListIndexerBenchmark>();
        var resParallelForVsTask = BenchmarkRunner.Run<ParallelForVsTaskBenchmark>();



        //BenchmarkRunner.Run(new[]{
        //    BenchmarkConverter.TypeToBenchmarks( typeof(StringBenchmarks)),
        //    BenchmarkConverter.TypeToBenchmarks( typeof(DictionaryBenchmarks)),
        //    BenchmarkConverter.TypeToBenchmarks( typeof(AsyncParametersBenchmark))
        //    });
    }

}