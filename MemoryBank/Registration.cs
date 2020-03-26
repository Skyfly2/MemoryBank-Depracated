using System;
using Newtonsoft.Json;

namespace MemoryBank
{
	public class Registration
	{
		[JsonProperty(PropertyName = "Email")]
		public string Email { get; set; }

		[JsonProperty(PropertyName = "Pass")]
		public string Pass { get; set; }

        [JsonProperty(PropertyName = "ConfirmPass")]
        public string CPass { get; set; }

		[JsonProperty(PropertyName = "First")]
		public string First { get; set; }

        [JsonProperty(PropertyName = "Last")]
        public string Last { get; set; }
	}
}