using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NUnit.Framework;
using Refit;
using ReGenSDK.Tests.Auth;

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
            var response = await authProvider.SignIn(apiKey,
                emailPasswordCredentials);
//            Console.WriteLine(response.IdToken);
            var token = response.IdToken;
            var client = new ReGenClient("https://regenapi.azurewebsites.net", () => Task.FromResult($"Bearer {token}"));
            try
            {
                var recipe = await client.Recipes.Get("-LdC5Prcr9aussFzdYYs");
                Console.WriteLine(recipe);
            }
            catch (ApiException e)
            {
                Console.WriteLine(e.RequestMessage.RequestUri);
                throw;
            }

        }
    }
}