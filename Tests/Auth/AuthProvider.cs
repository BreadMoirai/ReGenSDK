using System.Threading.Tasks;
using Refit;

namespace ReGenSDK.Tests.Auth
{
    public interface IAuthProvider
    {
        [Post("/accounts:signInWithPassword")]
        Task<SignInResponse> SignIn(string key, [Body] EmailPasswordCredentials credentials);
    }

    
    public class EmailPasswordCredentials
    {
        public string email;
        public string password;
        public bool returnSecureToken = true;

        public EmailPasswordCredentials(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
    }

    public class SignInResponse
    {
        public string IdToken;
    }
}