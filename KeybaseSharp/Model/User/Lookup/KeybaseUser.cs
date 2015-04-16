using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.User.Lookup
{
    public class KeybaseUser
    {
        // todo implement cryptocurrencyaddress and devices
        public string Id { get; set; }
        
        public Basics Basics { get; set; }
        
        public InvitationStats InvitationStats { get; set; }
        
        public Profile Profile { get; set; }
        
        public Emails Emails { get; set; }
        
        [JsonProperty(PropertyName = "billing_and_quotas")]
        public BillingAndQuotas BillingAndQuotas { get; set; }
        
        [JsonProperty(PropertyName = "public_keys")]
        public PublicKeys PublicKeys { get; set; }
        
        [JsonProperty(PropertyName = "private_keys")]
        public PrivateKeys PrivateKeys { get; set; }
        
        [JsonProperty(PropertyName = "proofs_summary")]
        public ProofSummary ProofSummary { get; set; }

        //[JsonProperty(PropertyName = "cryptocurrency_addresses")]
        //public CryptocurrencyAddresses CryptocurrencyAddresses { get; set; }
        
        public Pictures Pictures { get; set; }
        
        [JsonProperty(PropertyName = "sigs")]
        public Signatures Signatures { get; set; }
        //public Devices Devices { get; set; }
    }
}