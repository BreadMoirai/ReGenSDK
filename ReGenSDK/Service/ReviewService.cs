using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using ReGenSDK.Model;
using ReGenSDK.Service.Api;

namespace ReGenSDK.Service
{
    public abstract partial class ReviewService : IReviewApi
    {
        /// <summary>
        /// Returns a Paginator that allows you to iterate through the api.
        /// </summary>
        /// <param name="recipeId">the recipe id</param>
        /// <param name="fetchSize">how many reviews to fetch per call</param>
        /// <returns></returns>
        /// <seealso cref="RegenSDK.Service.Paginator.GetNext"/>
        public abstract IPaginator<Review, string> Paginated(string recipeId, int fetchSize);
        
        /// <inheritdoc cref="IReviewApi.Create"/>
        /// <param name="recipeId"></param>
        /// <param name="content"></param>
        /// <param name="rating"></param>
        /// <returns></returns>
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