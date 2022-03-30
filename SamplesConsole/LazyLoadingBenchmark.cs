// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Attributes;
using PerformanceBenchmarks;

[MemoryDiagnoser]
[MaxColumn, MinColumn]
[Config(typeof(BenchmarkConfig))]
public class LazyLoadingBenchmark
{
    public static readonly int itemCount = 1000;
    Random random = new Random();


    private static IList<int> PopulateList()
    {
        var list = new List<int>();

        for (int i = 0; i < itemCount; i++)
        {
            list.Add(i);
        }
        return list;
    }

    [Benchmark(Baseline = true)]
    public void UseListConditionally()
    {
        IList<int> regularList;

        regularList = PopulateList();

        bool condition = random.Next(1, 3) % 2 == 0;

        if (condition)
        {
            regularList[itemCount - 1]++;
        }
    }

    [Benchmark]
    public void UseLazyListConditionally()
    {
        Lazy<IList<int>> lazyList;

        lazyList = new Lazy<IList<int>>(() =>
        {
            return PopulateList();
        });

        bool condition = random.Next(1, 3) % 2 == 0;

        if (condition)
        {
            lazyList.Value[itemCount - 1]++;
        }
    }
}