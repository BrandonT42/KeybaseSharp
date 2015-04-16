namespace KenBonny.KeybaseSharp.Model
{
    public class PublicKeys
    {
        public Key Primary { get; set; }
        public Subkeys Subkeys { get; set; }
        public Sibkeys Sibkeys { get; set; }
        public Families Families { get; set; }
    }
}