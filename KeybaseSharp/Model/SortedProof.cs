using System.Collections.Generic;

namespace KenBonny.KeybaseSharp.Model
{
    public class SortedProof
    {
        public List<Proof> Twitter { get; set; }

        public List<Proof> Github { get; set; }

        public List<Proof> Domain { get; set; }
        
        public List<Proof> Reddit { get; set; }
        
        public List<Proof> HackerNews { get; set; }
        
        public List<Proof> Coinbase { get; set; }
    }
}