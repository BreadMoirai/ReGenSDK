# Callbacks

This SDK includes extension methods on tasks for callbacks.
 - @ReGenSDK.Tasks.TaskCallbackExtensions
 
 
 These callbacks are always called on the main thread and can be used as such
 ```c#
ReGenClient.Instance.Recipes.Get("recipeId").Success(async recipe => {
    var name = recipe.Name;
    var reviews = await recipe.Reviews();
    // etc...
});
```

or it can be used async await style with 
 - @ReGenSDK.Tasks.MainThreadTask.Run(System.Func{System.Threading.Tasks.Task})
 
 
```c#
using static ReGenSDK.Tasks.MainThreadTask;

public async Task DoOperation(Recipe recipe) {
    return Run(async () => {
        // code in here is executed on the main thread
        
        // for example
        var rating = await client.Reviews.Get(recipe.Key);
        await client.Reviews.Update(recipe.Key, 1);
    });
}
```
 

