using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using ReGenSDK.Model;
using ReGenSDK.Service.Api;

namespace ReGenSDK.Service
{
    
    /// <inheritdoc />
    public abstract partial class ReviewService : IReviewApi
    {
        
        /// <inheritdoc cref="ReGenSDK.Service.Api.IReviewApi.Create"/>
        Task Create([NotNull] string recipeId, [NotNull] string content, int rating)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            if (content == null) throw new ArgumentNullException(nameof(content));
            if (rating < 0 || rating > 5) throw new ArgumentOutOfRangeException(nameof(rating));
            return Create(recipeId, new Review
            {
                Content = content,
                Rating = rating
            });
        }
    }
}