using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using JetBrains.Annotations;
using ReGenSDK.Model;
using ReGenSDK.Service.Api;
using ReGenSDK.Tasks;

namespace ReGenSDK.Service
{
    public abstract partial class ReviewService
    {
        protected readonly IReviewApi ReviewApiImplementation;

        internal ReviewService([NotNull] IReviewApi reviewApiImplementation)
        {
            ReviewApiImplementation = reviewApiImplementation ??
                                      throw new ArgumentNullException(nameof(reviewApiImplementation));
        }

        /// <inheritdoc />
        public Task<ReviewsPage> GetPage(string recipeId, string start, int size)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
            return ReviewApiImplementation.GetPage(recipeId, start, size).Success(page =>
            {
                page.RecipeId = recipeId;
                return page;
            });
        }
//
//        public Task<HttpResponse> GetHttp(string recipeId)
//        {
//            return ReviewApiImplementation.GetHttp(recipeId);
//        }

        /// <inheritdoc />
        public Task Create(string recipeId, Review review)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            if (review == null) throw new ArgumentNullException(nameof(review));
            return ReviewApiImplementation.Create(recipeId, review);
        }

        /// <inheritdoc />
        public Task Update(string recipeId, Review review)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            if (review == null) throw new ArgumentNullException(nameof(review));
            return ReviewApiImplementation.Update(recipeId, review);
        }

        /// <inheritdoc />
        public Task Delete(string recipeId)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            return ReviewApiImplementation.Delete(recipeId);
        }

        /// <inheritdoc />
        public Task<Review> Get(string recipeId)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            return ReviewApiImplementation.Get(recipeId);
        }
    }
}