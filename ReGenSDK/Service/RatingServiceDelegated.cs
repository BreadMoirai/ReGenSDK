using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using ReGenSDK.Service.Api;

namespace ReGenSDK.Service
{
    public abstract partial class RatingService
    {
        protected readonly IRatingApi RatingApiImplementation;

        protected RatingService([NotNull] IRatingApi ratingApiImplementation)
        {
            RatingApiImplementation = ratingApiImplementation ?? throw new ArgumentNullException(nameof(ratingApiImplementation));
        }

        public Task<double> GetAverage(string recipeId)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            return RatingApiImplementation.GetAverage(recipeId);
        }

        public Task<int> Get(string recipeId)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            return RatingApiImplementation.Get(recipeId);
        }

        public Task Create(string recipeId, int rating)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            if (rating < 0 || rating > 5) throw new ArgumentOutOfRangeException(nameof(rating));
            return RatingApiImplementation.Create(recipeId, rating);
        }

        public Task Update(string recipeId, int rating)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            if (rating < 0 || rating > 5) throw new ArgumentOutOfRangeException(nameof(rating));
            return RatingApiImplementation.Update(recipeId, rating);
        }
    }
}