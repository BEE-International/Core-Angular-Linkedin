using Newtonsoft.Json;

namespace Logic.Models
{
    public class TokenResponse
    {
        [JsonProperty(PropertyName = "access_token")]
        public string Access_token { get; set; }

        [JsonProperty(PropertyName = "expires_in")]
        public int Expires_in { get; set; }

    }
}
