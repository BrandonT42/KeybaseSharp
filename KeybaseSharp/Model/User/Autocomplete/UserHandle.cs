using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.User.Autocomplete
{
    public class UserHandle
    {
        [JsonProperty(PropertyName = "val")]
        public string Value { get; set; }

        public double Score { get; set; }
    }
}