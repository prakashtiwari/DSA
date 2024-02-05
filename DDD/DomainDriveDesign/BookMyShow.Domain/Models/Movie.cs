namespace BookmyShowLLDDesign.Model
{
    public class Movie
    {
        public string Name { get; set; }
        public List<Actor> Actors { get; set; }

        public List<Language> Languages { get; set; }

        public double Length { get; set; }
        public double Rating { get; set; }
        public MovieFeature Feature { get; set; }
    }
}
