namespace Count4U.Model
{
	public static class FolderName
	{
		public const string inData = @"inData";
		public const string Inventor = @"Inventor";

	}
	public enum ImportDomainEnum
	{
		ImportInventProduct = 0,
		ImportDocumentHeader = 1,
		ImportMakat = 2,
		ImportItur = 3,
		ImportSession = 4,
		ImportLocation = 5,
		ImportCatalog = 6,
		ImportSupplier = 7,
		ImportParentMakat = 8,
		ImportParentCatalog = 9,
		ExistMakat = 10,
		ExistItur = 11,
		ExistBarcode = 12,
		ImportDBCatalog = 13,
		ImportParentProduct = 14,
		MakatApplyMask = 15,
		BarcodeApplyMask = 16,
		ExportCatalog = 18,
		ExportItur = 19,
		ExportUserIni = 20,
		ExportCustomerConfig = 21,
		ClearInventProduct = 22,
		ClearDocumentHeader = 23,
		ClearItur = 24,
		ClearSession = 25,
		ClearLocation = 26,
		ClearProduct = 27,
		ClearSupplier = 28,
		ExportInventProduct = 29,
		ExportSumInventProduct = 30,
		ExportCatalogERP = 31,
		ExportCatalogPDA = 32,
		ExportReport = 33,
		Any = 50,
		None = 51,
		ImportSection = 52,
		UpdateCatalog = 53,
		ImportBranch = 54,
		PrintReport = 55,
		ImportParentProductAdvanced,
		ExportInventProductByLocationCode,
		ExportInventProductByIturCode,
		ExportInventProductW,
		ImportUnitPlan,
		ImportIturAnalyzes,
		UploadCatalog,
		ImportFamily,
		ExportInventProductGroupByItur,
		ExportInventProductGroupHeaderByItur,
		ExportInventProductGroupNotHeaderByItur,
		ExportInventProductNotHeader,
		SortInventProductByItur,
		UnitTypeCodeContains,
		IncludeProductMakatWithoutInventProduct,
		SectionCodeContains,
		TagContains,
		IncludeIPIfContansOnlyOneItur,
		IturERPCodeContains,
		ProductNameContains,
		IturCodeContains,
		ChangeMakat2Barcode,
		ImportShelf,
		FullDataFromContains,
		NameAndBalanceOriginalERPAndCountInParentPackAndPriceContains,
		ExistCode,
		ImportСurrentInventory,
		ExportCurrentInventorExtended,
		ExportCurrentInventoryAdvanced,
		RefillMakatDictionary,
		ExistDocumentHeader,
		ClearByDomainObjectType,
		DontRefillProductMakatDictionary,
		FamilyCodeContains,
		ExistPreviousInventory,
		ComplexOperation
	}

	public class DomainUnknownCode
	{
		public const string UnknownSection = "none";
		public const string UnknownLocation = "none";
		public const string UnknownSupplier = "none";
		public const string UnknownStatus = "none";
		public const string UnknownUnitPlan = "none";
		public const string UnknownFamily = "none";
		public const string UnknownUnitType = "none";
		public const string UnknownDevice = "none";
		public const string UnknownPropertyStr = "none";
		public const string Unknown = "none";



	}

	public class DomainUnknownName
	{
		public static string UnknownSection = "UnknownSection";
		public static string UnknownSupplier = "UnknownSupplier";
		public static string UnknownLocation = "UnknownLocation";
		public static string UnknownUnitType = "UnknownUnitType";
		public static string UnknownFamily = "UnknownFamily";
		public static string UnknownDevice = "UnknownDevice";
		public static string UnknownWorker = "UnknownWorker";
		public static string UnknownPropertyStr = "UnknownPropertyStr";
	}
}
