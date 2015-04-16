using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model
{
    public class Key
    {
        public string Kid { get; set; }
        
        [JsonProperty(PropertyName = "key_type")]
        public int KeyType { get; set; }

        public string Bundle { get; set; }
        
        public Ctime Mtime { get; set; }
        
        public Ctime Ctime { get; set; }
        
        public string Ukbid { get; set; }

        [JsonProperty(PropertyName = "key_fingerprint")]
        public string KeyFingerprint { get; set; }

        [JsonProperty(PropertyName = "key_bits")]
        public int KeyBits { get; set; }

        [JsonProperty(PropertyName = "key_algo")]
        public int KeyAlgo { get; set; }

        [JsonProperty(PropertyName = "signing_kid")]
        public string SigningKid { get; set; }

        [JsonProperty(PropertyName = "key_level")]
        public int KeyLevel { get; set; }

        public object Etime { get; set; }

        [JsonProperty(PropertyName = "eldest_kid")]
        public object EldestKid { get; set; }

        public int Status { get; set; }

        [JsonProperty(PropertyName = "self_signed")]
        public bool SelfSigned { get; set; }
    }
}