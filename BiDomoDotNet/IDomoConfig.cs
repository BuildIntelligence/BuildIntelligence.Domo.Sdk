using System;
using System.Collections.Generic;
using System.Text;

namespace BiDomoDotNet
{
	public interface IDomoConfig
	{
		string ClientId { get; set; }
		string ClientSecret { get; set; }
		Uri ApiHost { get; set; }
		DomoAuthScope Scope { get; set; }
		HttpLoggingLevel HttpLogging { get; set; }
	}
}
