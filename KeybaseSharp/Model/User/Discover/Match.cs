using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.User.Discover
{
    public class Match
    {
        public string Thumbnail { get; set; }
        
        public string Username { get; set; }
        
        public string Uid { get; set; }

        [JsonProperty(PropertyName = "public_key")]
        public Key PublicKey { get; set; }

        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }
        
        public Ctime Ctime { get; set; }

        [JsonProperty(PropertyName = "remote_proofs")]
        public RemoteProofs RemoteProofs { get; set; }
    }
}