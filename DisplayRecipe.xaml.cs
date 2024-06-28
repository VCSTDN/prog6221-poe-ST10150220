using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PROG6221Part3
{
    /// <summary>
    /// Interaction logic for DisplayRecipe.xaml
    /// </summary>
    public partial class DisplayRecipe : Page
    {
        public DisplayRecipe()
        {
            InitializeComponent();
        }
        private void DisplayRecipeDetails(Recipe recipe)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Recipe Name: {recipe.RecipeName}");

            sb.AppendLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                sb.AppendLine($"- {ingredient.IngredientName}, Quantity: {ingredient.Quantity}, Unit: {ingredient.Unit}, Calories: {ingredient.Calories}, Food Group: {ingredient.FoodGroup}");
            }

            sb.AppendLine("Steps:");
            foreach (var step in recipe.Steps)
            {
                sb.AppendLine($"- {step}");
            }

            txtDisplayRecipeDetails.Text = sb.ToString();
        }

        private void ClearForm()
        {
            txtRecipeName.Text = string.Empty;
            txtNumIngredients.Text = string.Empty;
            txtNumSteps.Text = string.Empty;
            formPanel.Children.Clear();
        }
    }
}
