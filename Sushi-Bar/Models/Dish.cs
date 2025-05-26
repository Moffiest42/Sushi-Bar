using System.ComponentModel.DataAnnotations;

namespace Sushi_Bar.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; } // например, "роллы", "суши", "салаты"
        public string ImageUrl { get; set; }

        public ICollection<DishIngredient> DishIngredients { get; set; }
    }
}
