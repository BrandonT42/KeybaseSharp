using System;
using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.Authentication
{
    public class Salt : BaseObject
    {
        /// <summary>
        /// The salt value.
        /// </summary>
        [JsonProperty(PropertyName = "salt")]
        public string Token { get; set; }

        [JsonProperty(PropertyName = "login_session")]
        public string Session { get; set; }

        [JsonProperty(PropertyName = "pwh_version")]
        public int Version { get; set; }
    }
}