using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.Authentication
{
    public class Login : BaseObject
    {
        public string Session { get; set; }

        [JsonProperty(PropertyName = "me")]
        public User.User User { get; set; }
    }
}