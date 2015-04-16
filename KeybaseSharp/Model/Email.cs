using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model
{
    public class Email
    {
        [JsonProperty(PropertyName = "email")]
        public string Address { get; set; }

        [JsonProperty(PropertyName = "is_verified")]
        public int IsVerified { get; set; }
    }
}