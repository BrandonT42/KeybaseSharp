using System.Collections.Generic;
using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model
{
    public class UserAutocomplete
    {
        public List<Completion> Completions { get; set; }
    }

    public class Completion
    {
        [JsonProperty(PropertyName = "total_score")]
        public double TotalScore { get; set; }

        public Components Components { get; set; }
        
        public string Uid { get; set; }
        
        public string Thumbnail { get; set; }
        
        [JsonProperty(PropertyName = "is_followee")]
        public bool IsFollowee { get; set; }
    }

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

    public class UserProof
    {
        public string Val { get; set; }

        public int Score { get; set; }
    }

    public class KeyFingerprint : UserProof
    {
        public int Algo { get; set; }

        public int Nbits { get; set; }
    }

    public class Website : UserProof
    {
        public string Protocol { get; set; }
    }
}