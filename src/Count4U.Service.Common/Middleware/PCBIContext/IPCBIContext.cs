namespace Count4U.Service.Common
{
	public interface IPCBIContext
	{
		string ProcessCode { get; set; }
		string CustomerCode { get; set; }

		string BranchCode { get; set; }
		string InventorCode { get; set; }

		string DBPath { get; set; }

	}
}