using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using Refit;
using ReGenSDK.Tasks;
using ReGenSDK.Tests.Auth;
using static ReGenSDK.Tasks.MainThreadTask;

namespace ReGenSDK.Tests
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public async Task Test1()
        {
            var authProvider = RestService.For<IAuthProvider>("https://identitytoolkit.googleapis.com/v1", new RefitSettings
            {
                ContentSerializer = new JsonContentSerializer(
                    new JsonSerializerSettings
                    {
                        ContractResolver = new DefaultContractResolver()
                    })
            });
            var apiKey = Environment.GetEnvironmentVariable("FIREBASE_API_KEY");
//            Console.WriteLine(apiKey);
            var emailPasswordCredentials = new EmailPasswordCredentials("user@email.com", "password");
            var client = new ReGenClient("https://regenapi.azurewebsites.net", async () =>
            {
                var response = await authProvider.SignIn(apiKey,
                    emailPasswordCredentials);
//                Console.WriteLine(response.IdToken);
                return response.IdToken;
            });
            try
            {
                var recipe = await client.Recipes.Get("-LdC5Prcr9aussFzdYYs");
                Console.WriteLine(recipe.Key);
                var myreview = await client.Reviews.Get(recipe.Key);
                if (myreview == null)
                {
                    Console.WriteLine("null");
                }
                Console.WriteLine(myreview);
            }
            catch (ApiException e)
            {    
                Console.WriteLine(e.StatusCode);
                Console.WriteLine(e.RequestMessage.RequestUri);
                throw;
            }

//            Run(async () => { await Task.CompletedTask; });

        }
    }
}