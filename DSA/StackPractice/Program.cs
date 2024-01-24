// See https://aka.ms/new-console-template for more information
using StackPractice.Solutions;

Console.WriteLine("Hello, World!");
NextGreaterElement nextGreaterElement = new NextGreaterElement();
int[] result = nextGreaterElement.GetNextGreaterElement(new int[] { 3, 2, 6, 4, 5 });
Console.ReadLine();