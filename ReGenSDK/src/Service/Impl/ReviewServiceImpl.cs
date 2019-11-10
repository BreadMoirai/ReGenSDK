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
        
    }
}