using System.Collections.Generic;
using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.User.Discover
{
    public class DiscoverUsernames : BaseObject
    {
        [JsonProperty(PropertyName = "matches")]
        public List<string> Usernames { get; set; }
    }
}