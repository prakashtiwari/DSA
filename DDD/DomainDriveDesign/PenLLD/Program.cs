// See https://aka.ms/new-console-template for more information
using PenLLD.Common;
using PenLLD.DataModel;

Console.WriteLine("Hello, World!");
GelPen gelPen = PenFactory.CreateGetPen().SetRefil(new Refill()).CanChangeRefil(true).Build();
gelPen.Write();
Console.ReadLine();