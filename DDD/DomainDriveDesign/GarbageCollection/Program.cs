// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
var lotalMemory = GC.GetTotalMemory(false);
Console.WriteLine($"Total allocated?: {lotalMemory}");
GC.Collect();
var total = GC.GetTotalMemory(false);
Console.WriteLine($"Memory after collection : {total}");

Console.ReadLine();
