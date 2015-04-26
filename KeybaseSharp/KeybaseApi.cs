using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KenBonny.KeybaseSharp.Model;
using KenBonny.KeybaseSharp.Model.Authentication;
using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp
{
    /// <summary>
    /// Set details for the Keybase API connection.
    /// </summary>
    public static class KeybaseApi
    {
        internal const string Version = "1.0";

        private static readonly CookieContainer CookieContainer = new CookieContainer();
        private static readonly HttpClientHandler HttpClientHandler = new HttpClientHandler() { CookieContainer = CookieContainer};

        /// <summary>
        /// The HttpClient that will make the calls to the Keybase API.
        /// </summary>
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        // ReSharper disable once MemberCanBePrivate.Global
        public static HttpClient HttpClient = new HttpClient(HttpClientHandler);

        /// <summary>
        /// 
        /// </summary>
        public static readonly User User = new User();

        private static readonly Uri BaseLocation = new Uri("https://keybase.io/");

        /// <summary>
        /// Get the parsed result from Keybase.
        /// </summary>
        internal static Task<T> Get<T>(string address, bool setCrsfToken = true)
            where T: BaseObject
        {
            var json = Get(address).Result;
            var task = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));

            if (setCrsfToken)
            {
                task.ContinueWith(t =>
                {
                    var result = t.Result;
                    HttpClient.DefaultRequestHeaders.Add("X-CSRF-Token", result.CsrfToken);
                    return result;
                });
            }

            return task;
        }

        /// <summary>
        /// Get the raw result from Keybase.
        /// </summary>
        internal static Task<string> Get(string address)
        {
            return MakeHttpCall(() => HttpClient.GetAsync(address));
        }

        /// <summary>
        /// Send a message to the Keybase API using a POST request.
        /// </summary>
        internal static Task<T> Post<T>(string address, IEnumerable<KeyValuePair<string, string>> parameters)
            where T: BaseObject
        {
            parameters = parameters ?? new KeyValuePair<string, string>[0];

            var content = new FormUrlEncodedContent(parameters);
            var json = MakeHttpCall(() => HttpClient.PostAsync(address, content)).Result;

            return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
        }

        /// <summary>
        /// Authenticate a user so more information can be retrieved and more methods can be used.
        /// </summary>
        public static Task<Login> Authenticate(string username, string password)
        {
            var salt = Authentication.GetSaltAsync(username).Result;
            var securePassword = new Password(password, salt);
            
            var loginTask = Authentication.LoginAsync(username, securePassword, salt.Session);
            loginTask.ContinueWith(task =>
            {
                var login = task.Result;
                if (login.Status.Code.Equals(0))
                {
                    var cookie = new Cookie("Session", login.Session);
                    CookieContainer.Add(cookie);   
                }

                return login;
            });

            return loginTask;
        }

        private static Task<string> MakeHttpCall(Func<Task<HttpResponseMessage>> httpCall)
        {
            if (HttpClient.BaseAddress == null)
            {
                HttpClient.BaseAddress = BaseLocation;
                HttpClient.DefaultRequestHeaders.Accept.Clear();
                HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            var response = httpCall().Result;
            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsStringAsync();
        }
    }
}