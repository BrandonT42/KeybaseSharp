using System;

namespace KenBonny.KeybaseSharp.Model.User
{
    public class Ctime
    {
        public DateTime UtcDateTime { get; set; }

        public DateTime LocalDateTime { get; set; }

        public Ctime(long ctime)
        {
            var span = TimeSpan.FromTicks(ctime * TimeSpan.TicksPerSecond);
            UtcDateTime = new DateTime(1970, 1, 1).Add(span);
            LocalDateTime = TimeZone.CurrentTimeZone.ToLocalTime(UtcDateTime);
        }

        public static implicit operator Ctime(long ctime)
        {
            return new Ctime(ctime);
        }
    }
}