namespace Monitor.Service.Model
{
	public interface ICount4uContext
	{
		string ProcessCode { get; set; }
		string CustomerCode { get; set; }
		string BranchCode { get; set; }
		string InventorCode { get; set; }
		string DBPath { get; set; }

	}
	public class Count4uContext : ICount4uContext
	{
		public string ProcessCode { get; set; }
		public string CustomerCode { get; set; }
		public string BranchCode { get; set; }
		public string InventorCode { get; set; }
		public string DBPath { get; set; }

		public Count4uContext()
		{
			this.ProcessCode = "";
			this.CustomerCode = "";
			this.BranchCode = "";
			this.InventorCode = "";
			this.DBPath = "";
		}
	}

	
}