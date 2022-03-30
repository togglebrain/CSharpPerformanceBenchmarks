# CSharpPerformanceBenchmarks
Performance benchmarks for various C# scenarios.
Run without debugging in release mode only.
Needs VS 2022 / .NET 6

## Results:

### String Concatenation Vs String Builder Append Vs String Builder Append with Concatenation

|                                      Method |     Mean |     Error |    StdDev |   Median | Ratio | RatioSD |  Gen 0  | Allocated |
|-------------------------------------------- |---------:|----------:|----------:|---------:|------:|--------:|--------:|----------:|
|                       GetFullStringNormally | 8.648 μs | 0.1722 μs | 0.3518 μs | 8.492 μs |  1.00 |    0.00 | 29.8615 |    122 KB |
|              GetFullStringWithStringBuilder | 1.859 μs | 0.0612 μs | 0.1804 μs | 1.818 μs |  0.21 |    0.02 |  1.6918 |      7 KB |
| GetFullStringWithStringBuilderConcatenation | 3.939 μs | 0.1088 μs | 0.3192 μs | 4.005 μs |  0.47 |    0.04 |  3.5286 |     14 KB |

### Concurrent Dictionary AddorUpdate vs Custom Dictionary with Lock


|                                    Method |      Mean |     Error |    StdDev |    Median |       Max |       Min | Ratio | RatioSD | Completed Work Items | Lock Contentions | Allocated |
|------------------------------------------ |----------:|----------:|----------:|----------:|----------:|----------:|------:|--------:|---------------------:|-----------------:|----------:|
|           AddOrUpdateThreadSafeDictionary | 150.63 μs |  7.891 μs | 23.018 μs | 155.10 μs | 199.00 μs |  76.30 μs |  1.00 |    0.00 |               7.0000 |                - |      4 KB |
|           AddOrUpdateConcurrentDictionary |  77.85 μs |  1.541 μs |  3.416 μs |  76.60 μs |  87.90 μs |  71.90 μs |  0.53 |    0.09 |               8.0000 |                - |      4 KB |
| AddOrUpdateAllNewKeysThreadSafeDictionary | 138.03 μs |  4.081 μs | 11.969 μs | 138.10 μs | 172.10 μs | 110.40 μs |  0.94 |    0.19 |               9.0000 |           4.0000 |      4 KB |
| AddOrUpdateAllNewKeysConcurrentDictionary | 189.01 μs | 10.126 μs | 29.697 μs | 184.00 μs | 259.10 μs | 109.00 μs |  1.29 |    0.29 |               9.0000 |          19.0000 |     57 KB |

### Inline Async Method Parameters vs Async Method Parameters Evaluated Beforehand 

|                               Method |     Mean |    Error |   StdDev |      Max |      Min | Ratio | RatioSD | Completed Work Items | Allocated |
|------------------------------------- |---------:|---------:|---------:|---------:|---------:|------:|--------:|---------------------:|----------:|
|        AsyncMethodParamsPassedInline | 54.20 ms | 1.083 ms | 2.445 ms | 58.76 ms | 49.77 ms |  1.00 |    0.00 |               2.0000 |     885 B |
| AsyncMethodParamsEvaluatedBeforehand | 33.04 ms | 0.648 ms | 1.324 ms | 36.25 ms | 30.47 ms |  0.61 |    0.04 |               2.0000 |     851 B |

### IList and ImmutableList - ForEach vs For Loop 

|                    Method |      Mean |     Error |   StdDev |       Max |       Min | Ratio | RatioSD | Allocated |
|-------------------------- |----------:|----------:|---------:|----------:|----------:|------:|--------:|----------:|
|            EnumerateIList |  17.75 μs |  0.481 μs | 1.324 μs |  22.50 μs |  16.20 μs |  1.00 |    0.00 |     480 B |
|     EnumerateIListForEach |  75.09 μs |  1.956 μs | 5.289 μs |  91.50 μs |  69.30 μs |  4.26 |    0.44 |     520 B |
|        EnumerateImmutable | 525.73 μs | 10.353 μs | 9.685 μs | 548.30 μs | 513.00 μs | 30.48 |    1.69 |     480 B |
| EnumerateImmutableForEach | 250.62 μs |  4.212 μs | 6.558 μs | 264.30 μs | 241.30 μs | 14.41 |    1.03 |     480 B |

### Parallel For vs For Loop with Task.Run and AwaitAll

|                   Method |        Mean |      Error |     StdDev |         Max |         Min | Completed Work Items | Allocated |
|------------------------- |------------:|-----------:|-----------:|------------:|------------:|---------------------:|----------:|
| ParallelForListOperation |    54.53 μs |   1.088 μs |   2.867 μs |    62.10 μs |    49.60 μs |               7.0000 |      4 KB |
|     TaskRunListOperation | 3,430.66 μs | 184.293 μs | 543.392 μs | 4,650.40 μs | 2,379.30 μs |           10000.0000 |  1,820 KB |

### List<T> vs Lazy<List<T>>

|                     Method |     Mean |   Error |   StdDev |   Median |      Max |      Min | Ratio | RatioSD |  Gen 0 | Allocated |
|--------------------------- |---------:|--------:|---------:|---------:|---------:|---------:|------:|--------:|-------:|----------:|
|       UseListConditionally | 292.2 ns | 5.83 ns | 15.96 ns | 289.3 ns | 329.5 ns | 261.8 ns |  1.00 |    0.00 | 0.2828 |   1,184 B |
|   UseLazyListConditionally | 177.4 ns | 3.58 ns |  8.43 ns | 172.2 ns | 200.2 ns | 168.9 ns |  0.61 |    0.05 | 0.1585 |     664 B |
|     UseListUnconditionally | 336.2 ns | 6.28 ns | 10.84 ns | 336.7 ns | 355.9 ns | 306.1 ns |  1.17 |    0.06 | 0.2828 |   1,184 B |
| UseLazyListUnconditionally | 361.2 ns | 8.40 ns | 24.63 ns | 367.6 ns | 406.9 ns | 307.2 ns |  1.23 |    0.11 | 0.2999 |   1,256 B |


