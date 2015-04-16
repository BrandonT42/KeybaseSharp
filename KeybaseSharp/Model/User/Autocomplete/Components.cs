using System.Collections.Generic;
using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.User.Autocomplete
{
    public class Components
    {
        public UserHandle Username { get; set; }

        [JsonProperty(PropertyName = "key_fingerprint")]
        public KeyFingerprint KeyFingerprint { get; set; }

        [JsonProperty(PropertyName = "full_name")]
        public UserHandle FullName { get; set; }
        
        public UserHandle Coinbase { get; set; }
        
        public UserHandle Twitter { get; set; }
        
        public UserHandle Github { get; set; }

        public List<Website> Websites { get; set; }
        
        public UserHandle Reddit { get; set; }
    }
}