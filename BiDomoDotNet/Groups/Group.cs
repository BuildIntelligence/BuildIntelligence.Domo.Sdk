using System;
using System.Collections.Generic;
using System.Text;

namespace BiDomoDotNet.Groups
{
	public class Group : GroupBase
	{
		public bool Default { get; set; }
		public bool Active { get; set; }
		public string CreatorId { get; set; }
		public int MemberCount { get; set; }
		public List<int> UserIds { get; set; }
	}
}
