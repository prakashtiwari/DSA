// See https://aka.ms/new-console-template for more information
using BuilderPattern.ImmutableBuilder;

Console.WriteLine("Hello, World!");

Person person = new Person.Builder("Prakash", "Tiwari").AddMiddleName("Prakky").Build();
person.Show();