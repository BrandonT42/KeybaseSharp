using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.User.Autocomplete
{
    public class UserHandle
    {
        [JsonProperty(PropertyName = "val")]
        public string Value { get; set; }

        public int Score { get; set; }
    }
}