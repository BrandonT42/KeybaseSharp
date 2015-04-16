using System;
using KenBonny.KeybaseSharp.Model;

namespace KenBonny.KeybaseSharp
{
    public class User
    {
        private static readonly Uri LookupLocation = new Uri(KeybaseApi.BaseLocation,
            string.Format("_/api/{0}/user/lookup.json", KeybaseApi.Version));

        public LookupObject Lookup()
        {
            
        }
    }
}
