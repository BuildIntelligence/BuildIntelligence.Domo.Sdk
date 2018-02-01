using System;
using System.Collections.Generic;
using System.Text;

namespace BiDomoDotNet.Streams
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
