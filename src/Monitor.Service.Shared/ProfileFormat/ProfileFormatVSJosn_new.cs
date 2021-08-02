//using System;
//using System.Xml.Serialization;
//using System.Collections.Generic;

//	namespace Count4U.Service.Format.Xml
//	{
//		[XmlRoot(ElementName = "Customer")]
//		public class Customer
//		{
//			[XmlAttribute(AttributeName = "name")]
//			public string Name { get; set; }
//			[XmlAttribute(AttributeName = "code")]
//			public string Code { get; set; }
//		}

//		[XmlRoot(ElementName = "Branch")]
//		public class Branch
//		{
//			[XmlAttribute(AttributeName = "name")]
//			public string Name { get; set; }
//			[XmlAttribute(AttributeName = "code")]
//			public string Code { get; set; }
//		}

//		[XmlRoot(ElementName = "Inventory")]
//		public class Inventory
//		{
//			[XmlAttribute(AttributeName = "code")]
//			public string Code { get; set; }
//			[XmlAttribute(AttributeName = "created_date")]
//			public string Created_date { get; set; }
//			[XmlAttribute(AttributeName = "inventor_date")]
//			public string Inventor_date { get; set; }
//		}

//		[XmlRoot(ElementName = "InventoryProcessInformation")]
//		public class InventoryProcessInformation
//		{
//			[XmlElement(ElementName = "Customer")]
//			public Customer Customer { get; set; }
//			[XmlElement(ElementName = "Branch")]
//			public Branch Branch { get; set; }
//			[XmlElement(ElementName = "Inventory")]
//			public Inventory Inventory { get; set; }
//		}

//		[XmlRoot(ElementName = "InventoryProcessMode")]
//		public class InventoryProcessMode
//		{
//			[XmlElement(ElementName = "AssertModeEnabled")]
//			public string AssertModeEnabled { get; set; }
//			[XmlElement(ElementName = "StockModeEnabled")]
//			public string StockModeEnabled { get; set; }
//		}

//		[XmlRoot(ElementName = "InventoryProcessConfiguration")]
//		public class InventoryProcessConfiguration
//		{
//			[XmlElement(ElementName = "InventoryProcessMode")]
//			public InventoryProcessMode InventoryProcessMode { get; set; }
//		}

//		[XmlRoot(ElementName = "LocationInventoryListScreenConfiguration")]
//		public class LocationInventoryListScreenConfiguration
//		{
//			[XmlElement(ElementName = "AddNewInventoryEnabled")]
//			public string AddNewInventoryEnabled { get; set; }
//		[XmlElement(ElementName = "TemplateInventoriesEnabled")]

//		[NonSerialized]
//		public bool AddNewInventoryEnabledBool;
//		public string TemplateInventoriesEnabled { get; set; }
//		[XmlElement(ElementName = "SignatureToVerifyClosureOfLocationRequired")]

//		[NonSerialized]
//		public bool TemplateInventoriesEnabledBool;
//		public string SignatureToVerifyClosureOfLocationRequired { get; set; }

//		[NonSerialized]
//		public bool SignatureToVerifyClosureOfLocationRequiredBool;
//	}

//		[XmlRoot(ElementName = "Title")]
//		public class Title
//		{
//			[XmlAttribute(AttributeName = "en")]
//			public string En { get; set; }
//			[XmlAttribute(AttributeName = "he")]
//			public string He { get; set; }
//		}

//		[XmlRoot(ElementName = "InventoryItemDisplayProperty")]
//		public class InventoryItemDisplayProperty
//		{
//			[XmlElement(ElementName = "Title")]
//			public Title Title { get; set; }
//			[XmlElement(ElementName = "invalid")]
//			public string Invalid { get; set; }
//			[XmlElement(ElementName = "id")]
//			public string Id { get; set; }
//			[XmlAttribute(AttributeName = "id")]
//			public string _Id { get; set; }
//			[XmlAttribute(AttributeName = "itemtype")]
//			public string Itemtype { get; set; }
		
//			[NonSerialized]
//			public int index; //Todo
//		}

//		[XmlRoot(ElementName = "InventoryItemsProperties")]
//		public class InventoryItemsProperties
//		{
//			[XmlElement(ElementName = "InventoryItemDisplayProperty")]
//			public List<InventoryItemDisplayProperty> InventoryItemDisplayProperty { get; set; }
//		}

//		[XmlRoot(ElementName = "InventoryListDefaultUIConfiguration")]
//		public class InventoryListDefaultUIConfiguration
//		{
//			[XmlElement(ElementName = "ShowInventoryImageIndicator")]
//			public string ShowInventoryImageIndicator { get; set; }
//			[XmlElement(ElementName = "InventoryItemsProperties")]
//			public InventoryItemsProperties InventoryItemsProperties { get; set; }
//		}

//		[XmlRoot(ElementName = "DatabaseSettings")]
//		public class DatabaseSettings
//		{
//			[XmlElement(ElementName = "UIDKey")]
//			public string UIDKey { get; set; }
//			[XmlElement(ElementName = "CurrentInventoryDeviceIdProperty")]
//			public string CurrentInventoryDeviceIdProperty { get; set; }
//			[XmlElement(ElementName = "CurrentInventoryUserNameProperty")]
//			public string CurrentInventoryUserNameProperty { get; set; }
//			[XmlElement(ElementName = "ClearInventoryDataAfterUpload")]
//			public string ClearInventoryDataAfterUpload { get; set; }

//		[NonSerialized]
//		public bool ClearInventoryDataAfterUploadBool;
//	}

//		[XmlRoot(ElementName = "DataSource")]
//		public class DataSource
//		{
//			[XmlAttribute(AttributeName = "fieldname")]
//			public string Fieldname { get; set; }
//			[XmlAttribute(AttributeName = "keyboard_type")]
//			public string Keyboard_type { get; set; }
//			[XmlAttribute(AttributeName = "tablename")]
//			public string Tablename { get; set; }
//			[XmlAttribute(AttributeName = "fieldnametoshow")]
//			public string Fieldnametoshow { get; set; }
//		}

//		[XmlRoot(ElementName = "DataTarget")]
//		public class DataTarget
//		{
//			[XmlAttribute(AttributeName = "fieldname")]
//			public string Fieldname { get; set; }
//			[XmlAttribute(AttributeName = "tablename")]
//			public string Tablename { get; set; }
//		}

//		[XmlRoot(ElementName = "Details")]
//		public class Details
//		{
//			[XmlAttribute(AttributeName = "default")]
//			public string Default { get; set; }
//			[XmlAttribute(AttributeName = "id")]
//			public string Id { get; set; }
//			[XmlAttribute(AttributeName = "itemtype")]
//			public string Itemtype { get; set; }
//			[XmlAttribute(AttributeName = "mandatory")]
//			public string Mandatory { get; set; }
//			[XmlAttribute(AttributeName = "type")]
//			public string Type { get; set; }
//			[XmlAttribute(AttributeName = "typeview")]
//			public string Typeview { get; set; }
//			[XmlAttribute(AttributeName = "viewonly")]
//			public string Viewonly { get; set; }
//			[XmlAttribute(AttributeName = "add_enable")]
//			public string Add_enable { get; set; }
//			[XmlAttribute(AttributeName = "clear_enable")]
//			public string Clear_enable { get; set; }
//		}

//		[XmlRoot(ElementName = "Description")]
//		public class Description
//		{
//			[XmlAttribute(AttributeName = "en")]
//			public string En { get; set; }
//		}

//		[XmlRoot(ElementName = "Titles")]
//		public class Titles
//		{
//			[XmlElement(ElementName = "Title")]
//			public Title Title { get; set; }
//			[XmlElement(ElementName = "Description")]
//			public Description Description { get; set; }
//		}

//		[XmlRoot(ElementName = "Field")]
//		public class Field
//		{
//			[XmlElement(ElementName = "DataSource")]
//			public DataSource DataSource { get; set; }
//			[XmlElement(ElementName = "DataTarget")]
//			public DataTarget DataTarget { get; set; }
//			[XmlElement(ElementName = "Details")]
//			public Details Details { get; set; }
//			[XmlElement(ElementName = "Titles")]
//			public Titles Titles { get; set; }
//			[XmlElement(ElementName = "invalid")]
//			public string Invalid { get; set; }
//			[XmlElement(ElementName = "id")]
//			public string Id { get; set; }
//			[XmlElement(ElementName = "Actions")]
//			public Actions Actions { get; set; }
//		}

//		[XmlRoot(ElementName = "Validation")]
//		public class Validation
//		{
//			[XmlAttribute(AttributeName = "en")]
//			public string En { get; set; }
//			[XmlAttribute(AttributeName = "reg")]
//			public string Reg { get; set; }
//		}

//		[XmlRoot(ElementName = "Validations")]
//		public class Validations
//		{
//			[XmlElement(ElementName = "Validation")]
//			public Validation Validation { get; set; }
//		}

//		[XmlRoot(ElementName = "Actions")]
//		public class Actions
//		{
//			[XmlElement(ElementName = "Validations")]
//			public Validations Validations { get; set; }
//			[XmlElement(ElementName = "SelectInFocus")]
//			public string SelectInFocus { get; set; }
//		}

//		[XmlRoot(ElementName = "EditFormSettings")]
//		public class EditFormSettings
//		{
//			[XmlElement(ElementName = "Field")]
//			public List<Field> Field { get; set; }
//		}

//		[XmlRoot(ElementName = "FastStockInventoryItemsConfiguration")]
//		public class FastStockInventoryItemsConfiguration
//		{
//			[XmlElement(ElementName = "DefaultAutomaticQuantity")]
//			public string DefaultAutomaticQuantity { get; set; }
//			[XmlElement(ElementName = "EditFormSettings")]
//			public EditFormSettings EditFormSettings { get; set; }
//		}

//		[XmlRoot(ElementName = "Form")]
//		public class Form
//		{
//			[XmlElement(ElementName = "Field")]
//			public List<Field> Field { get; set; }
//			[XmlElement(ElementName = "KeepAllFieldsOnItemCodeChange")]
//			public string KeepAllFieldsOnItemCodeChange { get; set; }
//			[XmlAttribute(AttributeName = "id")]
//			public string Id { get; set; }
//		}

//		[XmlRoot(ElementName = "Forms")]
//		public class Forms
//		{
//			[XmlElement(ElementName = "Form")]
//			public Form Form { get; set; }
//		}

//		[XmlRoot(ElementName = "SearchByProperty")]
//		public class SearchByProperty
//		{
//			[XmlElement(ElementName = "Title")]
//			public Title Title { get; set; }
//			[XmlElement(ElementName = "id")]
//			public string Id { get; set; }
//			[XmlAttribute(AttributeName = "id")]
//			public string _Id { get; set; }
//		}

//		[XmlRoot(ElementName = "SearchByProperties")]
//		public class SearchByProperties
//		{
//			[XmlElement(ElementName = "SearchByProperty")]
//			public List<SearchByProperty> SearchByProperty { get; set; }
//		}

//		[XmlRoot(ElementName = "SearchDisplayProperty")]
//		public class SearchDisplayProperty
//		{
//			[XmlElement(ElementName = "Title")]
//			public Title Title { get; set; }
//			[XmlElement(ElementName = "invalid")]
//			public string Invalid { get; set; }
//			[XmlElement(ElementName = "id")]
//			public string Id { get; set; }
//			[XmlAttribute(AttributeName = "id")]
//			public string _Id { get; set; }
//		}

//		[XmlRoot(ElementName = "SearchByScannerResultListDisplayProperties")]
//		public class SearchByScannerResultListDisplayProperties
//		{
//			[XmlElement(ElementName = "SearchDisplayProperty")]
//			public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
//		}

//		[XmlRoot(ElementName = "SearchByScannerScreenConfiguration")]
//		public class SearchByScannerScreenConfiguration
//		{
//			[XmlElement(ElementName = "AddNewInventoryEnabled")]
//			public string AddNewInventoryEnabled { get; set; }
//			[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
//			public string CameraBarcodeScannerEnabled { get; set; }
//			[XmlElement(ElementName = "SearchByProperties")]
//			public SearchByProperties SearchByProperties { get; set; }
//			[XmlElement(ElementName = "SearchByScannerResultListDisplayProperties")]
//			public SearchByScannerResultListDisplayProperties SearchByScannerResultListDisplayProperties { get; set; }
//		}

//		[XmlRoot(ElementName = "SearchInCatalogByItemCodeResultListDisplayProperties")]
//		public class SearchInCatalogByItemCodeResultListDisplayProperties
//		{
//			[XmlElement(ElementName = "SearchDisplayProperty")]
//			public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
//		}

//		[XmlRoot(ElementName = "SearchInCatalogByItemNameResultListDisplayProperties")]
//		public class SearchInCatalogByItemNameResultListDisplayProperties
//		{
//			[XmlElement(ElementName = "SearchDisplayProperty")]
//			public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
//		}

//		[XmlRoot(ElementName = "SearchInCatalogResultListsDisplayProperties")]
//		public class SearchInCatalogResultListsDisplayProperties
//		{
//			[XmlElement(ElementName = "SearchInCatalogByItemCodeResultListDisplayProperties")]
//			public SearchInCatalogByItemCodeResultListDisplayProperties SearchInCatalogByItemCodeResultListDisplayProperties { get; set; }
//			[XmlElement(ElementName = "SearchInCatalogByItemNameResultListDisplayProperties")]
//			public SearchInCatalogByItemNameResultListDisplayProperties SearchInCatalogByItemNameResultListDisplayProperties { get; set; }
//		}

//		[XmlRoot(ElementName = "SearchInCatalogScreenConfiguration")]
//		public class SearchInCatalogScreenConfiguration
//		{
//			[XmlElement(ElementName = "AddNewItemIntoCatalogEnabled")]
//			public string AddNewItemIntoCatalogEnabled { get; set; }
//			[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
//			public string CameraBarcodeScannerEnabled { get; set; }
//			[XmlElement(ElementName = "SearchInCatalogResultListsDisplayProperties")]
//			public SearchInCatalogResultListsDisplayProperties SearchInCatalogResultListsDisplayProperties { get; set; }
//		}

//		[XmlRoot(ElementName = "SearchInLocationByItemSerialResultListDisplayProperties")]
//		public class SearchInLocationByItemSerialResultListDisplayProperties
//		{
//			[XmlElement(ElementName = "SearchDisplayProperty")]
//			public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
//		}

//		[XmlRoot(ElementName = "SearchInLocationByItemCodeResultListDisplayProperties")]
//		public class SearchInLocationByItemCodeResultListDisplayProperties
//		{
//			[XmlElement(ElementName = "SearchDisplayProperty")]
//			public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
//		}

//		[XmlRoot(ElementName = "SearchInLocationByItemNameResultListDisplayProperties")]
//		public class SearchInLocationByItemNameResultListDisplayProperties
//		{
//			[XmlElement(ElementName = "SearchDisplayProperty")]
//			public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
//		}

//		[XmlRoot(ElementName = "SearchInLocationResultListsDisplayProperties")]
//		public class SearchInLocationResultListsDisplayProperties
//		{
//			[XmlElement(ElementName = "SearchInLocationByItemSerialResultListDisplayProperties")]
//			public SearchInLocationByItemSerialResultListDisplayProperties SearchInLocationByItemSerialResultListDisplayProperties { get; set; }
//			[XmlElement(ElementName = "SearchInLocationByItemCodeResultListDisplayProperties")]
//			public SearchInLocationByItemCodeResultListDisplayProperties SearchInLocationByItemCodeResultListDisplayProperties { get; set; }
//			[XmlElement(ElementName = "SearchInLocationByItemNameResultListDisplayProperties")]
//			public SearchInLocationByItemNameResultListDisplayProperties SearchInLocationByItemNameResultListDisplayProperties { get; set; }
//		}

//		[XmlRoot(ElementName = "SearchInLocationScreenConfiguration")]
//		public class SearchInLocationScreenConfiguration
//		{
//			[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
//			public string CameraBarcodeScannerEnabled { get; set; }
//			[XmlElement(ElementName = "SearchInLocationResultListsDisplayProperties")]
//			public SearchInLocationResultListsDisplayProperties SearchInLocationResultListsDisplayProperties { get; set; }
//			[XmlElement(ElementName = "AddNewItemIntoCatalogEnabled")]
//			public string AddNewItemIntoCatalogEnabled { get; set; }
//		}

//		[XmlRoot(ElementName = "Search")]
//		public class Search
//		{
//			[XmlElement(ElementName = "IgnoreChar")]
//			public string IgnoreChar { get; set; }
//			[XmlElement(ElementName = "SearchByScannerScreenConfiguration")]
//			public SearchByScannerScreenConfiguration SearchByScannerScreenConfiguration { get; set; }
//			[XmlElement(ElementName = "SearchInCatalogScreenConfiguration")]
//			public SearchInCatalogScreenConfiguration SearchInCatalogScreenConfiguration { get; set; }
//			[XmlElement(ElementName = "SearchInLocationScreenConfiguration")]
//			public SearchInLocationScreenConfiguration SearchInLocationScreenConfiguration { get; set; }
//		}

//		[XmlRoot(ElementName = "AddNewLocationScreen")]
//		public class AddNewLocationScreen
//		{
//			[XmlElement(ElementName = "ScreenEnabled")]
//			public string ScreenEnabled { get; set; }
//		}

//		[XmlRoot(ElementName = "ItemCodeSummaryScreen")]
//		public class ItemCodeSummaryScreen
//		{
//			[XmlElement(ElementName = "ScreenEnabled")]
//			public string ScreenEnabled { get; set; }
//		}

//		[XmlRoot(ElementName = "InventoryMoveSearchProperty")]
//		public class InventoryMoveSearchProperty
//		{
//			[XmlElement(ElementName = "Title")]
//			public Title Title { get; set; }
//			[XmlAttribute(AttributeName = "id")]
//			public string Id { get; set; }
//		}

//		[XmlRoot(ElementName = "MoveInventoriesScreen")]
//		public class MoveInventoriesScreen
//		{
//			[XmlElement(ElementName = "InventoryMoveSearchProperty")]
//			public InventoryMoveSearchProperty InventoryMoveSearchProperty { get; set; }
//			[XmlElement(ElementName = "ScreenEnabled")]
//			public string ScreenEnabled { get; set; }
//		}

//		[XmlRoot(ElementName = "DefaultValues")]
//		public class DefaultValues
//		{
//			[XmlElement(ElementName = "DefaultItemCode")]
//			public string DefaultItemCode { get; set; }
//			[XmlElement(ElementName = "DefaultQuantity")]
//			public string DefaultQuantity { get; set; }
//		}

//		[XmlRoot(ElementName = "AddSNInventoryItemsInFastWayScreen")]
//		public class AddSNInventoryItemsInFastWayScreen
//		{
//			[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
//			public string CameraBarcodeScannerEnabled { get; set; }
//			[XmlElement(ElementName = "DefaultValues")]
//			public DefaultValues DefaultValues { get; set; }
//			[XmlElement(ElementName = "ScreenEnabled")]
//			public string ScreenEnabled { get; set; }
//		}

//		[XmlRoot(ElementName = "AddQInventoryItemsInFastWayScreen")]
//		public class AddQInventoryItemsInFastWayScreen
//		{
//			[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
//			public string CameraBarcodeScannerEnabled { get; set; }
//			[XmlElement(ElementName = "ScreenEnabled")]
//			public string ScreenEnabled { get; set; }
//		}

//		[XmlRoot(ElementName = "WarehouseScreenRFID")]
//		public class WarehouseScreenRFID
//		{
//			[XmlElement(ElementName = "ScreenEnabled")]
//			public string ScreenEnabled { get; set; }
//			[XmlElement(ElementName = "WarehouseScreenRFIDConnectionBeforeOpenRequired")]
//			public string WarehouseScreenRFIDConnectionBeforeOpenRequired { get; set; }
//		}

//		[XmlRoot(ElementName = "ScreensConfiguration")]
//		public class ScreensConfiguration
//		{
//			[XmlElement(ElementName = "AddNewLocationScreen")]
//			public AddNewLocationScreen AddNewLocationScreen { get; set; }
//			[XmlElement(ElementName = "ItemCodeSummaryScreen")]
//			public ItemCodeSummaryScreen ItemCodeSummaryScreen { get; set; }
//			[XmlElement(ElementName = "MoveInventoriesScreen")]
//			public MoveInventoriesScreen MoveInventoriesScreen { get; set; }
//			[XmlElement(ElementName = "AddSNInventoryItemsInFastWayScreen")]
//			public AddSNInventoryItemsInFastWayScreen AddSNInventoryItemsInFastWayScreen { get; set; }
//			[XmlElement(ElementName = "AddQInventoryItemsInFastWayScreen")]
//			public AddQInventoryItemsInFastWayScreen AddQInventoryItemsInFastWayScreen { get; set; }
//			[XmlElement(ElementName = "WarehouseScreenRFID")]
//			public WarehouseScreenRFID WarehouseScreenRFID { get; set; }
//		}

//		[XmlRoot(ElementName = "InventoryImage")]
//		public class InventoryImage
//		{
//			[XmlElement(ElementName = "InventoryImageEnabled")]
//			public string InventoryImageEnabled { get; set; }
//			[XmlElement(ElementName = "ImageQuality")]
//			public string ImageQuality { get; set; }
//			[XmlElement(ElementName = "InventoryImagePropertyId")]
//			public string InventoryImagePropertyId { get; set; }
//		}

//		[XmlRoot(ElementName = "FieldMapping")]
//		public class FieldMapping
//		{
//			[XmlAttribute(AttributeName = "name")]
//			public string Name { get; set; }
//			[XmlAttribute(AttributeName = "dateFormat")]
//			public string DateFormat { get; set; }
//			[XmlAttribute(AttributeName = "inventoryPropertyId")]
//			public string InventoryPropertyId { get; set; }
//			[XmlAttribute(AttributeName = "reverseValue")]
//			public string ReverseValue { get; set; }
//		}

//		[XmlRoot(ElementName = "FieldsMapping")]
//		public class FieldsMapping
//		{
//			[XmlElement(ElementName = "FieldMapping")]
//			public List<FieldMapping> FieldMapping { get; set; }
//		}

//		[XmlRoot(ElementName = "PrintingFormat")]
//		public class PrintingFormat
//		{
//			[XmlElement(ElementName = "Format")]
//			public string Format { get; set; }
//			[XmlElement(ElementName = "FieldsMapping")]
//			public FieldsMapping FieldsMapping { get; set; }
//		}

//		[XmlRoot(ElementName = "PrintingFormats")]
//		public class PrintingFormats
//		{
//			[XmlElement(ElementName = "PrintingFormat")]
//			public PrintingFormat PrintingFormat { get; set; }
//		}

//		[XmlRoot(ElementName = "ZebraPrinter")]
//		public class ZebraPrinter
//		{
//			[XmlElement(ElementName = "PrintingFormats")]
//			public PrintingFormats PrintingFormats { get; set; }
//		}

//		[XmlRoot(ElementName = "PrinterSettings")]
//		public class PrinterSettings
//		{
//			[XmlElement(ElementName = "ZebraPrinter")]
//			public ZebraPrinter ZebraPrinter { get; set; }
//		}

//		[XmlRoot(ElementName = "RFIDCommand")]
//		public class RFIDCommand
//		{
//			[XmlAttribute(AttributeName = "command")]
//			public string Command { get; set; }
//			[XmlAttribute(AttributeName = "type")]
//			public string Type { get; set; }
//		}

//		[XmlRoot(ElementName = "RFIDCommands")]
//		public class RFIDCommands
//		{
//			[XmlElement(ElementName = "RFIDCommand")]
//			public List<RFIDCommand> RFIDCommand { get; set; }
//		}

//		[XmlRoot(ElementName = "RFID")]
//		public class RFID
//		{
//			[XmlElement(ElementName = "QCodeType")]
//			public string QCodeType { get; set; }
//			[XmlElement(ElementName = "RFIDCommands")]
//			public RFIDCommands RFIDCommands { get; set; }
//			[XmlElement(ElementName = "RFIDTagWritten")]
//			public string RFIDTagWritten { get; set; }
//			[XmlElement(ElementName = "SNCodeType")]
//			public string SNCodeType { get; set; }
//		}

//		[XmlRoot(ElementName = "Profile")]
//		public class Profile
//		{
//			[XmlElement(ElementName = "InventoryProcessInformation")]
//			public InventoryProcessInformation InventoryProcessInformation { get; set; }
//			[XmlElement(ElementName = "InventoryProcessConfiguration")]
//			public InventoryProcessConfiguration InventoryProcessConfiguration { get; set; }
//			[XmlElement(ElementName = "ScannerType")]
//			public string ScannerType { get; set; }
//			[XmlElement(ElementName = "LocationInventoryListScreenConfiguration")]
//			public LocationInventoryListScreenConfiguration LocationInventoryListScreenConfiguration { get; set; }
//			[XmlElement(ElementName = "InventoryListDefaultUIConfiguration")]
//			public InventoryListDefaultUIConfiguration InventoryListDefaultUIConfiguration { get; set; }
//			[XmlElement(ElementName = "DatabaseSettings")]
//			public DatabaseSettings DatabaseSettings { get; set; }
//			[XmlElement(ElementName = "FastStockInventoryItemsConfiguration")]
//			public FastStockInventoryItemsConfiguration FastStockInventoryItemsConfiguration { get; set; }
//			[XmlElement(ElementName = "Forms")]
//			public Forms Forms { get; set; }
//			[XmlElement(ElementName = "Search")]
//			public Search Search { get; set; }
//			[XmlElement(ElementName = "ScreensConfiguration")]
//			public ScreensConfiguration ScreensConfiguration { get; set; }
//			[XmlElement(ElementName = "InventoryImage")]
//			public InventoryImage InventoryImage { get; set; }
//			[XmlElement(ElementName = "PrinterSettings")]
//			public PrinterSettings PrinterSettings { get; set; }
//			[XmlElement(ElementName = "RFID")]
//			public RFID RFID { get; set; }
//			[XmlElement(ElementName = "Version")]
//			public string Version { get; set; }
//		}

//	}


