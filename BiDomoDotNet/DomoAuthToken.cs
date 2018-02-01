using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BiDomoDotNet
{
    public class DomoAuthToken
    {
		[JsonProperty("access_token")]
		public string Token { get; set; }
		[JsonProperty("token_type")]
		public string Token_type { get; set; }
		[JsonProperty("expires_in")]
		public int Expires_in { get; set; } // Seconds?
		[JsonProperty("scope")]
		public string Scope { get; set; }
		[JsonProperty("customer")]
		public string Customer { get; set; }
		[JsonProperty("env")]
		public string Env { get; set; }
		[JsonProperty("userId")]
		public int UserId { get; set; }
		[JsonProperty("role")]
		public string Role { get; set; }
		[JsonProperty("jti")]
		public string Jti { get; set; }

		[JsonIgnore]
		public DateTime NeedNewTokenAt => NeedToGetNewToken();
		private DateTime NeedToGetNewToken()
		{
			var timeToGetNewToken = DateTime.Now;
			timeToGetNewToken.AddSeconds(Expires_in);
			return timeToGetNewToken;
		}
	}
}
