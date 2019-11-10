using ReGenSDK.Service.Api;

namespace ReGenSDK.Service.Impl
{
    class RecipeServiceImpl : RecipeService
    {
        public RecipeServiceImpl(IRecipeApi recipeApiImplementation) : base(recipeApiImplementation)
        {
        }
    }
}