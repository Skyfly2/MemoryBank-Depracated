using System;
using Newtonsoft.Json;

namespace MemoryBank
{
	public class LoginInfo
	{
		[JsonProperty(PropertyName = "id")]
		public string Id { get; set; }

		[JsonProperty(PropertyName = "Email")]
		public string Email { get; set; }

		[JsonProperty(PropertyName = "Pass")]
		public string Pass { get; set; }

		[JsonProperty(PropertyName = "First")]
		public string First { get; set; }

        [JsonProperty(PropertyName = "Last")]
        public string Last { get; set; }
	}
}