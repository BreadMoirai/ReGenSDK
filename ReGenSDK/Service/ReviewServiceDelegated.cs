using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JetBrains.Annotations;
using ReGenSDK.Model;
using ReGenSDK.Service.Api;
using ReGenSDK.Tasks;

namespace ReGenSDK.Service
{
    public abstract partial class ReviewService
    {
        protected readonly IReviewApi ReviewApiImplementation;

        protected ReviewService([NotNull] IReviewApi reviewApiImplementation)
        {
            ReviewApiImplementation = reviewApiImplementation ?? throw new ArgumentNullException(nameof(reviewApiImplementation));
        }

        public Task<ReviewsPage> Get(string recipeId, string start, int size)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            if (start == null) throw new ArgumentNullException(nameof(start));
            if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
            return ReviewApiImplementation.Get(recipeId, start, size).Success(page =>
            {
                page.RecipeId = recipeId;
                return page;
            });
        }

        public Task Create(string recipeId, Review review)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            if (review == null) throw new ArgumentNullException(nameof(review));
            return ReviewApiImplementation.Create(recipeId, review);
        }

        public Task Update(string recipeId, Review review)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            if (review == null) throw new ArgumentNullException(nameof(review));
            return ReviewApiImplementation.Update(recipeId, review);
        }

        public Task Delete(string recipeId)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            return ReviewApiImplementation.Delete(recipeId);
        }
    }
}