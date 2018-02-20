using System;
using System.Collections.Generic;
using System.Text;

namespace BuildIntelligence.Domo.Sdk.Datasets
{
	public interface IDatasetSchema
	{
		string Name { get; set; }
		string Description { get; set; }
		int Rows { get; set; }
		Schema Schema { get; set; }
	}
}
