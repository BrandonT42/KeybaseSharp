using System;

namespace KenBonny.KeybaseSharp
{
    public class Keybase
    {
        private static readonly Uri LookupLocation = new Uri(KeybaseApi.BaseLocation, "_/api/1.0/user/lookup.json");

        public LookupObject Lookup()
        {
            
        }
    }
}
