using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.User.Lookup
{
    public class Profile
    {
        public long Mtime { get; set; }

        [JsonProperty(PropertyName = "full_name")]
        public string FullName { get; set; }
        
        public string Location { get; set; }
        
        public string Bio { get; set; }
    }
}