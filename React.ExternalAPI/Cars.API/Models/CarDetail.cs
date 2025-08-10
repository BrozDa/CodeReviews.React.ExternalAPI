namespace Cars.API.Models
{
    public class CarDetail
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;   
        public string ImageUrl { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
