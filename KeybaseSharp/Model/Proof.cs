using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model
{
    public class Proof
    {
        [JsonProperty(PropertyName = "proof_type")]
        public string ProofType { get; set; }

        public string Nametag { get; set; }
        
        public int State { get; set; }

        [JsonProperty(PropertyName = "proof_url")]
        public string ProofUrl { get; set; }

        [JsonProperty(PropertyName = "sig_id")]
        public string SignatureId { get; set; }

        [JsonProperty(PropertyName = "proof_id")]
        public string ProofId { get; set; }

        [JsonProperty(PropertyName = "human_url")]
        public string HumanUrl { get; set; }

        [JsonProperty(PropertyName = "service_url")]
        public string ServiceUrl { get; set; }

        [JsonProperty(PropertyName = "presentation_group")]
        public string PresentationGroup { get; set; }

        [JsonProperty(PropertyName = "presentation_tag")]
        public string PresentationTag { get; set; }
    }
}