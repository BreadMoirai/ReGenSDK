using System;
using System.Linq;
using JetBrains.Annotations;
using ReGenSDK.Model;
using ReGenSDK.Service.Api;

namespace ReGenSDK.Service.Impl
{
    internal class ReviewServiceImpl : ReviewService
    {
        public ReviewServiceImpl(IReviewApi reviewApiImplementation) : base(reviewApiImplementation)
        {
        }

        public override IPaginator<Review, string> Paginated([NotNull] string recipeId, int fetchSize)
        {
            if (recipeId == null) throw new ArgumentNullException(nameof(recipeId));
            if (fetchSize <= 0) throw new ArgumentOutOfRangeException(nameof(fetchSize));
            return new Paginator<Review, string>(list => list.Last().ReviewId, id => Get(recipeId, id, fetchSize));
        }
    }
}