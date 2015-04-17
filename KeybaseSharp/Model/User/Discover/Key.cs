using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.User.Discover
{
    public class Key
    {
        [JsonProperty(PropertyName = "key_fingerprint")]
        public string KeyFingerprint { get; set; }

        public int Bits { get; set; }

        public int Algo { get; set; }
    }
}