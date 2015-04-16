using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.User.Lookup
{
    public class Basics
    {
        public string Username { get; set; }

        public Ctime Ctime { get; set; }
        
        public Ctime Mtime { get; set; }

        [JsonProperty(PropertyName = "id_version")]
        public int IdVersion { get; set; }

        [JsonProperty(PropertyName = "track_version")]
        public int TrackVersion { get; set; }

        [JsonProperty(PropertyName = "last_id_change")]
        public long LastIdChange { get; set; }
        
        public string Salt { get; set; }
    }
}