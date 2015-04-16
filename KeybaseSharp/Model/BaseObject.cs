using Newtonsoft.Json;

namespace KenBonny.KeybaseSharp.Model
{
    public abstract class BaseObject
    {
        [JsonProperty(PropertyName = "guest_id")]
        public string GuestId { get; set; }

        public Status Status { get; set; }

        [JsonProperty(PropertyName = "csrf_token")]
        public string CsrfToken { get; set; }
    }
}