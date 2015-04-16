namespace KenBonny.KeybaseSharp.Model
{
    public class Plan
    {
        public string PlanId { get; set; }
        public string PlanName { get; set; }
        public int PricePennies { get; set; }
        public int Gigabytes { get; set; }
        public int NumGroups { get; set; }
        public int FoldersWithWrites { get; set; }
        public int BillingStatus { get; set; }
        public object TestMode { get; set; }
    }
}