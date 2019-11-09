using System;
using System.Threading.Tasks;
using Firebase.Auth;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using ReGenSDK.Firebase;
using ReGenSDK.Service;
using ReGenSDK.Service.Api;
using ReGenSDK.Service.Impl;

namespace ReGenSDK
{
    [UsedImplicitly]
    public class ReGenClient
    {
        private readonly string _endPoint;
        private readonly RefitSettings _refitSettings;

        public ReGenClient(string endPoint) : this(endPoint, () =>
        {
            var user = FirebaseAuth.DefaultInstance.CurrentUser;
            if (user == null)
            {
                throw new ArgumentNullException($"FirebaseAuth.CurrentUser");
            }
            return user.TokenAsync(false);
        })
        {
        }

        public ReGenClient(string endPoint, Func<Task<string>> authorizationProvider)
        {
            _endPoint = endPoint;
            _refitSettings = new RefitSettings
            {
                AuthorizationHeaderValueGetter = authorizationProvider,
                ContentSerializer = new JsonContentSerializer(
                    new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver()
                    })
            };
        }
        
        public AuthenticationService Authentication => new AuthenticationService();

        public FavoriteService Favorites =>
            new FavoriteServiceImpl(RestService.For<IFavoriteApi>(_endPoint + "/api/Favorites", _refitSettings));

        public RatingService Ratings =>
            new RatingServiceImpl(RestService.For<IRatingApi>(_endPoint + "/api/Ratings", _refitSettings));
        
        public RecipeService Recipes =>
            new RecipeServiceImpl(RestService.For<IRecipeApi>(_endPoint + "/api/Recipes", _refitSettings));

        public ReviewService Reviews =>
            new ReviewServiceImpl(RestService.For<IReviewApi>(_endPoint + "/api/Reviews", _refitSettings));

        public SearchService Search =>
            new SearchServiceImpl(RestService.For<ISearchApi>(_endPoint + "/api/Search", _refitSettings));

        
    }
}