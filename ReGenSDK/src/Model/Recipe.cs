using System;
using System.Collections.Generic;

namespace ReGenSDK.Model
{
    public class Recipe : RecipeLite
    {
        #region Properties

        public string AuthorId { get; set; }
        public int? Calories { get; set; }
        public int? PrepTimeMinutes { get; set; }
        public IEnumerable<string> Steps { get; set; }
        public string ImageReferencePath { get; set; }
        public string RootImagePath { get; set; }

        #endregion

        public Recipe(string key, string authorId, string name, int? calories, int? prepTimeMinutes,
            IEnumerable<Ingredient> ingredients, IEnumerable<string> steps, IEnumerable<string> tags,
            string imageReferencePath, string rootImagePath)
        {
            Key = key;
            AuthorId = authorId;
            Name = name;
            Calories = calories;
            PrepTimeMinutes = prepTimeMinutes;
            Ingredients = ingredients;
            Steps = steps;
            Tags = tags;
            ImageReferencePath = imageReferencePath;
            RootImagePath = rootImagePath;
        }


        public override string ToString()
        {
            String recipeString = "";

            recipeString += "Name: " + Name;
            recipeString += "\nCalories: " + Calories;
            recipeString += "\nPrep Time: " + PrepTimeMinutes + " minutes";
            recipeString += "\n\nIngredients: ";

            foreach (var ingredient in Ingredients)
                recipeString += "\n" + ingredient;

            recipeString += "\n\nSteps: ";

            foreach (var step in Steps)
                recipeString += "\n\n" + step;

            recipeString += "\n\n" + RootImagePath;

            return recipeString;
        }
    }
}