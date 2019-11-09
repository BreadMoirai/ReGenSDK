using System;
using System.Threading.Tasks;
using ReGenSDK.Exceptions;
using ReGenSDK.Model;

namespace ReGenSDK
{
    public static class ModelExtensions
    {
        public static Task<Recipe> Recipe(this RecipeLite recipeLite) => ReGenClient.Instance.Recipes.Get(recipeLite.Key);

        public static Task<double> AverageRating(this RecipeLite recipe) => ReGenClient.Instance.Ratings.GetAverage(recipe.Key);

        public static Task<int> Rating(this RecipeLite recipe) => ReGenClient.Instance.Ratings.Get(recipe.Key);

        public static Task<ReviewsPage> NextPage(this ReviewsPage page, int fetchSize = 5)
        {
            if (page.NextKey == null)
            {
                throw new RegenException("There are no more reviews to fetch");
            }
            return ReGenClient.Instance.Reviews.Get(page.RecipeId, page.NextKey, fetchSize);
        }

        public static Task<ReviewsPage> Reviews(this RecipeLite recipe, int fetchSize = 5) =>
            ReGenClient.Instance.Reviews.Get(recipe.Key, null, fetchSize);
    }
}