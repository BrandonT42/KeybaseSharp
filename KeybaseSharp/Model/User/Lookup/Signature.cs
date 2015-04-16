using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.User.Lookup
{
    public class Signature
    {
        [JsonProperty(PropertyName = "sig_id")]
        public string SignatureId { get; set; }

        [JsonProperty(PropertyName = "seqno")]
        public int SequenceNumber { get; set; }

        [JsonProperty(PropertyName = "payload_hash")]
        public string PayloadHash { get; set; }
    }
}