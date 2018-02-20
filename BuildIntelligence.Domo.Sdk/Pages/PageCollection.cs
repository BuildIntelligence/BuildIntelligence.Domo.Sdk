using System;
using System.Collections.Generic;
using System.Text;

namespace BuildIntelligence.Domo.Sdk.Pages
{
	public class PageCollection
	{
		public IEnumerable<PageInfo> PageInformation { get; set; }
	}

	public class PageInfo
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public IEnumerable<int> CardIds { get; set; }
	}
}
