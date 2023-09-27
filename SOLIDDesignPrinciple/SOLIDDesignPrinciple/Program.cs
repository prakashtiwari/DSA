// See https://aka.ms/new-console-template for more information
using SOLIDDesignPrinciple.LSP;
using SOLIDDesignPrinciple.SRP;

//Console.WriteLine("Hello, World!");
//RatingEngine ratingEngine = new RatingEngine();
//int rating = ratingEngine.Rate();
//if (rating > 0)
//{
//    Console.WriteLine(1000M);
//    Console.WriteLine($"Rating is : {rating}");
//}
//else
//{
//    Console.WriteLine($"No rating produced");
//}

//LSP
//AreaCalculator areaCalculator = new AreaCalculator();
//Rectangle areaRectangle = new Square();
//areaRectangle.Width = 10;
//areaRectangle.Height = 5;
//int area= areaCalculator.CalculateArea(areaRectangle);
//Console.WriteLine($"Area is : {area}" );
//Console.ReadLine();

//LSP2

List<Employee> employees = new List<Employee>();
employees.Add(new Employee() { Name = "Panda", Address = "US" });
employees.Add(new Manager() { Name = "Kungfu", Address = "US", Shares = 200 });
employees.Add(new Employee() { Name = "Dean", Address = "US" });
foreach (Employee emp in employees)
{
    if (emp is Manager)
    {
        PrintUtil.PrintManager(emp as Manager);
    }
    else
    {
        Console.WriteLine($"Name: {emp.Name}, Share:{emp.Address}");
    }
}