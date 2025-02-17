namespace backend.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public decimal Price { get; set; }

        public required string ImageUrl { get; set; }
        public required bool ShowInMenu { get; set; }
    }
}
