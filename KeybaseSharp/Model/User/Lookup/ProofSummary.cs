using System.Collections.Generic;

namespace KenBonny.KeybaseSharp.Model.User.Lookup
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