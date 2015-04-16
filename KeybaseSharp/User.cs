using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using KenBonny.KeybaseSharp.Model.User.Autocomplete;
using KenBonny.KeybaseSharp.Model.User.Lookup;
using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp
{
    public class User
    {
        private static readonly string AutocompleteAddress = string.Format("_/api/{0}/user/autocomplete.json?q=",
            KeybaseApi.Version);

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
            var address = string.Format("_/api/{0}/user/lookup.json?{1}={2}"
                , KeybaseApi.Version
                , GetProofTypeDescription(proofType)
                , string.Join(",", usernames));

            return await KeybaseApi.Get<UserLookup>(address);
        }

        /// <summary>
        /// Autocomplete will only return up to 10 matching results for a search string of your choice,
        ///  although it will focus on the best matches in can find.
        /// </summary>
        /// <param name="searchTerm">Can match Keybase usernames, full names, identity usernames, and key fingerprints.</param>
        /// <returns></returns>
        public async Task<UserAutocomplete> AutocompleteAsync(string searchTerm)
        {
            var address = string.Format("_/api/{0}/user/autocomplete.json?q={1}", KeybaseApi.Version, searchTerm);

            return await KeybaseApi.Get<UserAutocomplete>(address);
        }

        private string GetProofTypeDescription(ProofType proofType)
        {
            if (proofType == ProofType.KeyFingerprint)
                return "key_fingerprint";

            return proofType.ToString().ToLower();
        }
    }
}
