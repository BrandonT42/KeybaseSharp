using System.Collections.Generic;

namespace KenBonny.KeybaseSharp.Model.User.Lookup
{
    public class LookupMultiple : BaseObject
    {
        public IEnumerable<KeybaseUser> Them { get; set; }
    }
}