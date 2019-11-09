using System;
using System.Threading.Tasks;
using Firebase.Auth;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Refit;
using ReGenSDK.Service;
using ReGenSDK.Service.Api;
using ReGenSDK.Service.Impl;

namespace ReGenSDK
{
    [UsedImplicitly]
    public class ReGenClient
    {
        public static ReGenClient Instance
        {
            get => _instance;
            set
            {
                if (_instance != null) throw new InvalidOperationException();
                _instance = value;
            }
        }

        private readonly string _endpoint;
        private readonly RefitSettings _refitSettings;
        private static ReGenClient _instance;


        public static ReGenClient Initialize([NotNull] string endpoint)
        {
            return Initialize(endpoint, () =>
            {
                var user = FirebaseAuth.DefaultInstance.CurrentUser;
                if (user == null)
                {
                    throw new ArgumentNullException($"FirebaseAuth.CurrentUser");
                }

                return user.TokenAsync(false);
            });
        }

        public static ReGenClient Initialize([NotNull] string endpoint,
            [NotNull] Func<Task<string>> authorizationProvider)
        {
            if (endpoint == null) throw new ArgumentNullException(nameof(endpoint));
            if (authorizationProvider == null) throw new ArgumentNullException(nameof(authorizationProvider));
            return new ReGenClient(endpoint, authorizationProvider);
        }

        public ReGenClient(string endpoint, Func<Task<string>> authorizationProvider)
        {
            _endpoint = endpoint;
            _refitSettings = new RefitSettings
            {
                AuthorizationHeaderValueGetter = authorizationProvider,
                ContentSerializer = new JsonContentSerializer(
                    new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver()
                    })
            };
            if (Instance == null)
                Instance = this;
        }

        public AuthenticationService Authentication => new AuthenticationServiceImpl();

        public FavoriteService Favorites =>
            new FavoriteServiceImpl(RestService.For<IFavoriteApi>(_endpoint + "/api/Favorites", _refitSettings));

        public RatingService Ratings =>
            new RatingServiceImpl(RestService.For<IRatingApi>(_endpoint + "/api/Ratings", _refitSettings));

        public RecipeService Recipes =>
            new RecipeServiceImpl(RestService.For<IRecipeApi>(_endpoint + "/api/Recipes", _refitSettings));

        public ReviewService Reviews =>
            new ReviewServiceImpl(RestService.For<IReviewApi>(_endpoint + "/api/Reviews", _refitSettings));

        public SearchService Search =>
            new SearchServiceImpl(RestService.For<ISearchApi>(_endpoint + "/api/Search", _refitSettings));
    }
}