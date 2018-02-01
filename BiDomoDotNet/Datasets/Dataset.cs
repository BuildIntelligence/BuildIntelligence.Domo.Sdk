using System;
using System.Collections.Generic;
using System.Text;

namespace BiDomoDotNet.Datasets
{
	public class Dataset : DatasetSchemaBase
	{
		//Dataset POCO
		public string Id { get; set; }
		public Owner Owner { get; set; }
		public int Columns { get; set; }
		public string CreatedAt { get; set; }
		public string UpdatedAt { get; set; }
		public string DataCurrentAt { get; set; }
		public bool PdpEnabled { get; set; }
		public List<Policies> Policies { get; set; }
	}

	public class Owner
	{
		public string Id { get; set; }
		public string Name { get; set; }
	}

	public class Policies
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Type { get; set; }
		public List<int> Users { get; set; }
		public List<int> Groups { get; set; }
		public List<Filter> Filters { get; set; }
	}

	public class Filter
	{
		public string Column { get; set; }
		public bool Not { get; set; }
		public string Operator { get; set; }
		public List<string> Values { get; set; }
	}
}
