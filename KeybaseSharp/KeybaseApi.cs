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
        /// Set the HttpClientHandler that will be used by the HttpClient to connect to the Keybase API.
        /// </summary>
        public static HttpClientHandler HttpClientHandler = new HttpClientHandler();

        private static readonly Uri BaseLocation = new Uri("https://keybase.io/");

        /// <summary>
        /// Get the parsed result from Keybase.
        /// </summary>
        internal static async Task<T> Get<T>(string address)
        {
            var json = await Get(address);
            return JsonConvert.DeserializeObject<T>(json);
        }

        /// <summary>
        /// Get the raw result from Keybase
        /// </summary>
        internal static async Task<string> Get(string address)
        {
            using (var client = new HttpClient(HttpClientHandler))
            {
                client.BaseAddress = BaseLocation;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(address);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}