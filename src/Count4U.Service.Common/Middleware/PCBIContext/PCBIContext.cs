namespace Count4U.Service.Common
{
	public class PCBIContext : IPCBIContext
	{
		public string ProcessCode { get; set; }
		public string CustomerCode { get; set; }
		public string BranchCode { get; set; }
		public string InventorCode { get; set; }
		public string DBPath { get; set; }

		public PCBIContext()
		{
			this.ProcessCode = "";
			this.CustomerCode = "";
			this.BranchCode = "";
			this.InventorCode = "";
			this.DBPath = "";
		}
	}
}