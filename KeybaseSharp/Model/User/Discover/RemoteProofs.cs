using System.Collections.Generic;
using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.User.Discover
{
    public class RemoteProofs
    {
        public List<Dns> Dns { get; set; }
        
        [JsonProperty(PropertyName = "generic_web_site")]
        public List<WebSite> GenericWebSite { get; set; }
        
        public string Twitter { get; set; }
        
        public string Github { get; set; }
        
        public string Reddit { get; set; }

        public string Hackernews { get; set; }

        public string Coinbase { get; set; }
    }
}