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
    public partial class AddRecipe : Page
    {
        public AddRecipe()
        {
            InitializeComponent();

        }
        private void GenerateForm_Click(object sender, RoutedEventArgs e)
        {
            formPanel.Children.Clear();

            if (int.TryParse(txtNumIngredients.Text, out int numIngredients) && int.TryParse(txtNumSteps.Text, out int numSteps))
            {
                TextBlock ingredientsHeader = new TextBlock
                {
                    Text = "Ingredients:",
                    Margin = new Thickness(0, 10, 0, 10)
                };
                formPanel.Children.Add(ingredientsHeader);

                for (int i = 0; i < numIngredients; i++)
                {
                    StackPanel ingredientPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };

                    TextBlock nameLabel = new TextBlock { Text = $"Name of Ingredient {i + 1}:", VerticalAlignment = VerticalAlignment.Center, Width = 150 };
                    ingredientPanel.Children.Add(nameLabel);
                    ingredientPanel.Children.Add(new TextBox { Width = 100, Margin = new Thickness(5), Tag = $"ingredientName{i}" });

                    TextBlock quantityLabel = new TextBlock { Text = "Quantity:", VerticalAlignment = VerticalAlignment.Center, Width = 60 };
                    ingredientPanel.Children.Add(quantityLabel);
                    ingredientPanel.Children.Add(new TextBox { Width = 50, Margin = new Thickness(5), Tag = $"ingredientQuantity{i}" });

                    TextBlock unitLabel = new TextBlock { Text = "Unit:", VerticalAlignment = VerticalAlignment.Center, Width = 60 };
                    ingredientPanel.Children.Add(unitLabel);
                    ingredientPanel.Children.Add(new TextBox { Width = 60, Margin = new Thickness(5), Tag = $"ingredientUnit{i}" });

                    TextBlock caloriesLabel = new TextBlock { Text = "Calories:", VerticalAlignment = VerticalAlignment.Center, Width = 60 };
                    ingredientPanel.Children.Add(caloriesLabel);
                    ingredientPanel.Children.Add(new TextBox { Width = 60, Margin = new Thickness(5), Tag = $"ingredientCalories{i}" });

                    TextBlock foodGroupLabel = new TextBlock { Text = "Food Group:", VerticalAlignment = VerticalAlignment.Center, Width = 100 };
                    ingredientPanel.Children.Add(foodGroupLabel);
                    ComboBox foodGroupComboBox = new ComboBox { Width = 100, Margin = new Thickness(5), Tag = $"ingredientFoodGroup{i}", ItemsSource = new string[] { "Starchy foods", "Vegetables and fruits", "Dry beans, peas, lentils and soya", "Chicken, fish, meat and eggs", "Milk and dairy products", "Fats and oil", "Water" } };
                    ingredientPanel.Children.Add(foodGroupComboBox);

                    formPanel.Children.Add(ingredientPanel);
                }

                TextBlock stepsHeader = new TextBlock
                {
                    Text = "Steps:",
                    FontWeight = FontWeights.Bold,
                    Margin = new Thickness(0, 20, 0, 10)
                };
                formPanel.Children.Add(stepsHeader);

                for (int i = 0; i < numSteps; i++)
                {
                    StackPanel stepPanel = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 5, 0, 5) };

                    TextBlock stepLabel = new TextBlock { Text = $"Step {i + 1}:", VerticalAlignment = VerticalAlignment.Center, Width = 80 };
                    stepPanel.Children.Add(stepLabel);
                    stepPanel.Children.Add(new TextBox { Width = 300, Margin = new Thickness(5), Tag = $"step{i}" });

                    formPanel.Children.Add(stepPanel);
                }

                Button saveButton = new Button { Content = "Save Recipe", HorizontalAlignment = HorizontalAlignment.Center, Margin = new Thickness(10, 20, 10, 10) };
                saveButton.Click += SaveRecipe_Click;
                formPanel.Children.Add(saveButton);
            }
            else
            {
                MessageBox.Show("Invalid entery");
            }
        }

        private void SaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe();
            recipe.RecipeName = txtRecipeName.Text;

            foreach (var child in formPanel.Children)
            {
                if (child is StackPanel panel)
                {
                    Ingredient ingredient = new Ingredient();
                    foreach (var element in panel.Children)
                    {
                        if (element is TextBox textBox && textBox.Tag != null)
                        {
                            string tag = textBox.Tag.ToString();
                            string value = textBox.Text;

                            switch (tag)
                            {
                                case "ingredientName":
                                    ingredient.IngredientName = value;
                                    break;
                                case "ingredientQuantity":
                                    ingredient.Quantity = double;
                                    break;
                                case "ingredientUnit":
                                    ingredient.Unit = value;
                                    break;
                                case "ingredientCalories":
                                    ingredient.Calories = int;
                                    break;
                            }
                        }
                        else if (element is ComboBox comboBox && comboBox.Tag != null)
                        {
                            string tag = comboBox.Tag.ToString();
                            string value = comboBox.SelectedItem?.ToString();

                            switch (tag)
                            {
                                case "ingredientFoodGroup":
                                    ingredient.FoodGroup = value;
                                    break;
                            }
                        }
                    }
                    recipe.Ingredients.Add(ingredient);
                }
            }

            for (int i = 0; i < int.Parse(txtNumSteps.Text); i++)
            {
                TextBox stepTextBox = formPanel.Children.OfType<TextBox>().FirstOrDefault(tb => tb.Tag.ToString() == $"step{i}");
                if (stepTextBox != null)
                {
                    recipe.Steps.Add(stepTextBox.Text);
                }
            }

            DisplayRecipe(recipe);

            ClearForm();
        }
    }
}