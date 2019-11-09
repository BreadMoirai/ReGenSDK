# Setup
We need to initialize the sdk with the endpoint.
```c#
ReGenClient.Initialize("web api endpoint");
```

The client can then be accessed by it's `Instance` member;

```c#
var client = ReGenClient.Instance;
```

The api can be accessed from it's services;

```c#
var recipes = client.Recipes;
```

View the API reference for more details.
 - @ReGenSDK.Service.AuthenticationService
 - @ReGenSDK.Service.FavoriteService 
 - @ReGenSDK.Service.RatingService 
 - @ReGenSDK.Service.RecipeService 
 - @ReGenSDK.Service.ReviewService 
 - @ReGenSDK.Service.SearchService 
