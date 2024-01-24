// See https://aka.ms/new-console-template for more information
using ArrayPract.ArrayReverse;
using ArrayPract.Sumpract;

Console.WriteLine("Hello, World!");
//TwoSum twoSum = new TwoSum();
//bool result = twoSum.IsTwoSum(new int[] { 2, 6, 5, 8, 11 }, 14);
//Console.WriteLine($"Two sum: {result}");

ReverseArray reverseArray = new ReverseArray();
int[] rev = reverseArray.Reverse(new int[] { 1, 3, 2,4 });
Console.ReadLine();
