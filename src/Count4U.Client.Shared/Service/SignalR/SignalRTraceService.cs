using System.Collections.Generic;

namespace Count4U.Client.Shared.Service
{
	public interface ISignalRTraceService
	{
		List<string> Messages { get; set; }

	}

	public class SignalRTraceService : ISignalRTraceService
	{
		public List<string> Messages { get; set; }

		public SignalRTraceService()
		{
			if (this.Messages == null)
				this.Messages = new List<string>();
		}

	}
}
