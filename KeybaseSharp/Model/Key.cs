namespace KenBonny.KeybaseSharp.Model
{
    public class Key
    {
        public string Kid { get; set; }
        public int KeyType { get; set; }
        public string Bundle { get; set; }
        public Ctime Mtime { get; set; }
        public Ctime Ctime { get; set; }
        public string Ukbid { get; set; }
        public string KeyFingerprint { get; set; }
        public int KeyBits { get; set; }
        public int KeyAlgo { get; set; }
        public string SigningKid { get; set; }
        public int KeyLevel { get; set; }
        public object Etime { get; set; }
        public object EldestKid { get; set; }
        public int Status { get; set; }
        public bool SelfSigned { get; set; }
    }
}