﻿using System.Threading.Tasks;
using JetBrains.Annotations;
using Refit;

namespace ReGenSDK.Service.Api
{
    public interface IRatingApi
    {
        [Get("/{recipeId}/average")]
        Task<double> GetAverage([NotNull] string recipeId);

        [Get("/{recipeId}")]
        [Headers("Authorization")]
        Task<int> Get([NotNull] string recipeId);

        [Put("/{recipeId}")]
        [Headers("Authorization")]
        Task Create([NotNull] string recipeId, [Body(BodySerializationMethod.Serialized), AliasAs("Rating")] 
            int rating);

        [Post("/{recipeId}")]
        [Headers("Authorization")]
        Task Update([NotNull] string recipeId, [Body(BodySerializationMethod.Serialized), AliasAs("Rating")]
            int rating);
    }
}