using System.Collections.Generic;

namespace KenBonny.KeybaseSharp.Model
{
    public class ProofsSummary
    {
        public ByProofType ByProofType { get; set; }
        public ByPresentationGroup ByPresentationGroup { get; set; }
        public List<Proof> All { get; set; }
    }
}