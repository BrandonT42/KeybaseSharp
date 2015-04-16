using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KenBonny.KeybaseSharp.Model;
using KenBonny.KeybaseSharp.Model.User.Lookup;
using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp
{
    public class User
    {
        private static readonly string SpecificAddress = string.Format("_/api/{0}/user/lookup.json", KeybaseApi.Version);

        /// <summary>
        /// Look a user up on Keybase.
        /// </summary>
        /// <param name="username">Specify the username you want to look for 
        /// (can be a twitter handle, reddit login, etc.).</param>
        /// <param name="proofType">The type of username provided.</param>
        /// <returns>The details of a user on Keybase.</returns>
        public Task<UserLookup> LookupAsync(string username, ProofType proofType)
        {
            return LookupAsync(new[] {username}, proofType);
        }

        /// <summary>
        /// Look multilpe users up on Keybase.
        /// </summary>
        /// <param name="usernames">Specify the usernames you want to look for 
        /// (can be a twitter handle, reddit login, etc.). Do not mix different types of usernames,
        ///  all usernames or all twitter handles.</param>
        /// <param name="proofType">The type of usernames provided.</param>
        /// <returns>The details of the users on Keybase.</returns>
        public async Task<UserLookup> LookupAsync(IEnumerable<string> usernames, ProofType proofType)
        {
            HttpResponseMessage userLookupResponse;

            using (var client = new HttpClient())
            {
                client.BaseAddress = KeybaseApi.BaseLocation;
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var address = string.Format("{0}?{1}={2}", SpecificAddress, GetProofTypeDescription(proofType),
                    string.Join(",", usernames));
                userLookupResponse = await client.GetAsync(address);
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
