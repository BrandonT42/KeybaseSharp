using System;

namespace KenBonny.KeybaseSharp.Model
{
    public class Ctime
    {
        public DateTime DateTime { get; set; }

        public DateTime DateTimeLocal { get; set; }

        public Ctime(long ctime)
        {
            var span = TimeSpan.FromTicks(ctime * TimeSpan.TicksPerSecond);
            DateTime = new DateTime(1970, 1, 1).Add(span);
            DateTimeLocal = TimeZone.CurrentTimeZone.ToLocalTime(DateTime);
        }

        public static implicit operator Ctime(long ctime)
        {
            return new Ctime(ctime);
        }
    }
}