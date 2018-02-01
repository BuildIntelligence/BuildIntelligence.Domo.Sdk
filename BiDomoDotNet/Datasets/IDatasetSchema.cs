using System;
using System.Collections.Generic;
using System.Text;

namespace BiDomoDotNet.Datasets
{
	public interface IDatasetSchema
	{
		string Name { get; set; }
		string Description { get; set; }
		int Rows { get; set; }
		Schema Schema { get; set; }
	}
}
