using System;
using System.Collections.Generic;
using System.Linq;

namespace RecipeApp
{
    class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<string> Steps { get; set; }

        public Recipe()
        {
            Ingredients = new List<Ingredient>();
            Steps = new List<string>();
        }

        public int GetTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories);
        }
    }

    class Ingredient
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public string Unit { get; set; }
        public int Calories { get; set; }
        public string FoodGroup { get; set; }
    }

    class RecipeManager
    {
        private List<Recipe> recipes = new List<Recipe>();

        public void EnterRecipeDetails()
        {
            Recipe recipe = new Recipe();

            Console.WriteLine("Enter the details for your recipe:");
            Console.Write("Enter the name of the recipe: ");
            recipe.Name = Console.ReadLine();

            // Prompt user to enter ingredient details
            int numOfIngredients = GetNumberFromUser("Enter the number of ingredients: ");

            for (int i = 0; i < numOfIngredients; i++)
            {
                Ingredient ingredient = new Ingredient();

                Console.Write($"Enter name of ingredient #{i + 1}: ");
                ingredient.Name = Console.ReadLine();

                ingredient.Quantity = GetQuantityFromUser($"Enter quantity of {ingredient.Name}: ");

                Console.Write($"Enter unit of measurement for {ingredient.Name}: ");
                ingredient.Unit = Console.ReadLine();

                Console.Write($"Enter number of calories for {ingredient.Name}: ");
                ingredient.Calories = int.Parse(Console.ReadLine());

                Console.Write($"Enter food group for {ingredient.Name}: ");
                ingredient.FoodGroup = Console.ReadLine();

                recipe.Ingredients.Add(ingredient);
            }

            // Prompt user to enter step details
            int numOfSteps = GetNumberFromUser("Enter the number of steps: ");

            for (int i = 0; i < numOfSteps; i++)
            {
                Console.Write($"Enter description for step #{i + 1}: ");
                string stepDescription = Console.ReadLine();
                recipe.Steps.Add(stepDescription);
            }

            recipes.Add(recipe);
        }

        public void DisplayAllRecipes()
        {
            if (recipes.Count == 0)
            {
                Console.WriteLine("No recipes available.");
                return;
            }

            Console.WriteLine("Recipes:");
            foreach (var recipe in recipes.OrderBy(r => r.Name))
            {
                Console.WriteLine(recipe.Name);
            }
        }

        public void DisplayRecipe(string recipeName)
        {
            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            Console.WriteLine($"\nRecipe: {recipe.Name}");

            Console.WriteLine("Ingredients:");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < recipe.Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipe.Steps[i]}");
            }

            Console.WriteLine($"\nTotal Calories: {recipe.GetTotalCalories()}");
            if (recipe.GetTotalCalories() > 300)
            {
                Console.WriteLine("Warning: Total calories exceed 300!");
            }
        }

        public void ScaleRecipe(string recipeName, double scaleFactor)
        {
            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            Console.WriteLine($"\nScaled Recipe for {recipe.Name} (Factor: {scaleFactor}):");
            foreach (var ingredient in recipe.Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity * scaleFactor} {ingredient.Unit} of {ingredient.Name}");
            }
        }

        public void ClearRecipe(string recipeName)
        {
            Recipe recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe == null)
            {
                Console.WriteLine("Recipe not found.");
                return;
            }

            recipes.Remove(recipe);
            Console.WriteLine("Recipe data cleared.");
        }

        private int GetNumberFromUser(string prompt)
        {
            int num;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out num) && num > 0)
                {
                    return num;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive integer.");
                }
            }
        }

        private double GetQuantityFromUser(string prompt)
        {
            double quantity;
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out quantity) && quantity > 0)
                {
                    return quantity;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a positive number.");
                }
            }
        }
    }
}