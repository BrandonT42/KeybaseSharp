namespace KenBonny.KeybaseSharp.Model
{
    public class Them
    {
        public string Id { get; set; }
        public Basics Basics { get; set; }
        public InvitationStats InvitationStats { get; set; }
        public Profile Profile { get; set; }
        public Emails Emails { get; set; }
        public BillingAndQuotas BillingAndQuotas { get; set; }
        public PublicKeys PublicKeys { get; set; }
        public PrivateKeys PrivateKeys { get; set; }
        public ProofsSummary ProofsSummary { get; set; }
        public CryptocurrencyAddresses CryptocurrencyAddresses { get; set; }
        public Pictures Pictures { get; set; }
        public Sigs Sigs { get; set; }
        public Devices Devices { get; set; }
    }
}