// See https://aka.ms/new-console-template for more information
using SOLIDDesignPrinciple.SRP;

Console.WriteLine("Hello, World!");
RatingEngine ratingEngine = new RatingEngine();
int rating = ratingEngine.Rate();
if (rating > 0)
{
    Console.WriteLine($"Rating is : {rating}");
}
else
{
    Console.WriteLine($"No rating produced");
}
