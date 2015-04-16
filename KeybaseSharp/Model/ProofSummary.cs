using System.Collections.Generic;

namespace KenBonny.KeybaseSharp.Model
{
    public class ProofSummary
    {
        //[JsonProperty(PropertyName = "by_proof_type")]
        //public SortedProof ByProofType { get; set; }

        //[JsonProperty(PropertyName = "by_presentation_group")]
        //public SortedProof ByPresentationGroup { get; set; }

        public List<Proof> All { get; set; }
    }
}