﻿using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KenBonny.KeybaseSharp.Model;
using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp
{
    public class User
    {
        private static readonly string SpecificAddress = string.Format("_/api/{0}/user/lookup.json", KeybaseApi.Version);

        public async Task<UserLookup> LookupAsync(IEnumerable<string> usernames, ProofType proofType)
        {
            HttpResponseMessage userLookupResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = KeybaseApi.BaseLocation;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                userLookupResponse =
                    await
                        client.GetAsync(string.Format("{0}?{1}={2}", SpecificAddress, GetProofTypeDescription(proofType),
                            string.Join(",", usernames)));
            }
            userLookupResponse.EnsureSuccessStatusCode();

            var userLookupJson = await userLookupResponse.Content.ReadAsStringAsync();
            var userLookup = JsonConvert.DeserializeObject<UserLookup>(userLookupJson);
            return userLookup;
        }

        private string GetProofTypeDescription(ProofType proofType)
        {
            if (proofType == ProofType.KeyFingerprint)
                return "key_fingerprint";

            return proofType.ToString().ToLower();
        }
    }
}
