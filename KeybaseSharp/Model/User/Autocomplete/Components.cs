using System.Collections.Generic;
using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.User.Autocomplete
{
    public class Components
    {
        public UserProof Username { get; set; }

        [JsonProperty(PropertyName = "key_fingerprint")]
        public KeyFingerprint KeyFingerprint { get; set; }

        [JsonProperty(PropertyName = "full_name")]
        public UserProof FullName { get; set; }
        
        public UserProof Coinbase { get; set; }
        
        public UserProof Twitter { get; set; }
        
        public UserProof Github { get; set; }

        public List<Website> Websites { get; set; }
        
        public UserProof Reddit { get; set; }
    }
}