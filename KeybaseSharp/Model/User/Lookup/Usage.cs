using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.User.Lookup
{
    public class Usage
    {
        public int Gigabytes { get; set; }

        [JsonProperty(PropertyName = "num_groups")]
        public int NumGroups { get; set; }

        [JsonProperty(PropertyName = "folders_with_writes")]
        public int FoldersWithWrites { get; set; }
    }
}