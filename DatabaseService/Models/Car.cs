namespace DatabaseService.Models
{
    public class Car
    {
        public int CarId { get; set; }
        public string? Name { get; set; }
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? Img { get; set; }
        public decimal Price { get; set; }
        public bool IsFavourite { get; set; }
        public bool Available { get; set; }
        public int CategoryId { get; set; }

    }
}
