using System.Collections.Generic;
using System.Threading.Tasks;
using KenBonny.KeybaseSharp.Model.Authentication;

namespace KenBonny.KeybaseSharp
{
    internal static class Authentication
    {
        /// <summary>
        /// The user presents a username or email address to the server, and the server responds with the salt.
        /// </summary>
        /// <param name="username">Username or email address.</param>
        /// <returns>A salt.</returns>
        internal static Task<Salt> GetSaltAsync(string username)
        {
            var address = string.Format("_/api/1.0/getsalt.json?email_or_username={0}", username);

            return KeybaseApi.Get<Salt>(address);
        }

        internal static Task<Login> LoginAsync(string username, Password password, string session)
        {
            const string address = "_/api/1.0/login.json";

            var parameters = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("email_or_username", username),
                new KeyValuePair<string, string>("hmac_pwh", password.ToString()),
                new KeyValuePair<string, string>("login_session", session)
            };

            return KeybaseApi.Post<Login>(address, parameters);
        } 
    }
}