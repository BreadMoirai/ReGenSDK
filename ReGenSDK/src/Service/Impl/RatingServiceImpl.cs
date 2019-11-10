using ReGenSDK.Service.Api;

namespace ReGenSDK.Service.Impl
{
    class RatingServiceImpl : RatingService
    {
        public RatingServiceImpl(IRatingApi ratingApiImplementation) : base(ratingApiImplementation)
        {
        }
    }
}