using BuildIntelligence.Domo.Sdk.Datasets;
using System;

namespace BuildIntelligence.Domo.Sdk.Streams
{
    public class StreamDataset
	{
		public int Id { get; set; }
		public Dataset Dataset { get; set; }
		public string UpdateMethod { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}

	public class StreamDatasetSchema
	{
		public IDatasetSchema DataSet { get; set; }
		public string UpdateMethod { get; set; }
	}

	public enum UpdateMethod
	{
		APPEND,
		REPLACE
	}

}
