namespace Sushi_Bar.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAllergen { get; set; }

        public ICollection<DishIngredient> DishIngredients { get; set; }
    }
}
