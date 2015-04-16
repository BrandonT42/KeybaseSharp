using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model.User.Lookup
{
    public class Plan
    {
        [JsonProperty(PropertyName = "plan_id")]
        public string PlanId { get; set; }

        [JsonProperty(PropertyName = "plan_name")]
        public string PlanName { get; set; }

        [JsonProperty(PropertyName = "price_pennies")]
        public int PricePennies { get; set; }

        public int Gigabytes { get; set; }
        
        [JsonProperty(PropertyName = "num_groups")]
        public int NumGroups { get; set; }

        [JsonProperty(PropertyName = "folders_with_writes")]
        public int FoldersWithWrites { get; set; }

        [JsonProperty(PropertyName = "billing_status")]
        public int BillingStatus { get; set; }

        [JsonProperty(PropertyName = "test_mode")]
        public object TestMode { get; set; }
    }
}