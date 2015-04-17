using System.Collections.Generic;
using System.Threading.Tasks;
using KenBonny.KeybaseSharp.Model;
using KenBonny.KeybaseSharp.Model.User.Autocomplete;
using KenBonny.KeybaseSharp.Model.User.Lookup;

namespace KenBonny.KeybaseSharp
{
    public class User
    {
        /// <summary>
        /// Look a user up on Keybase.
        /// </summary>
        /// <param name="username">Specify the username you want to look for.</param>
        public async Task<LookupSingle> LookupAsync(string username)
        {
            var address = string.Format("_/api/{0}/user/lookup.json?username={1}"
                , KeybaseApi.Version
                , username);

            return await KeybaseApi.Get<LookupSingle>(address);
        }
        /// <summary>
        /// Look an identity up on Keybase.
        /// </summary>
        /// <param name="identity">Specify the username you want to look for 
        /// (can be a twitter handle, reddit login, etc.).</param>
        /// <param name="proofType">The type of username provided.</param>
        /// <returns>The details of a user on Keybase.</returns>
        public async Task<LookupMultiple> LookupAsync(string identity, ProofType proofType)
        {
            var address = string.Format("_/api/{0}/user/lookup.json?{1}={2}"
                , KeybaseApi.Version
                , GetProofTypeDescription(proofType)
                , identity);

            return await KeybaseApi.Get<LookupMultiple>(address);
        }

        /// <summary>
        /// Look up multiple users.
        /// If you pass in a list with N names, you will get back a matching N-sized array,
        ///  but with null for any users who could not be found.We imagine this is easier to deal with.
        /// No need to specify a prooftype for this method, you will always specify usernames.
        /// </summary>
        /// <param name="usernames">Specify the usernames you want to look for.</param>
        /// <returns>The details of the users on Keybase.</returns>
        public async Task<LookupMultiple> LookupAsync(IEnumerable<string> usernames)
        {
            var address = string.Format("_/api/{0}/user/lookup.json?usernames={1}"
                , KeybaseApi.Version
                , string.Join(",", usernames));

            return await KeybaseApi.Get<LookupMultiple>(address);
        }

        /// <summary>
        /// Autocomplete will only return up to 10 matching results for a search string of your choice,
        ///  although it will focus on the best matches in can find.
        /// </summary>
        /// <param name="searchTerm">Can match Keybase usernames, full names, identity usernames, and key fingerprints.</param>
        /// <returns></returns>
        public async Task<Autocomplete> AutocompleteAsync(string searchTerm)
        {
            var address = string.Format("_/api/{0}/user/autocomplete.json?q={1}", KeybaseApi.Version, searchTerm);

            return await KeybaseApi.Get<Autocomplete>(address);
        }

        /// <summary>
        /// Fetches the users public key.
        /// </summary>
        /// <param name="username">The user whose key we should fetch.</param>
        /// <returns>The public PGP key.</returns>
        public async Task<string> Key(string username)
        {
            var address = string.Format("{0}/key.asc", username);

            return await KeybaseApi.Get(address);
        }

        private string GetProofTypeDescription(ProofType proofType)
        {
            if (proofType == ProofType.KeyFingerprint)
                return "key_fingerprint";

            return proofType.ToString().ToLower();
        }
    }
}
