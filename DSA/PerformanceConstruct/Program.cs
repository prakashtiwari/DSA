// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using PerformanceConstruct;

Console.WriteLine("Hello, World!");
_ = BenchmarkRunner.Run<ArrayDiagnoser>();
