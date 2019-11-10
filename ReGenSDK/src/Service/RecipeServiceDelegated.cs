using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using ReGenSDK.Model;
using ReGenSDK.Service.Api;

namespace ReGenSDK.Service
{
    /// <inheritdoc />
    public abstract partial class RecipeService
    {
        protected readonly IRecipeApi RecipeApiImplementation;

        internal RecipeService([NotNull] IRecipeApi recipeApiImplementation)
        {
            RecipeApiImplementation = recipeApiImplementation ??
                                      throw new ArgumentNullException(nameof(recipeApiImplementation));
        }

        /// <inheritdoc />
        public Task<Recipe> Get(string recipeId)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            return RecipeApiImplementation.Get(recipeId);
        }

        /// <inheritdoc />
        public Task Update(string recipeId, Recipe recipe)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            if (recipe == null) throw new ArgumentNullException(nameof(recipe));
            return RecipeApiImplementation.Update(recipeId, recipe);
        }

        /// <inheritdoc />
        public Task Delete(string recipeId)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            return RecipeApiImplementation.Delete(recipeId);
        }

        /// <inheritdoc />
        public Task Create(Recipe recipe)
        {
            if (recipe == null) throw new ArgumentNullException(nameof(recipe));
            return RecipeApiImplementation.Create(recipe);
        }
    }
}