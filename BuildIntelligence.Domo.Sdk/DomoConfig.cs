using System;

namespace BuildIntelligence.Domo.Sdk
{
    public class DomoConfig : IDomoConfig
	{
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }
		public Uri ApiHost { get; set; } = new Uri("https://api.domo.com/");
		public DomoAuthScope Scope { get; set; }
	}

	[Flags]
	public enum DomoAuthScope
	{
		None = 0x0,
		User = 0x1,
		Data = 0x2
	}
}
