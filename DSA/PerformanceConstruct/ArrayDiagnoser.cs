using BenchmarkDotNet.Attributes;

namespace PerformanceConstruct
{
    [MemoryDiagnoser]
    public class ArrayDiagnoser
    {
        private int[] myArray;
        // [Params(100, 1000, 10000)]
        [Params(10)]
        public int Size { get; set; }

        [GlobalSetup]
        public void Setup()
        {
            myArray = new int[Size];
            for (int i = 0; i < Size; i++)
            {
                myArray[i] = i;
            }
        }
        [Benchmark]
        public int[] Original() => myArray.Skip(Size / 2).Take(Size / 4).ToArray();

        [Benchmark]
        public int[] ArrayCopy()
        {

            var newArr = new int[Size];
            Array.Copy(myArray, Size / 2, newArr, 0, Size / 4);
            return newArr;
        }

        [Benchmark]
        public Span<int> Span() => myArray.AsSpan().Slice( Size / 2, Size / 4);
    }
}
