using System;

namespace BuildIntelligence.Domo.Sdk.Streams
{
    public class StreamExecution
	{
		public int Id { get; set; }
		public DateTime StartedAt { get; set; }
		public string CurrentState { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime ModifiedAt { get; set; }
	}
}
