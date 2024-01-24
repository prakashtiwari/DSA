```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22621.2861/22H2/2022Update/SunValley2)
11th Gen Intel Core i5-11320H 3.20GHz, 1 CPU, 8 logical and 4 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2 [AttachedDebugger]
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
| Method    | Size | Mean       | Error     | StdDev     | Median     | Gen0   | Allocated |
|---------- |----- |-----------:|----------:|-----------:|-----------:|-------:|----------:|
| Original  | 10   | 80.0569 ns | 5.9665 ns | 16.3331 ns | 77.8068 ns | 0.0305 |     128 B |
| ArrayCopy | 10   | 19.2945 ns | 3.1693 ns |  9.1947 ns | 17.4956 ns | 0.0153 |      64 B |
| Span      | 10   |  0.6506 ns | 0.0806 ns |  0.2376 ns |  0.5877 ns |      - |         - |
