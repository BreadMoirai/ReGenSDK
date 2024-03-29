﻿using System.Threading.Tasks;
using JetBrains.Annotations;
using Refit;
using ReGenSDK.Model;

namespace ReGenSDK.Service.Api
{
    public interface IRecipeApi
    {
        [Get("/{recipeId}")]
        Task<Recipe> Get([NotNull] string recipeId);

        [Post("/{recipeId}")]
        [Headers("Authorization: Bearer")]
        Task Update([NotNull] string recipeId, [NotNull, Body]  Recipe recipe);

        [Delete("/{recipeId}")]
        [Headers("Authorization: Bearer")]
        Task Delete([NotNull] string recipeId);

        [Put("")]
        [Headers("Authorization: Bearer")]
        Task Create([NotNull, Body] Recipe recipe);
    }
}