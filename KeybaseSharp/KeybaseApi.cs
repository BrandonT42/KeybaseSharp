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
            HttpResponseMessage userLookupResponse;

            using (var client = new HttpClient(HttpClientHandler))
            {
                client.BaseAddress = BaseLocation;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                userLookupResponse = await client.GetAsync(address);
            }
            userLookupResponse.EnsureSuccessStatusCode();

            var json = await userLookupResponse.Content.ReadAsStringAsync();
            var specific = JsonConvert.DeserializeObject<T>(json);

            return specific;
        }

        /// <summary>
        /// Get the raw result from Keybase
        /// </summary>
        internal static async Task<string> Get(string address)
        {
            HttpResponseMessage userLookupResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = BaseLocation;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                userLookupResponse = await client.GetAsync(address);
            }
            userLookupResponse.EnsureSuccessStatusCode();

            return await userLookupResponse.Content.ReadAsStringAsync();
        }
    }
}