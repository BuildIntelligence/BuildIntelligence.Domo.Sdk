using System;
using System.Collections.Generic;
using System.Text;

namespace BiDomoDotNet.Datasets
{
	public class DatasetSchemaBase : IDatasetSchema
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int Rows { get; set; }
		public Schema Schema { get; set; }
	}
}
