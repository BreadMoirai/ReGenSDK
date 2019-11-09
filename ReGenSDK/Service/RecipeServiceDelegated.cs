using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using ReGenSDK.Model;
using ReGenSDK.Service.Api;

namespace ReGenSDK.Service
{
    public abstract partial class RecipeService
    {
        protected readonly IRecipeApi RecipeApiImplementation;

        public RecipeService([NotNull] IRecipeApi recipeApiImplementation)
        {
            RecipeApiImplementation = recipeApiImplementation ?? throw new ArgumentNullException(nameof(recipeApiImplementation));
        }

        public Task<Recipe> Get(string recipeId)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            return RecipeApiImplementation.Get(recipeId);
        }

        public Task Update(string recipeId, Recipe recipe)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            if (recipe == null) throw new ArgumentNullException(nameof(recipe));
            return RecipeApiImplementation.Update(recipeId, recipe);
        }

        public Task Delete(string recipeId)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            return RecipeApiImplementation.Delete(recipeId);
        }

        public Task Create(Recipe recipe)
        {
            if (recipe == null) throw new ArgumentNullException(nameof(recipe));
            return RecipeApiImplementation.Create(recipe);
        }
    }
}