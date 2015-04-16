using System.Collections.Generic;

namespace KenBonny.KeybaseSharp.Model.User.Lookup
{
    public class Status
    {
        public int Code { get; set; }

        public string Desc { get; set; }
        
        public Dictionary<string, string> Fields { get; set; }
        
        public string Name { get; set; }
    }
}