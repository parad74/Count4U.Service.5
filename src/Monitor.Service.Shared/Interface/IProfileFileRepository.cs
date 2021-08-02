using System.Collections.Generic;
using System.Threading.Tasks;
using Count4U.Model.SelectionParams;

namespace Monitor.Model.ServiceContract.Interface
{
	public interface IProfileFileRepository
	{
		Monitor.Service.Model.ProfileFiles GetProfileFiles();
		Monitor.Service.Model.ProfileFiles GetTestDataProfileFiles();
		Monitor.Service.Model.ProfileFiles GetProfileFiles(SelectParams selectParams);
		Monitor.Service.Model.ProfileFile GetProfileFile(long id);

		Monitor.Service.Model.ProfileFiles GetCustomersProfileFiles();

		Monitor.Service.Model.ProfileFiles GetBranchesProfileFiles();
		Monitor.Service.Model.ProfileFiles GetBranchesProfileFiles(string customerCode);
	
		Monitor.Service.Model.ProfileFiles GetInventoriesProfileFiles();
		Monitor.Service.Model.ProfileFiles GetInventoriesProfileFilesByCustomerCode(string customerCode);
		Monitor.Service.Model.ProfileFiles GetInventoriesProfileFilesByBranchCode(string branchCode);


		List<string> GetCustomerCodeList();
		List<string> GetBranchCodeList();
		List<string> GetBranchCodeListForCustomer(string customerCode);
		List<string> GetInventorCodeList();
		List<string> GetInventorCodeListForCustomer(string customerCode);
		List<string> GetInventorCodeListForBranch(string branchCode);
	

		Monitor.Service.Model.ProfileFiles GetProfileFilesByParentCode(string parentCode);
		Monitor.Service.Model.ProfileFile GetProfileFileByObjectCode(string objectCode);
		Monitor.Service.Model.ProfileFile GetProfileFileByInventorCode(string objectCode);
		Monitor.Service.Model.ProfileFile GetProfileFileInventor(Monitor.Service.Model.ProfileFile profileFileModel);

		Task Delete(long id);
		Task DeleteAll();
		Task Delete(string objectCode);
		long Insert(Monitor.Service.Model.ProfileFile profileFile);
		Task InsertArray(Monitor.Service.Model.ProfileFile[] profileFileArray);
		Task InsertList(Monitor.Service.Model.ProfileFiles profileFileList);
		Task InsertCustomersBySubFolderList(List<string> customerCodes);
		Task InsertBranchsBySubFolderList(string customerCode, List<string> branchCodes);
		Task InsertInventoriesBySubFolderList(string customerCode, string branchCode, List<string> inventorCodes);
		Monitor.Service.Model.ProfileFile InsertInventoriesByCBI(Monitor.Service.Model.ProfileFile profileFileModel);
		Task Update(Monitor.Service.Model.ProfileFile profileFile);
	}
}
