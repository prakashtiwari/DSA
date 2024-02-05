namespace BookMyShowLLD.DataModel
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Theatre>? Theatre { get; set; }
    }
}
