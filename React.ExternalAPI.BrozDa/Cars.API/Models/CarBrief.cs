namespace Cars.API.Models
{
    public class CarBrief
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImageUrl { get; set; } = null!;

        public CarBrief(Guid id, string name, string imageUrl)
        {
            Id= id;
            Name = name;
            ImageUrl= imageUrl;
        }
    }
}
