using RecipeApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Let Him Cook");

        RecipeManager recipeManager = new RecipeManager();
        bool continueProgram = true;

        while (continueProgram)
        {
            Console.WriteLine("\n1. Enter Recipe Details");
            Console.WriteLine("2. Display All Recipes");
            Console.WriteLine("3. Display Recipe");
            Console.WriteLine("4. Scale Recipe");
            Console.WriteLine("5. Clear Recipe");
            Console.WriteLine("6. Exit");
            Console.Write("Select an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    recipeManager.EnterRecipeDetails();
                    break;
                case "2":
                    recipeManager.DisplayAllRecipes();
                    break;
                case "3":
                    Console.Write("Enter the name of the recipe to display: ");
                    string recipeName = Console.ReadLine();
                    recipeManager.DisplayRecipe(recipeName);
                    break;
                case "4":
                    Console.Write("Enter the name of the recipe to scale: ");
                    string recipeToScale = Console.ReadLine();
                    double scaleFactor = GetScaleFactorFromUser();
                    recipeManager.ScaleRecipe(recipeToScale, scaleFactor);
                    break;
                case "5":
                    Console.Write("Enter the name of the recipe to clear: ");
                    string recipeToClear = Console.ReadLine();
                    recipeManager.ClearRecipe(recipeToClear);
                    break;
                case "6":
                    continueProgram = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please select a valid option.");
                    break;
            }
        }
    }

    static double GetScaleFactorFromUser()
    {
        double scaleFactor;
        while (true)
        {
            Console.Write("Enter the scaling factor: ");
            if (double.TryParse(Console.ReadLine(), out scaleFactor) && scaleFactor > 0)
            {
                return scaleFactor;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a positive number.");
            }
        }
    }
}
