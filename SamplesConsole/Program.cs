// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using PerformanceBenchmarks;

public class Program
{

    static void Main(string[] args)
    {
        //var res = BenchmarkRunner.Run<StringBenchmarks>();
        var resDict = BenchmarkRunner.Run<DictionaryBenchmarks>();
    }

}