﻿using System;
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

        /// <summary>
        /// The HttpClient that will make the call to the webservice.
        /// </summary>
        public static HttpClient HttpClient = new HttpClient(HttpClientHandler, false);

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
        /// Get the raw result from Keybase.
        /// </summary>
        internal static async Task<string> Get(string address)
        {
            if (HttpClient.BaseAddress == null)
            {
                HttpClient.BaseAddress = BaseLocation;
                HttpClient.DefaultRequestHeaders.Accept.Clear();
                HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }

            var response = await HttpClient.GetAsync(address);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}