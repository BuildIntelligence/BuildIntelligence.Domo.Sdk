using System;
using System.Collections.Generic;
using System.Text;

namespace BiDomoDotNet
{
	public class DomoConfig : IDomoConfig
	{
		public string ClientId { get; set; }
		public string ClientSecret { get; set; }
		public Uri ApiHost { get; set; } = new Uri("https://api.domo.com/");
		public DomoAuthScope Scope { get; set; }
		public HttpLoggingLevel HttpLogging { get; set; }
	}

	[Flags]
	public enum DomoAuthScope
	{
		None = 0x0,
		User = 0x1,
		Data = 0x2
	}
	public enum HttpLoggingLevel
	{
		None,
		Error,
		Info,
		Verbose
	}
}
