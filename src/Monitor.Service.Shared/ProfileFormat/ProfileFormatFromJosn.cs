//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Newtonsoft.Json;

//namespace Count4U.Service.Format.Json
//{
//	// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
//	public class Xml
//	{
//		[JsonProperty("@version")]
//		public string Version { get; set; }
//		[JsonProperty("@encoding")]
//		public string Encoding { get; set; }
//	}

//	public class Customer
//	{
//		[JsonProperty("@name")]
//		public string Name { get; set; }
//		[JsonProperty("@code")]
//		public string Code { get; set; }
//	}

//	public class Branch
//	{
//		[JsonProperty("@name")]
//		public string Name { get; set; }
//		[JsonProperty("@code")]
//		public string Code { get; set; }
//	}

//	public class Inventory
//	{
//		[JsonProperty("@code")]
//		public string Code { get; set; }
//		[JsonProperty("@created_date")]
//		public string CreatedDate { get; set; }
//	}

//	public class InventoryProcessInformation
//	{
//		public Customer Customer { get; set; }
//	 	public Branch Branch { get; set; }
//		public Inventory Inventory { get; set; }
//	}

//	public class InventoryProcessMode
//	{
//		public string AssertModeEnabled { get; set; }
//		public string StockModeEnabled { get; set; }
//	}

//	public class InventoryProcessConfiguration
//	{
//		public InventoryProcessMode InventoryProcessMode { get; set; }
//	}

//	public class LocationInventoryListScreenConfiguration
//	{
//		public string AddNewInventoryEnabled { get; set; }
//		public string TemplateInventoriesEnabled { get; set; }
//		public string SignatureToVerifyClosureOfLocationRequired { get; set; }
//		public string AddNewInventoryOfflineEnabled { get; set; }
//	}

//	public class Title
//	{
//		[JsonProperty("@en")]
//		public string En { get; set; }
//		[JsonProperty("@he")]
//		public string He { get; set; }
//	}

//	public class InventoryItemDisplayProperty
//	{
//		[JsonProperty("@id")]
//		public string Id { get; set; }
//		[JsonProperty("@itemtype")]
//		public string Itemtype { get; set; }
//		public Title Title { get; set; }
//		public string invalid { get; set; }
//		public string id { get; set; }
//	}

//	public class InventoryItemsProperties
//	{
//		public List<InventoryItemDisplayProperty> InventoryItemDisplayProperty { get; set; }
//	}

//	public class InventoryListDefaultUIConfiguration
//	{
//		public string ShowInventoryImageIndicator { get; set; }
//		public InventoryItemsProperties InventoryItemsProperties { get; set; }
//	}

//	public class DatabaseSettings
//	{
//		public string UIDKey { get; set; }
//		public string CurrentInventoryDeviceIdProperty { get; set; }
//		public string CurrentInventoryUserNameProperty { get; set; }
//		public string ClearInventoryDataAfterUpload { get; set; }
//		public string CurrentInventoryDeviceNameProperty { get; set; }
//	}

//	public class DataSource
//	{
//		[JsonProperty("@fieldname")]
//		public string Fieldname { get; set; }
//		[JsonProperty("@keyboard_type")]
//		public string KeyboardType { get; set; }
//		[JsonProperty("@tablename")]
//		public string Tablename { get; set; }
//		[JsonProperty("@fieldnametoshow")]
//		public string Fieldnametoshow { get; set; }
//	}

//	public class DataTarget
//	{
//		[JsonProperty("@fieldname")]
//		public string Fieldname { get; set; }
//		[JsonProperty("@tablename")]
//		public string Tablename { get; set; }
//	}

//	public class Details
//	{
//		[JsonProperty("@default")]
//		public string Default { get; set; }
//		[JsonProperty("@id")]
//		public string Id { get; set; }
//		[JsonProperty("@itemtype")]
//		public string Itemtype { get; set; }
//		[JsonProperty("@mandatory")]
//		public string Mandatory { get; set; }
//		[JsonProperty("@type")]
//		public string Type { get; set; }
//		[JsonProperty("@typeview")]
//		public string Typeview { get; set; }
//		[JsonProperty("@viewonly")]
//		public string Viewonly { get; set; }
//		[JsonProperty("@camera_barcode_scanner_enable")]
//		public string CameraBarcodeScannerEnable { get; set; }
//		[JsonProperty("@negative_value_enable")]
//		public string NegativeValueEnable { get; set; }
//		[JsonProperty("@add_enable")]
//		public string AddEnable { get; set; }
//		[JsonProperty("@clear_enable")]
//		public string ClearEnable { get; set; }
//		[JsonProperty("@zero_value_enable")]
//		public string ZeroValueEnable { get; set; }
//	}

//	public class Title2
//	{
//		[JsonProperty("@en")]
//		public string En { get; set; }
//		[JsonProperty("@he")]
//		public string He { get; set; }
//	}

//	public class Description
//	{
//		[JsonProperty("@en")]
//		public string En { get; set; }
//	}

//	public class Titles
//	{
//		public Title2 Title { get; set; }
//		public Description Description { get; set; }
//	}

//	public class Enabled
//	{
//		[JsonProperty("@fieldcondition")]
//		public string Fieldcondition { get; set; }
//	}

//	public class Filter
//	{
//		[JsonProperty("@type")]
//		public string Type { get; set; }
//		[JsonProperty("@value")]
//		public string Value { get; set; }
//		[JsonProperty("@valueToReg")]
//		public string ValueToReg { get; set; }
//	}

//	public class EnabledFiler
//	{
//		public Enabled Enabled { get; set; }
//		public Filter Filter { get; set; }
//	}

//	public class EnabledFilters
//	{
//		public List<EnabledFiler> EnabledFiler { get; set; }
//	}

//	public class Actions
//	{
//		public string SelectInFocus { get; set; }
//		public string AutoGenerateCode { get; set; }
//		public EnabledFilters EnabledFilters { get; set; }
//	}

//	public class Field
//	{
//		public DataSource DataSource { get; set; }
//		public DataTarget DataTarget { get; set; }
//		public Details Details { get; set; }
//		public Titles Titles { get; set; }
//		public string invalid { get; set; }
//		public string id { get; set; }
//		public Actions Actions { get; set; }
//	}

//	public class Form
//	{
//		[JsonProperty("@id")]
//		public string Id { get; set; }
//		public List<Field> Field { get; set; }
//		public string KeepAllFieldsOnItemCodeChange { get; set; }
//	}

//	public class Forms
//	{
//		public Form Form { get; set; }
//	}

//	public class Title3
//	{
//		[JsonProperty("@en")]
//		public string En { get; set; }
//		[JsonProperty("@he")]
//		public string He { get; set; }
//	}

//	public class SearchByProperty
//	{
//		[JsonProperty("@id")]
//		public string Id { get; set; }
//		public Title3 Title { get; set; }
//		public string id { get; set; }
//	}

//	public class SearchByProperties
//	{
//		public List<SearchByProperty> SearchByProperty { get; set; }
//	}

//	public class Title4
//	{
//		[JsonProperty("@en")]
//		public string En { get; set; }
//		[JsonProperty("@he")]
//		public string He { get; set; }
//	}

//	public class SearchDisplayProperty
//	{
//		[JsonProperty("@id")]
//		public string Id { get; set; }
//		public Title4 Title { get; set; }
//		public string invalid { get; set; }
//		public string id { get; set; }
//		[JsonProperty("@he")]
//		public string He { get; set; }
//	}

//	public class SearchByScannerResultListDisplayProperties
//	{
//		public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
//	}

//	public class SearchByScannerScreenConfiguration
//	{
//		public string AddNewInventoryEnabled { get; set; }
//		public string CameraBarcodeScannerEnabled { get; set; }
//		public string NavigateBackEnabled { get; set; }
//		public SearchByProperties SearchByProperties { get; set; }
//		public SearchByScannerResultListDisplayProperties SearchByScannerResultListDisplayProperties { get; set; }
//	}

//	public class Title5
//	{
//		[JsonProperty("@en")]
//		public string En { get; set; }
//		[JsonProperty("@he")]
//		public string He { get; set; }
//	}

//	public class SearchDisplayProperty2
//	{
//		[JsonProperty("@id")]
//		public string Id { get; set; }
//		public Title5 Title { get; set; }
//		public string invalid { get; set; }
//		public string id { get; set; }
//	}

//	public class SearchInCatalogByItemCodeResultListDisplayProperties
//	{
//		public List<SearchDisplayProperty2> SearchDisplayProperty { get; set; }
//	}

//	public class Title6
//	{
//		[JsonProperty("@en")]
//		public string En { get; set; }
//		[JsonProperty("@he")]
//		public string He { get; set; }
//	}

//	public class SearchDisplayProperty3
//	{
//		[JsonProperty("@id")]
//		public string Id { get; set; }
//		public Title6 Title { get; set; }
//		public string invalid { get; set; }
//		public string id { get; set; }
//	}

//	public class SearchInCatalogByItemNameResultListDisplayProperties
//	{
//		public List<SearchDisplayProperty3> SearchDisplayProperty { get; set; }
//	}

//	public class SearchInCatalogResultListsDisplayProperties
//	{
//		public SearchInCatalogByItemCodeResultListDisplayProperties SearchInCatalogByItemCodeResultListDisplayProperties { get; set; }
//		public SearchInCatalogByItemNameResultListDisplayProperties SearchInCatalogByItemNameResultListDisplayProperties { get; set; }
//	}

//	public class SearchInCatalogScreenConfiguration
//	{
//		public string AddNewItemIntoCatalogEnabled { get; set; }
//		public string CameraBarcodeScannerEnabled { get; set; }
//		public SearchInCatalogResultListsDisplayProperties SearchInCatalogResultListsDisplayProperties { get; set; }
//	}

//	public class Title7
//	{
//		[JsonProperty("@en")]
//		public string En { get; set; }
//		[JsonProperty("@he")]
//		public string He { get; set; }
//	}

//	public class SearchDisplayProperty4
//	{
//		[JsonProperty("@id")]
//		public string Id { get; set; }
//		public Title7 Title { get; set; }
//		public string invalid { get; set; }
//		public string id { get; set; }
//		[JsonProperty("@he")]
//		public string He { get; set; }
//	}

//	public class SearchInLocationByItemSerialResultListDisplayProperties
//	{
//		public List<SearchDisplayProperty4> SearchDisplayProperty { get; set; }
//	}

//	public class Title8
//	{
//		[JsonProperty("@en")]
//		public string En { get; set; }
//		[JsonProperty("@he")]
//		public string He { get; set; }
//	}

//	public class SearchDisplayProperty5
//	{
//		[JsonProperty("@id")]
//		public string Id { get; set; }
//		public Title8 Title { get; set; }
//		public string invalid { get; set; }
//		public string id { get; set; }
//		[JsonProperty("@he")]
//		public string He { get; set; }
//	}

//	public class SearchInLocationByItemCodeResultListDisplayProperties
//	{
//		public List<SearchDisplayProperty5> SearchDisplayProperty { get; set; }
//	}

//	public class Title9
//	{
//		[JsonProperty("@en")]
//		public string En { get; set; }
//		[JsonProperty("@he")]
//		public string He { get; set; }
//	}

//	public class SearchDisplayProperty6
//	{
//		[JsonProperty("@id")]
//		public string Id { get; set; }
//		public Title9 Title { get; set; }
//		public string invalid { get; set; }
//		public string id { get; set; }
//		[JsonProperty("@he")]
//		public string He { get; set; }
//	}

//	public class SearchInLocationByItemNameResultListDisplayProperties
//	{
//		public List<SearchDisplayProperty6> SearchDisplayProperty { get; set; }
//	}

//	public class SearchInLocationResultListsDisplayProperties
//	{
//		public SearchInLocationByItemSerialResultListDisplayProperties SearchInLocationByItemSerialResultListDisplayProperties { get; set; }
//		public SearchInLocationByItemCodeResultListDisplayProperties SearchInLocationByItemCodeResultListDisplayProperties { get; set; }
//		public SearchInLocationByItemNameResultListDisplayProperties SearchInLocationByItemNameResultListDisplayProperties { get; set; }
//	}

//	public class SearchInLocationScreenConfiguration
//	{
//		public string CameraBarcodeScannerEnabled { get; set; }
//		public SearchInLocationResultListsDisplayProperties SearchInLocationResultListsDisplayProperties { get; set; }
//		public string AddNewItemIntoCatalogEnabled { get; set; }
//	}

//	public class Search
//	{
//		public SearchByScannerScreenConfiguration SearchByScannerScreenConfiguration { get; set; }
//		public SearchInCatalogScreenConfiguration SearchInCatalogScreenConfiguration { get; set; }
//		public SearchInLocationScreenConfiguration SearchInLocationScreenConfiguration { get; set; }
//		public string IgnoreChar { get; set; }
//	}

//	public class AddNewLocationScreen
//	{
//		public string ScreenEnabled { get; set; }
//		public string ScreenEnabledOffline { get; set; }
//	}

//	public class ItemCodeSummaryScreen
//	{
//		public string ScreenEnabled { get; set; }
//	}

//	public class Title10
//	{
//		[JsonProperty("@en")]
//		public string En { get; set; }
//		[JsonProperty("@he")]
//		public string He { get; set; }
//	}

//	public class InventoryMoveSearchProperty
//	{
//		[JsonProperty("@id")]
//		public string Id { get; set; }
//		public Title10 Title { get; set; }
//	}

//	public class MoveInventoriesScreen
//	{
//		public InventoryMoveSearchProperty InventoryMoveSearchProperty { get; set; }
//		public string ScreenEnabled { get; set; }
//	}

//	public class AddQInventoryItemsInFastWayScreen
//	{
//		public string CameraBarcodeScannerEnabled { get; set; }
//		public string ScreenEnabled { get; set; }
//	}

//	public class DefaultValues
//	{
//		public string DefaultItemCode { get; set; }
//		public string DefaultQuantity { get; set; }
//	}

//	public class AddSNInventoryItemsInFastWayScreen
//	{
//		public string CameraBarcodeScannerEnabled { get; set; }
//		public DefaultValues DefaultValues { get; set; }
//		public string ScreenEnabled { get; set; }
//	}

//	public class WarehouseScreenRFID
//	{
//		public string ScreenEnabled { get; set; }
//		public string WarehouseScreenRFIDConnectionBeforeOpenRequired { get; set; }
//	}

//	public class AssertInventoryScreen
//	{
//		public string InventoryWizard { get; set; }
//		public string CameraBarcodeScannerEnabled { get; set; }
//	}

//	public class ScreensConfiguration
//	{
//		public AddNewLocationScreen AddNewLocationScreen { get; set; }
//		public ItemCodeSummaryScreen ItemCodeSummaryScreen { get; set; }
//		public MoveInventoriesScreen MoveInventoriesScreen { get; set; }
//		public AddQInventoryItemsInFastWayScreen AddQInventoryItemsInFastWayScreen { get; set; }
//		public AddSNInventoryItemsInFastWayScreen AddSNInventoryItemsInFastWayScreen { get; set; }
//		public WarehouseScreenRFID WarehouseScreenRFID { get; set; }
//		public AssertInventoryScreen AssertInventoryScreen { get; set; }
//	}

//	public class InventoryImage
//	{
//		public string InventoryImageEnabled { get; set; }
//		public string ImageQuality { get; set; }
//		public string InventoryImagePropertyId { get; set; }
//	}

//	public class FieldMapping
//	{
//		[JsonProperty("@name")]
//		public string Name { get; set; }
//		[JsonProperty("@dateFormat")]
//		public string DateFormat { get; set; }
//		[JsonProperty("@inventoryPropertyId")]
//		public string InventoryPropertyId { get; set; }
//		[JsonProperty("@reverseValue")]
//		public string ReverseValue { get; set; }
//	}

//	public class FieldsMapping
//	{
//		public List<FieldMapping> FieldMapping { get; set; }
//	}

//	public class PrintingFormat
//	{
//		public string Format { get; set; }
//		public FieldsMapping FieldsMapping { get; set; }
//	}

//	public class PrintingFormats
//	{
//		public PrintingFormat PrintingFormat { get; set; }
//	}

//	public class ZebraPrinter
//	{
//		public PrintingFormats PrintingFormats { get; set; }
//	}

//	public class PrinterSettings
//	{
//		public ZebraPrinter ZebraPrinter { get; set; }
//	}

//	public class RFIDCommand
//	{
//		[JsonProperty("@command")]
//		public string Command { get; set; }
//		[JsonProperty("@type")]
//		public string Type { get; set; }
//	}

//	public class RFIDCommands
//	{
//		public List<RFIDCommand> RFIDCommand { get; set; }
//	}

//	public class RFID
//	{
//		public string QCodeType { get; set; }
//		public RFIDCommands RFIDCommands { get; set; }
//		public string RFIDTagWritten { get; set; }
//		public string SNCodeType { get; set; }
//	}

//	public class DataSource2
//	{
//		[JsonProperty("@fieldname")]
//		public string Fieldname { get; set; }
//		[JsonProperty("@keyboard_type")]
//		public string KeyboardType { get; set; }
//		[JsonProperty("@tablename")]
//		public string Tablename { get; set; }
//		[JsonProperty("@fieldnametoshow")]
//		public string Fieldnametoshow { get; set; }
//	}

//	public class DataTarget2
//	{
//		[JsonProperty("@fieldname")]
//		public string Fieldname { get; set; }
//		[JsonProperty("@tablename")]
//		public string Tablename { get; set; }
//	}

//	public class Details2
//	{
//		[JsonProperty("@default")]
//		public string Default { get; set; }
//		[JsonProperty("@id")]
//		public string Id { get; set; }
//		[JsonProperty("@itemtype")]
//		public string Itemtype { get; set; }
//		[JsonProperty("@mandatory")]
//		public string Mandatory { get; set; }
//		[JsonProperty("@type")]
//		public string Type { get; set; }
//		[JsonProperty("@typeview")]
//		public string Typeview { get; set; }
//		[JsonProperty("@viewonly")]
//		public string Viewonly { get; set; }
//		[JsonProperty("@negative_value_enable")]
//		public string NegativeValueEnable { get; set; }
//		[JsonProperty("@add_enable")]
//		public string AddEnable { get; set; }
//	}

//	public class Title11
//	{
//		[JsonProperty("@en")]
//		public string En { get; set; }
//		[JsonProperty("@he")]
//		public string He { get; set; }
//	}

//	public class Description2
//	{
//		[JsonProperty("@en")]
//		public string En { get; set; }
//	}

//	public class Titles2
//	{
//		public Title11 Title { get; set; }
//		public Description2 Description { get; set; }
//	}

//	public class Validation
//	{
//		[JsonProperty("@en")]
//		public string En { get; set; }
//		[JsonProperty("@reg")]
//		public string Reg { get; set; }
//	}

//	public class Validations
//	{
//		public Validation Validation { get; set; }
//	}

//	public class Actions2
//	{
//		public Validations Validations { get; set; }
//		public string SelectInFocus { get; set; }
//		public string AutoGenerateCode { get; set; }
//	}

//	public class Field2
//	{
//		public DataSource2 DataSource { get; set; }
//		public DataTarget2 DataTarget { get; set; }
//		public Details2 Details { get; set; }
//		public Titles2 Titles { get; set; }
//		public string invalid { get; set; }
//		public string id { get; set; }
//		public Actions2 Actions { get; set; }
//	}

//	public class EditFormSettings
//	{
//		public List<Field2> Field { get; set; }
//	}

//	public class FastStockInventoryItemsConfiguration
//	{
//		public string DefaultAutomaticQuantity { get; set; }
//		public EditFormSettings EditFormSettings { get; set; }
//		public string AddDefaultQuantityMode { get; set; }
//		public string InsertNotExistInCatalogItems { get; set; }
//		public string InsertDetailsForNotExistInCatalogItems { get; set; }
//		public string CaseSensitiveItemCode { get; set; }
//		public string CameraBarcodeScannerStockLocation { get; set; }
//		public string CameraBarcodeScannerStockInventory { get; set; }
//	}

//	public class Customer2
//	{
//		[JsonProperty("@name")]
//		public string Name { get; set; }
//		[JsonProperty("@code")]
//		public string Code { get; set; }
//	}

//	public class Profile
//	{
//		public InventoryProcessInformation InventoryProcessInformation { get; set; }
//		public InventoryProcessConfiguration InventoryProcessConfiguration { get; set; }
//		[JsonProperty("#comment")]
//		public List<object> Comment { get; set; }
//		public string ScannerType { get; set; }
//		public LocationInventoryListScreenConfiguration LocationInventoryListScreenConfiguration { get; set; }
//		public InventoryListDefaultUIConfiguration InventoryListDefaultUIConfiguration { get; set; }
//		public DatabaseSettings DatabaseSettings { get; set; }
//		public Forms Forms { get; set; }
//		public Search Search { get; set; }
//		public ScreensConfiguration ScreensConfiguration { get; set; }
//		public InventoryImage InventoryImage { get; set; }
//		public PrinterSettings PrinterSettings { get; set; }
//		public RFID RFID { get; set; }
//		public FastStockInventoryItemsConfiguration FastStockInventoryItemsConfiguration { get; set; }
//		public string BarcodeManipulations { get; set; }
//		public string Version { get; set; }
//		public Customer2 Customer { get; set; }
//	}

//	public class Root
//	{
//		[JsonProperty("?xml")]
//		public Xml Xml { get; set; }
//		public Profile Profile { get; set; }
//	}
//}
