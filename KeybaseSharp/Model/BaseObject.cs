namespace KenBonny.KeybaseSharp.Model
{
    public abstract class BaseObject
    {
        public string GuestId { get; set; }

        public Status Status { get; set; }

        public string CsrfToken { get; set; }
    }
}