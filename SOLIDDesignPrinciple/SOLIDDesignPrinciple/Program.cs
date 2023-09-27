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
// Area calculator=
AreaCalculator areaCalculator = new AreaCalculator();
Rectangle areaRectangle = new Square();
areaRectangle.Width = 10;
areaRectangle.Height = 5;
int area= areaCalculator.CalculateArea(areaRectangle);
Console.WriteLine($"Area is : {area}" );
Console.ReadLine();
