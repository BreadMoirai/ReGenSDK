using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using ReGenSDK.Service.Api;

namespace ReGenSDK.Service
{
    public abstract partial class FavoriteService
    {
        protected readonly IFavoriteApi FavoriteApiImplementation;

        internal FavoriteService([NotNull] IFavoriteApi favoriteApiImplementation)
        {
            FavoriteApiImplementation = favoriteApiImplementation ??
                                        throw new ArgumentNullException(nameof(favoriteApiImplementation));
        }

        /// <inheritdoc />
        public Task<Dictionary<string, bool>> Get()
        {
            return FavoriteApiImplementation.Get();
        }

        /// <inheritdoc />
        public Task Create(string recipeId)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            return FavoriteApiImplementation.Create(recipeId);
        }

        /// <inheritdoc />
        public Task Delete(string recipeId)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            return FavoriteApiImplementation.Delete(recipeId);
        }
    }
}