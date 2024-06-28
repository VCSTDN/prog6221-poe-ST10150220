using System.Collections.Generic;

namespace PROG6221Part3
{
    public class Recipe
    {
        public string RecipeName { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe(string recipeName, List<Ingredient> ingredients, List<string> steps)
        {
            RecipeName = recipeName;
            Ingredients = ingredients;
            Steps = steps;
        }

        public Recipe DeepCopy()
        {
            var ingredientsCopy = new List<Ingredient>();
            foreach (var ingredient in Ingredients)
            {
                ingredientsCopy.Add(new Ingredient
                {
                    IngredientName = ingredient.IngredientName,
                    Quantity = ingredient.Quantity,
                    Unit = ingredient.Unit,
                    Calories = ingredient.Calories,
                    FoodGroup = ingredient.FoodGroup
                });
            }
            return new Recipe(RecipeName, ingredientsCopy, new List<string>(Steps));
        }
    }
}