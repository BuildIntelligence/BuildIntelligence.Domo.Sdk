using System;
using System.Collections.Generic;
using System.Text;

namespace BiDomoDotNet.Datasets
{
	public class Schema
	{
		public List<Column> Columns { get; set; }
	}

	public class Column
	{
		public string Type { get; set; }
		public string Name { get; set; }
	}
}
