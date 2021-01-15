using System.Collections.Generic;
using Newtonsoft.Json;

namespace Logic.Models
{
    public class Identifier
    {
        public string identifier { get; set; }
        public int index { get; set; }
        public string mediaType { get; set; }
        public string file { get; set; }
        public string identifierType { get; set; }
        public int identifierExpiresInSeconds { get; set; }
    }

    public class Element
    {
        public List<Identifier> identifiers { get; set; }
    }

    public class DisplayImage
    {
        public List<Element> elements { get; set; }
    }

    public class ProfilePicture
    {
        [JsonProperty("displayImage~")]
        public DisplayImage DisplayImage { get; set; }
    }

    public class LinkedInUserData
    {
        [JsonProperty(PropertyName = "id")]
        public string id { get; set; }
        [JsonProperty(PropertyName = "localizedFirstName")]
        public string localizedFirstName { get; set; }
        [JsonProperty(PropertyName = "localizedLastName")]
        public string localizedLastName { get; set; }
        [JsonProperty(PropertyName = "localizedHeadline")]
        public string localizedHeadline { get; set; }
        [JsonProperty(PropertyName = "profilePicture")]
        public ProfilePicture profilePicture { get; set; }
    }
}
