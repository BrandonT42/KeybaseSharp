using System.Collections.Generic;

namespace KenBonny.KeybaseSharp.Model
{
    public class UserLookup : BaseObject
    {
        public IEnumerable<KeybaseUser> Them { get; set; }
    }
}