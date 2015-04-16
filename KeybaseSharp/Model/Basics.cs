namespace KenBonny.KeybaseSharp.Model
{
    public class Basics
    {
        public string Username { get; set; }
        public Ctime Ctime { get; set; }
        public Ctime Mtime { get; set; }
        public int IdVersion { get; set; }
        public int TrackVersion { get; set; }
        public Ctime LastIdChange { get; set; }
        public string Salt { get; set; }
    }
}