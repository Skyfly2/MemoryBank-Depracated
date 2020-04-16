using System;
using Newtonsoft.Json;
namespace MemoryBank
{
    public class Note
    {
        [JsonProperty(PropertyName = "id")]
        public string id;

        [JsonProperty(PropertyName = "content")]
        public string content;

        [JsonProperty(PropertyName = "title")]
        public string title;
    }
}
