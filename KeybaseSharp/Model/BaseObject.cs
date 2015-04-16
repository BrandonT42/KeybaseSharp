namespace KenBonny.KeybaseSharp.Model
{
    public abstract class BaseObject
    {
        public Status Status { get; set; }

        public string CsrfToken { get; set; }
    }
}