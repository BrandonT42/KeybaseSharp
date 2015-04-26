using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp
{
    /// <summary>
    /// Set details for the Keybase API connection.
    /// </summary>
    public static class KeybaseApi
    {
        internal const string Version = "1.0";

        /// <summary>
        /// The HttpClient that will make the calls to the Keybase API.
        /// </summary>
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        // ReSharper disable once MemberCanBePrivate.Global
        public static HttpClient HttpClient = new HttpClient();

        /// <summary>
        /// 
        /// </summary>
        public static readonly User User = new User();

        private static readonly Uri BaseLocation = new Uri("https://keybase.io/");

        /// <summary>
        /// Get the parsed result from Keybase.
        /// </summary>
        internal static Task<T> Get<T>(string address)
        {
            var json = Get(address).Result;
            return Task.Factory.StartNew(() => JsonConvert.DeserializeObject<T>(json));
        }

        /// <summary>
        /// Get the raw result from Keybase.
        /// </summary>
        internal static Task<string> Get(string address)
        {
            if (HttpClient.BaseAddress == null)
            {
                HttpClient.BaseAddress = BaseLocation;
                HttpClient.DefaultRequestHeaders.Accept.Clear();
                HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            var response = HttpClient.GetAsync(address).Result;
            response.EnsureSuccessStatusCode();

            return response.Content.ReadAsStringAsync();
        }
    }
}