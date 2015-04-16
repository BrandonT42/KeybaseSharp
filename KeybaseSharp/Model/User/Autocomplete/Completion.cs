using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.User.Autocomplete
{
    public class Completion
    {
        [JsonProperty(PropertyName = "total_score")]
        public double TotalScore { get; set; }

        public Components Components { get; set; }
        
        public string Uid { get; set; }
        
        public string Thumbnail { get; set; }
        
        [JsonProperty(PropertyName = "is_followee")]
        public bool IsFollowee { get; set; }
    }
}