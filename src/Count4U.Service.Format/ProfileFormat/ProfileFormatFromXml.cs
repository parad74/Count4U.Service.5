using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Count4U.Service.Format.Xml
{
	// using System.Xml.Serialization;
	// XmlSerializer serializer = new XmlSerializer(typeof(Profile));
	// using (StringReader reader = new StringReader(xml))
	// {
	//    var test = (Profile)serializer.Deserialize(reader);
	// }

	[XmlRoot(ElementName = "Customer")]
	public class Customer
	{

		[XmlAttribute(AttributeName = "name")]
		public String Name { get; set; }

		[XmlAttribute(AttributeName = "code")]
		public String Code { get; set; }
	}

	[XmlRoot(ElementName = "Branch")]
	public class Branch
	{

		[XmlAttribute(AttributeName = "name")]
		public String Name { get; set; }

		[XmlAttribute(AttributeName = "code")]
		public String Code { get; set; }
	}

	[XmlRoot(ElementName = "Inventory")]
	public class Inventory
	{

		[XmlAttribute(AttributeName = "code")]
		public String Code { get; set; }

		[XmlAttribute(AttributeName = "created_date")]
		public String CreatedDate { get; set; }
	}

	[XmlRoot(ElementName = "InventoryProcessInformation")]
	public class InventoryProcessInformation
	{

		[XmlElement(ElementName = "Customer")]
		public Customer Customer { get; set; }

		[XmlElement(ElementName = "Branch")]
		public Branch Branch { get; set; }

		[XmlElement(ElementName = "Inventory")]
		public Inventory Inventory { get; set; }
	}

	[XmlRoot(ElementName = "InventoryProcessMode")]
	public class InventoryProcessMode
	{

		[XmlElement(ElementName = "AssertModeEnabled")]
		public string AssertModeEnabled { get; set; }

		[XmlElement(ElementName = "StockModeEnabled")]
		public string StockModeEnabled { get; set; }
	}

	[XmlRoot(ElementName = "InventoryProcessConfiguration")]
	public class InventoryProcessConfiguration
	{

		[XmlElement(ElementName = "InventoryProcessMode")]
		public InventoryProcessMode InventoryProcessMode { get; set; }
	}

	[XmlRoot(ElementName = "LocationInventoryListScreenConfiguration")]
	public class LocationInventoryListScreenConfiguration
	{

		[XmlElement(ElementName = "AddNewInventoryEnabled")]
		public string AddNewInventoryEnabled { get; set; }

		[XmlElement(ElementName = "TemplateInventoriesEnabled")]
		public string TemplateInventoriesEnabled { get; set; }

		[XmlElement(ElementName = "SignatureToVerifyClosureOfLocationRequired")]
		public string SignatureToVerifyClosureOfLocationRequired { get; set; }

		[XmlElement(ElementName = "AddNewInventoryOfflineEnabled")]
		public string AddNewInventoryOfflineEnabled { get; set; }
	}

	[XmlRoot(ElementName = "Title")]
	public class Title
	{

		[XmlAttribute(AttributeName = "en")]
		public String En { get; set; }

		[XmlAttribute(AttributeName = "he")]
		public String He { get; set; }
	}

	[XmlRoot(ElementName = "InventoryItemDisplayProperty")]
	public class InventoryItemDisplayProperty
	{

		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlElement(ElementName = "string")]
		public List<string> Id { get; set; }

		[XmlAttribute(AttributeName = "itemtype")]
		public String Itemtype { get; set; }
	}

	[XmlRoot(ElementName = "InventoryItemsProperties")]
	public class InventoryItemsProperties
	{

		[XmlElement(ElementName = "InventoryItemDisplayProperty")]
		public List<InventoryItemDisplayProperty> InventoryItemDisplayProperty { get; set; }
	}

	[XmlRoot(ElementName = "InventoryListDefaultUIConfiguration")]
	public class InventoryListDefaultUIConfiguration
	{

		[XmlElement(ElementName = "ShowInventoryImageIndicator")]
		public string ShowInventoryImageIndicator { get; set; }

		[XmlElement(ElementName = "InventoryItemsProperties")]
		public InventoryItemsProperties InventoryItemsProperties { get; set; }
	}

	[XmlRoot(ElementName = "DatabaseSettings")]
	public class DatabaseSettings
	{

		[XmlElement(ElementName = "UIDKey")]
		public string UIDKey { get; set; }

		[XmlElement(ElementName = "CurrentInventoryDeviceIdProperty")]
		public string CurrentInventoryDeviceIdProperty { get; set; }

		[XmlElement(ElementName = "CurrentInventoryUserNameProperty")]
		public string CurrentInventoryUserNameProperty { get; set; }

		[XmlElement(ElementName = "ClearInventoryDataAfterUpload")]
		public string ClearInventoryDataAfterUpload { get; set; }

		[XmlElement(ElementName = "CurrentInventoryDeviceNameProperty")]
		public string CurrentInventoryDeviceNameProperty { get; set; }
	}

	[XmlRoot(ElementName = "DataSource")]
	public class DataSource
	{

		[XmlAttribute(AttributeName = "fieldname")]
		public String Fieldname { get; set; }

		[XmlAttribute(AttributeName = "keyboard_type")]
		public String KeyboardType { get; set; }

		[XmlAttribute(AttributeName = "tablename")]
		public String Tablename { get; set; }
	}

	[XmlRoot(ElementName = "DataTarget")]
	public class DataTarget
	{

		[XmlAttribute(AttributeName = "fieldname")]
		public String Fieldname { get; set; }

		[XmlAttribute(AttributeName = "tablename")]
		public String Tablename { get; set; }
	}

	[XmlRoot(ElementName = "Details")]
	public class Details
	{

		[XmlAttribute(AttributeName = "default")]
		public String Default { get; set; }

		[XmlAttribute(AttributeName = "id")]
		public String Id { get; set; }

		[XmlAttribute(AttributeName = "itemtype")]
		public String Itemtype { get; set; }

		[XmlAttribute(AttributeName = "mandatory")]
		public String Mandatory { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public String Type { get; set; }

		[XmlAttribute(AttributeName = "typeview")]
		public String Typeview { get; set; }

		[XmlAttribute(AttributeName = "viewonly")]
		public String Viewonly { get; set; }

		[XmlAttribute(AttributeName = "camera_barcode_scanner_enable")]
		public String CameraBarcodeScannerEnable { get; set; }

		[XmlAttribute(AttributeName = "negative_value_enable")]
		public String NegativeValueEnable { get; set; }
	}

	[XmlRoot(ElementName = "Description")]
	public class Description
	{

		[XmlAttribute(AttributeName = "en")]
		public String En { get; set; }
	}

	[XmlRoot(ElementName = "Titles")]
	public class Titles
	{

		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }

		[XmlElement(ElementName = "Description")]
		public Description Description { get; set; }
	}

	[XmlRoot(ElementName = "Field")]
	public class Field
	{

		[XmlElement(ElementName = "DataSource")]
		public DataSource DataSource { get; set; }

		[XmlElement(ElementName = "DataTarget")]
		public DataTarget DataTarget { get; set; }

		[XmlElement(ElementName = "Details")]
		public Details Details { get; set; }

		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "DataSource")]
	public class DataSource2
	{

		[XmlAttribute(AttributeName = "fieldname")]
		public String Fieldname { get; set; }

		[XmlAttribute(AttributeName = "keyboard_type")]
		public String KeyboardType { get; set; }

		[XmlAttribute(AttributeName = "tablename")]
		public String Tablename { get; set; }

		[XmlAttribute(AttributeName = "fieldnametoshow")]
		public String Fieldnametoshow { get; set; }
	}

	[XmlRoot(ElementName = "Field")]
	public class Field2
	{

		[XmlElement(ElementName = "DataSource")]
		public DataSource2 DataSource2 { get; set; }

		[XmlElement(ElementName = "DataTarget")]
		public DataTarget DataTarget { get; set; }

		[XmlElement(ElementName = "Details")]
		public Details Details { get; set; }

		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "Details")]
	public class Details2
	{

		[XmlAttribute(AttributeName = "add_enable")]
		public String AddEnable { get; set; }

		[XmlAttribute(AttributeName = "clear_enable")]
		public String ClearEnable { get; set; }

		[XmlAttribute(AttributeName = "default")]
		public String Default { get; set; }

		[XmlAttribute(AttributeName = "id")]
		public String Id { get; set; }

		[XmlAttribute(AttributeName = "itemtype")]
		public String Itemtype { get; set; }

		[XmlAttribute(AttributeName = "mandatory")]
		public String Mandatory { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public String Type { get; set; }

		[XmlAttribute(AttributeName = "typeview")]
		public String Typeview { get; set; }

		[XmlAttribute(AttributeName = "viewonly")]
		public String Viewonly { get; set; }
	}

	[XmlRoot(ElementName = "Titles")]
	public class Titles2
	{

		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }
	}

	[XmlRoot(ElementName = "Field")]
	public class Field3
	{

		[XmlElement(ElementName = "Actions")]
		public string Actions { get; set; }

		[XmlElement(ElementName = "DataSource")]
		public DataSource DataSource { get; set; }

		[XmlElement(ElementName = "DataTarget")]
		public DataTarget DataTarget { get; set; }

		[XmlElement(ElementName = "Details")]
		public Details2 Details2 { get; set; }

		[XmlElement(ElementName = "Titles")]
		public Titles2 Titles2 { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "Actions")]
	public class Actions
	{

		[XmlElement(ElementName = "SelectInFocus")]
		public string SelectInFocus { get; set; }
	}

	[XmlRoot(ElementName = "Details")]
	public class Details3
	{

		[XmlAttribute(AttributeName = "default")]
		public String Default { get; set; }

		[XmlAttribute(AttributeName = "id")]
		public String Id { get; set; }

		[XmlAttribute(AttributeName = "itemtype")]
		public String Itemtype { get; set; }

		[XmlAttribute(AttributeName = "mandatory")]
		public String Mandatory { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public String Type { get; set; }

		[XmlAttribute(AttributeName = "typeview")]
		public String Typeview { get; set; }

		[XmlAttribute(AttributeName = "viewonly")]
		public String Viewonly { get; set; }

		[XmlAttribute(AttributeName = "camera_barcode_scanner_enable")]
		public String CameraBarcodeScannerEnable { get; set; }

		[XmlAttribute(AttributeName = "negative_value_enable")]
		public String NegativeValueEnable { get; set; }

		[XmlAttribute(AttributeName = "zero_value_enable")]
		public String ZeroValueEnable { get; set; }
	}

	[XmlRoot(ElementName = "Field")]
	public class Field4
	{

		[XmlElement(ElementName = "Actions")]
		public Actions Actions { get; set; }

		[XmlElement(ElementName = "DataSource")]
		public DataSource DataSource { get; set; }

		[XmlElement(ElementName = "DataTarget")]
		public DataTarget DataTarget { get; set; }

		[XmlElement(ElementName = "Details")]
		public Details3 Details3 { get; set; }

		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "Actions")]
	public class Actions2
	{

		[XmlElement(ElementName = "SelectInFocus")]
		public string SelectInFocus { get; set; }

		[XmlElement(ElementName = "AutoGenerateCode")]
		public string AutoGenerateCode { get; set; }
	}

	[XmlRoot(ElementName = "Details")]
	public class Details4
	{

		[XmlAttribute(AttributeName = "default")]
		public String Default { get; set; }

		[XmlAttribute(AttributeName = "id")]
		public String Id { get; set; }

		[XmlAttribute(AttributeName = "itemtype")]
		public String Itemtype { get; set; }

		[XmlAttribute(AttributeName = "mandatory")]
		public String Mandatory { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public String Type { get; set; }

		[XmlAttribute(AttributeName = "typeview")]
		public String Typeview { get; set; }

		[XmlAttribute(AttributeName = "viewonly")]
		public String Viewonly { get; set; }

		[XmlAttribute(AttributeName = "camera_barcode_scanner_enable")]
		public String CameraBarcodeScannerEnable { get; set; }

		[XmlAttribute(AttributeName = "negative_value_enable")]
		public String NegativeValueEnable { get; set; }

		[XmlAttribute(AttributeName = "add_enable")]
		public String AddEnable { get; set; }
	}

	[XmlRoot(ElementName = "Field")]
	public class Field5
	{

		[XmlElement(ElementName = "Actions")]
		public Actions2 Actions2 { get; set; }

		[XmlElement(ElementName = "DataSource")]
		public DataSource DataSource { get; set; }

		[XmlElement(ElementName = "DataTarget")]
		public DataTarget DataTarget { get; set; }

		[XmlElement(ElementName = "Details")]
		public Details4 Details4 { get; set; }

		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "Field")]
	public class Field6
	{

		[XmlElement(ElementName = "Actions")]
		public Actions Actions { get; set; }

		[XmlElement(ElementName = "DataSource")]
		public DataSource DataSource { get; set; }

		[XmlElement(ElementName = "DataTarget")]
		public DataTarget DataTarget { get; set; }

		[XmlElement(ElementName = "Details")]
		public Details Details { get; set; }

		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "Enabled")]
	public class Enabled
	{

		[XmlAttribute(AttributeName = "fieldcondition")]
		public String Fieldcondition { get; set; }
	}

	[XmlRoot(ElementName = "Filter")]
	public class Filter
	{

		[XmlAttribute(AttributeName = "type")]
		public String Type { get; set; }

		[XmlAttribute(AttributeName = "value")]
		public String Value { get; set; }

		[XmlAttribute(AttributeName = "valueToReg")]
		public String ValueToReg { get; set; }
	}

	[XmlRoot(ElementName = "EnabledFiler")]
	public class EnabledFiler
	{

		[XmlElement(ElementName = "Enabled")]
		public Enabled Enabled { get; set; }

		[XmlElement(ElementName = "Filter")]
		public Filter Filter { get; set; }
	}

	[XmlRoot(ElementName = "EnabledFilters")]
	public class EnabledFilters
	{

		[XmlElement(ElementName = "EnabledFiler")]
		public List<EnabledFiler> EnabledFiler { get; set; }
	}

	[XmlRoot(ElementName = "Actions")]
	public class Actions3
	{

		[XmlElement(ElementName = "SelectInFocus")]
		public string SelectInFocus { get; set; }

		[XmlElement(ElementName = "EnabledFilters")]
		public EnabledFilters EnabledFilters { get; set; }
	}

	[XmlRoot(ElementName = "Details")]
	public class Details5
	{

		[XmlAttribute(AttributeName = "default")]
		public String Default { get; set; }

		[XmlAttribute(AttributeName = "id")]
		public String Id { get; set; }

		[XmlAttribute(AttributeName = "itemtype")]
		public String Itemtype { get; set; }

		[XmlAttribute(AttributeName = "mandatory")]
		public String Mandatory { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public String Type { get; set; }

		[XmlAttribute(AttributeName = "typeview")]
		public String Typeview { get; set; }

		[XmlAttribute(AttributeName = "viewonly")]
		public String Viewonly { get; set; }

		[XmlAttribute(AttributeName = "camera_barcode_scanner_enable")]
		public String CameraBarcodeScannerEnable { get; set; }

		[XmlAttribute(AttributeName = "zero_value_enable")]
		public String ZeroValueEnable { get; set; }
	}

	[XmlRoot(ElementName = "Field")]
	public class Field7
	{

		[XmlElement(ElementName = "Actions")]
		public Actions3 Actions3 { get; set; }

		[XmlElement(ElementName = "DataSource")]
		public DataSource DataSource { get; set; }

		[XmlElement(ElementName = "DataTarget")]
		public DataTarget DataTarget { get; set; }

		[XmlElement(ElementName = "Details")]
		public Details5 Details5 { get; set; }

		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "Field")]
	public class Field8
	{

		[XmlElement(ElementName = "Actions")]
		public string Actions4 { get; set; }

		[XmlElement(ElementName = "DataSource")]
		public DataSource DataSource { get; set; }

		[XmlElement(ElementName = "DataTarget")]
		public DataTarget DataTarget { get; set; }

		[XmlElement(ElementName = "Details")]
		public Details Details { get; set; }

		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "Actions")]
	public class Actions4
	{

		[XmlElement(ElementName = "EnabledFilters")]
		public string EnabledFilters2 { get; set; }

		[XmlElement(ElementName = "SelectInFocus")]
		public string SelectInFocus { get; set; }
	}

	[XmlRoot(ElementName = "Field")]
	public class Field9
	{

		[XmlElement(ElementName = "Actions")]
		public Actions4 Actions4 { get; set; }

		[XmlElement(ElementName = "DataSource")]
		public DataSource DataSource { get; set; }

		[XmlElement(ElementName = "DataTarget")]
		public DataTarget DataTarget { get; set; }

		[XmlElement(ElementName = "Details")]
		public Details Details { get; set; }

		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "Field")]
	public class Field10
	{

		[XmlElement(ElementName = "Actions")]
		public string Actions5 { get; set; }

		[XmlElement(ElementName = "DataSource")]
		public DataSource DataSource { get; set; }

		[XmlElement(ElementName = "DataTarget")]
		public DataTarget DataTarget { get; set; }

		[XmlElement(ElementName = "Details")]
		public Details Details { get; set; }

		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "Form")]
	public class Form
	{

		[XmlElement(ElementName = "Field")]
		public List<Field> Field { get; set; }

		[XmlElement(ElementName = "Field")]
		public Field2 Field2 { get; set; }

		[XmlElement(ElementName = "Field")]
		public Field3 Field3 { get; set; }

		[XmlElement(ElementName = "Field")]
		public Field4 Field4 { get; set; }

		[XmlElement(ElementName = "Field")]
		public Field5 Field5 { get; set; }

		[XmlElement(ElementName = "Field")]
		public Field6 Field6 { get; set; }

		[XmlElement(ElementName = "Field")]
		public Field7 Field7 { get; set; }

		[XmlElement(ElementName = "Field")]
		public Field8 Field8 { get; set; }

		[XmlElement(ElementName = "Field")]
		public Field9 Field9 { get; set; }

		[XmlElement(ElementName = "Field")]
		public Field10 Field10 { get; set; }

		[XmlElement(ElementName = "KeepAllFieldsOnItemCodeChange")]
		public string KeepAllFieldsOnItemCodeChange { get; set; }

		[XmlAttribute(AttributeName = "id")]
		public String Id { get; set; }
	}

	[XmlRoot(ElementName = "Forms")]
	public class Forms
	{

		[XmlElement(ElementName = "Form")]
		public Form Form { get; set; }
	}

	[XmlRoot(ElementName = "SearchByProperty")]
	public class SearchByProperty
	{

		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }

		[XmlElement(ElementName = "string")]
		public List<string> Id { get; set; }
	}

	[XmlRoot(ElementName = "SearchByProperty")]
	public class SearchByProperty2
	{

		[XmlElement(ElementName = "string")]
		public List<string> Id { get; set; }
	}

	[XmlRoot(ElementName = "SearchByProperties")]
	public class SearchByProperties
	{

		[XmlElement(ElementName = "SearchByProperty")]
		public List<SearchByProperty> SearchByProperty { get; set; }

		[XmlElement(ElementName = "SearchByProperty")]
		public SearchByProperty2 SearchByProperty2 { get; set; }
	}

	[XmlRoot(ElementName = "SearchDisplayProperty")]
	public class SearchDisplayProperty
	{

		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlElement(ElementName = "string")]
		public List<string> Id { get; set; }
	}

	[XmlRoot(ElementName = "SearchDisplayProperty")]
	public class SearchDisplayProperty2
	{

		[XmlElement(ElementName = "string")]
		public List<string> Id { get; set; }

		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlAttribute(AttributeName = "he")]
		public String He { get; set; }
	}

	[XmlRoot(ElementName = "SearchByScannerResultListDisplayProperties")]
	public class SearchByScannerResultListDisplayProperties
	{

		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }

		[XmlElement(ElementName = "SearchDisplayProperty")]
		public SearchDisplayProperty2 SearchDisplayProperty2 { get; set; }
	}

	[XmlRoot(ElementName = "SearchByScannerScreenConfiguration")]
	public class SearchByScannerScreenConfiguration
	{

		[XmlElement(ElementName = "AddNewInventoryEnabled")]
		public string AddNewInventoryEnabled { get; set; }

		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public string CameraBarcodeScannerEnabled { get; set; }

		[XmlElement(ElementName = "NavigateBackEnabled")]
		public string NavigateBackEnabled { get; set; }

		[XmlElement(ElementName = "SearchByProperties")]
		public SearchByProperties SearchByProperties { get; set; }

		[XmlElement(ElementName = "SearchByScannerResultListDisplayProperties")]
		public SearchByScannerResultListDisplayProperties SearchByScannerResultListDisplayProperties { get; set; }
	}

	[XmlRoot(ElementName = "SearchInCatalogByItemCodeResultListDisplayProperties")]
	public class SearchInCatalogByItemCodeResultListDisplayProperties
	{

		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
	}

	[XmlRoot(ElementName = "SearchInCatalogByItemNameResultListDisplayProperties")]
	public class SearchInCatalogByItemNameResultListDisplayProperties
	{

		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
	}

	[XmlRoot(ElementName = "SearchInCatalogResultListsDisplayProperties")]
	public class SearchInCatalogResultListsDisplayProperties
	{

		[XmlElement(ElementName = "SearchInCatalogByItemCodeResultListDisplayProperties")]
		public SearchInCatalogByItemCodeResultListDisplayProperties SearchInCatalogByItemCodeResultListDisplayProperties { get; set; }

		[XmlElement(ElementName = "SearchInCatalogByItemNameResultListDisplayProperties")]
		public SearchInCatalogByItemNameResultListDisplayProperties SearchInCatalogByItemNameResultListDisplayProperties { get; set; }
	}

	[XmlRoot(ElementName = "SearchInCatalogScreenConfiguration")]
	public class SearchInCatalogScreenConfiguration
	{

		[XmlElement(ElementName = "AddNewItemIntoCatalogEnabled")]
		public string AddNewItemIntoCatalogEnabled { get; set; }

		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public string CameraBarcodeScannerEnabled { get; set; }

		[XmlElement(ElementName = "SearchInCatalogResultListsDisplayProperties")]
		public SearchInCatalogResultListsDisplayProperties SearchInCatalogResultListsDisplayProperties { get; set; }
	}

	[XmlRoot(ElementName = "SearchInLocationByItemSerialResultListDisplayProperties")]
	public class SearchInLocationByItemSerialResultListDisplayProperties
	{

		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
	}

	[XmlRoot(ElementName = "SearchInLocationByItemCodeResultListDisplayProperties")]
	public class SearchInLocationByItemCodeResultListDisplayProperties
	{

		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
	}

	[XmlRoot(ElementName = "SearchInLocationByItemNameResultListDisplayProperties")]
	public class SearchInLocationByItemNameResultListDisplayProperties
	{

		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
	}

	[XmlRoot(ElementName = "SearchInLocationResultListsDisplayProperties")]
	public class SearchInLocationResultListsDisplayProperties
	{

		[XmlElement(ElementName = "SearchInLocationByItemSerialResultListDisplayProperties")]
		public SearchInLocationByItemSerialResultListDisplayProperties SearchInLocationByItemSerialResultListDisplayProperties { get; set; }

		[XmlElement(ElementName = "SearchInLocationByItemCodeResultListDisplayProperties")]
		public SearchInLocationByItemCodeResultListDisplayProperties SearchInLocationByItemCodeResultListDisplayProperties { get; set; }

		[XmlElement(ElementName = "SearchInLocationByItemNameResultListDisplayProperties")]
		public SearchInLocationByItemNameResultListDisplayProperties SearchInLocationByItemNameResultListDisplayProperties { get; set; }
	}

	[XmlRoot(ElementName = "SearchInLocationScreenConfiguration")]
	public class SearchInLocationScreenConfiguration
	{

		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public string CameraBarcodeScannerEnabled { get; set; }

		[XmlElement(ElementName = "SearchInLocationResultListsDisplayProperties")]
		public SearchInLocationResultListsDisplayProperties SearchInLocationResultListsDisplayProperties { get; set; }

		[XmlElement(ElementName = "AddNewItemIntoCatalogEnabled")]
		public string AddNewItemIntoCatalogEnabled { get; set; }
	}

	[XmlRoot(ElementName = "Search")]
	public class Search
	{

		[XmlElement(ElementName = "SearchByScannerScreenConfiguration")]
		public SearchByScannerScreenConfiguration SearchByScannerScreenConfiguration { get; set; }

		[XmlElement(ElementName = "SearchInCatalogScreenConfiguration")]
		public SearchInCatalogScreenConfiguration SearchInCatalogScreenConfiguration { get; set; }

		[XmlElement(ElementName = "SearchInLocationScreenConfiguration")]
		public SearchInLocationScreenConfiguration SearchInLocationScreenConfiguration { get; set; }

		[XmlElement(ElementName = "IgnoreChar")]
		public string IgnoreChar { get; set; }
	}

	[XmlRoot(ElementName = "AddNewLocationScreen")]
	public class AddNewLocationScreen
	{

		[XmlElement(ElementName = "ScreenEnabled")]
		public string ScreenEnabled { get; set; }

		[XmlElement(ElementName = "ScreenEnabledOffline")]
		public string ScreenEnabledOffline { get; set; }
	}

	[XmlRoot(ElementName = "ItemCodeSummaryScreen")]
	public class ItemCodeSummaryScreen
	{

		[XmlElement(ElementName = "ScreenEnabled")]
		public string ScreenEnabled { get; set; }
	}

	[XmlRoot(ElementName = "InventoryMoveSearchProperty")]
	public class InventoryMoveSearchProperty
	{

		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }

		[XmlAttribute(AttributeName = "id")]
		public String Id { get; set; }
	}

	[XmlRoot(ElementName = "MoveInventoriesScreen")]
	public class MoveInventoriesScreen
	{

		[XmlElement(ElementName = "InventoryMoveSearchProperty")]
		public InventoryMoveSearchProperty InventoryMoveSearchProperty { get; set; }

		[XmlElement(ElementName = "ScreenEnabled")]
		public string ScreenEnabled { get; set; }
	}

	[XmlRoot(ElementName = "AddQInventoryItemsInFastWayScreen")]
	public class AddQInventoryItemsInFastWayScreen
	{

		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public string CameraBarcodeScannerEnabled { get; set; }

		[XmlElement(ElementName = "ScreenEnabled")]
		public string ScreenEnabled { get; set; }
	}

	[XmlRoot(ElementName = "DefaultValues")]
	public class DefaultValues
	{

		[XmlElement(ElementName = "DefaultItemCode")]
		public string DefaultItemCode { get; set; }

		[XmlElement(ElementName = "DefaultQuantity")]
		public string DefaultQuantity { get; set; }
	}

	[XmlRoot(ElementName = "AddSNInventoryItemsInFastWayScreen")]
	public class AddSNInventoryItemsInFastWayScreen
	{

		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public string CameraBarcodeScannerEnabled { get; set; }

		[XmlElement(ElementName = "DefaultValues")]
		public DefaultValues DefaultValues { get; set; }

		[XmlElement(ElementName = "ScreenEnabled")]
		public string ScreenEnabled { get; set; }
	}

	[XmlRoot(ElementName = "WarehouseScreenRFID")]
	public class WarehouseScreenRFID
	{

		[XmlElement(ElementName = "ScreenEnabled")]
		public string ScreenEnabled { get; set; }

		[XmlElement(ElementName = "WarehouseScreenRFIDConnectionBeforeOpenRequired")]
		public string WarehouseScreenRFIDConnectionBeforeOpenRequired { get; set; }
	}

	[XmlRoot(ElementName = "AssertInventoryScreen")]
	public class AssertInventoryScreen
	{

		[XmlElement(ElementName = "InventoryWizard")]
		public string InventoryWizard { get; set; }

		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public string CameraBarcodeScannerEnabled { get; set; }
	}

	[XmlRoot(ElementName = "ScreensConfiguration")]
	public class ScreensConfiguration
	{

		[XmlElement(ElementName = "AddNewLocationScreen")]
		public AddNewLocationScreen AddNewLocationScreen { get; set; }

		[XmlElement(ElementName = "ItemCodeSummaryScreen")]
		public ItemCodeSummaryScreen ItemCodeSummaryScreen { get; set; }

		[XmlElement(ElementName = "MoveInventoriesScreen")]
		public MoveInventoriesScreen MoveInventoriesScreen { get; set; }

		[XmlElement(ElementName = "AddQInventoryItemsInFastWayScreen")]
		public AddQInventoryItemsInFastWayScreen AddQInventoryItemsInFastWayScreen { get; set; }

		[XmlElement(ElementName = "AddSNInventoryItemsInFastWayScreen")]
		public AddSNInventoryItemsInFastWayScreen AddSNInventoryItemsInFastWayScreen { get; set; }

		[XmlElement(ElementName = "WarehouseScreenRFID")]
		public WarehouseScreenRFID WarehouseScreenRFID { get; set; }

		[XmlElement(ElementName = "AssertInventoryScreen")]
		public AssertInventoryScreen AssertInventoryScreen { get; set; }
	}

	[XmlRoot(ElementName = "InventoryImage")]
	public class InventoryImage
	{

		[XmlElement(ElementName = "InventoryImageEnabled")]
		public string InventoryImageEnabled { get; set; }

		[XmlElement(ElementName = "ImageQuality")]
		public string ImageQuality { get; set; }

		[XmlElement(ElementName = "InventoryImagePropertyId")]
		public string InventoryImagePropertyId { get; set; }
	}

	[XmlRoot(ElementName = "FieldMapping")]
	public class FieldMapping
	{

		[XmlAttribute(AttributeName = "name")]
		public String Name { get; set; }

		[XmlAttribute(AttributeName = "dateFormat")]
		public String DateFormat { get; set; }

		[XmlAttribute(AttributeName = "inventoryPropertyId")]
		public String InventoryPropertyId { get; set; }
	}

	[XmlRoot(ElementName = "FieldMapping")]
	public class FieldMapping2
	{

		[XmlAttribute(AttributeName = "name")]
		public String Name { get; set; }

		[XmlAttribute(AttributeName = "inventoryPropertyId")]
		public String InventoryPropertyId { get; set; }

		[XmlAttribute(AttributeName = "reverseValue")]
		public String ReverseValue { get; set; }
	}

	[XmlRoot(ElementName = "FieldMapping")]
	public class FieldMapping3
	{

		[XmlAttribute(AttributeName = "name")]
		public String Name { get; set; }

		[XmlAttribute(AttributeName = "inventoryPropertyId")]
		public String InventoryPropertyId { get; set; }
	}

	[XmlRoot(ElementName = "FieldsMapping")]
	public class FieldsMapping
	{

		[XmlElement(ElementName = "FieldMapping")]
		public List<FieldMapping> FieldMapping { get; set; }

		[XmlElement(ElementName = "FieldMapping")]
		public FieldMapping2 FieldMapping2 { get; set; }

		[XmlElement(ElementName = "FieldMapping")]
		public FieldMapping3 FieldMapping3 { get; set; }
	}

	[XmlRoot(ElementName = "PrintingFormat")]
	public class PrintingFormat
	{

		[XmlElement(ElementName = "Format")]
		public string Format { get; set; }

		[XmlElement(ElementName = "FieldsMapping")]
		public FieldsMapping FieldsMapping { get; set; }
	}

	[XmlRoot(ElementName = "PrintingFormats")]
	public class PrintingFormats
	{

		[XmlElement(ElementName = "PrintingFormat")]
		public PrintingFormat PrintingFormat { get; set; }
	}

	[XmlRoot(ElementName = "ZebraPrinter")]
	public class ZebraPrinter
	{

		[XmlElement(ElementName = "PrintingFormats")]
		public PrintingFormats PrintingFormats { get; set; }
	}

	[XmlRoot(ElementName = "PrinterSettings")]
	public class PrinterSettings
	{

		[XmlElement(ElementName = "ZebraPrinter")]
		public ZebraPrinter ZebraPrinter { get; set; }
	}

	[XmlRoot(ElementName = "RFIDCommand")]
	public class RFIDCommand
	{

		[XmlAttribute(AttributeName = "command")]
		public String Command { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public String Type { get; set; }
	}

	[XmlRoot(ElementName = "RFIDCommands")]
	public class RFIDCommands
	{

		[XmlElement(ElementName = "RFIDCommand")]
		public List<RFIDCommand> RFIDCommand { get; set; }
	}

	[XmlRoot(ElementName = "RFID")]
	public class RFID
	{

		[XmlElement(ElementName = "QCodeType")]
		public string QCodeType { get; set; }

		[XmlElement(ElementName = "RFIDCommands")]
		public RFIDCommands RFIDCommands { get; set; }

		[XmlElement(ElementName = "RFIDTagWritten")]
		public string RFIDTagWritten { get; set; }

		[XmlElement(ElementName = "SNCodeType")]
		public string SNCodeType { get; set; }
	}

	[XmlRoot(ElementName = "Details")]
	public class Details6
	{

		[XmlAttribute(AttributeName = "default")]
		public String Default { get; set; }

		[XmlAttribute(AttributeName = "id")]
		public String Id { get; set; }

		[XmlAttribute(AttributeName = "itemtype")]
		public String Itemtype { get; set; }

		[XmlAttribute(AttributeName = "mandatory")]
		public String Mandatory { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public String Type { get; set; }

		[XmlAttribute(AttributeName = "typeview")]
		public String Typeview { get; set; }

		[XmlAttribute(AttributeName = "viewonly")]
		public String Viewonly { get; set; }

		[XmlAttribute(AttributeName = "negative_value_enable")]
		public String NegativeValueEnable { get; set; }
	}

	[XmlRoot(ElementName = "Field")]
	public class Field11
	{

		[XmlElement(ElementName = "DataSource")]
		public DataSource DataSource { get; set; }

		[XmlElement(ElementName = "DataTarget")]
		public DataTarget DataTarget { get; set; }

		[XmlElement(ElementName = "Details")]
		public Details6 Details6 { get; set; }

		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "Validation")]
	public class Validation
	{

		[XmlAttribute(AttributeName = "en")]
		public String En { get; set; }

		[XmlAttribute(AttributeName = "reg")]
		public String Reg { get; set; }
	}

	[XmlRoot(ElementName = "Validations")]
	public class Validations
	{

		[XmlElement(ElementName = "Validation")]
		public Validation Validation { get; set; }
	}

	[XmlRoot(ElementName = "Actions")]
	public class Actions5
	{

		[XmlElement(ElementName = "Validations")]
		public Validations Validations { get; set; }

		[XmlElement(ElementName = "SelectInFocus")]
		public string SelectInFocus { get; set; }
	}

	[XmlRoot(ElementName = "Field")]
	public class Field12
	{

		[XmlElement(ElementName = "Actions")]
		public Actions5 Actions5 { get; set; }

		[XmlElement(ElementName = "DataSource")]
		public DataSource DataSource { get; set; }

		[XmlElement(ElementName = "DataTarget")]
		public DataTarget DataTarget { get; set; }

		[XmlElement(ElementName = "Details")]
		public Details Details { get; set; }

		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "Actions")]
	public class Actions6
	{

		[XmlElement(ElementName = "AutoGenerateCode")]
		public string AutoGenerateCode { get; set; }

		[XmlElement(ElementName = "Validations")]
		public Validations Validations { get; set; }
	}

	[XmlRoot(ElementName = "Details")]
	public class Details7
	{

		[XmlAttribute(AttributeName = "default")]
		public String Default { get; set; }

		[XmlAttribute(AttributeName = "id")]
		public String Id { get; set; }

		[XmlAttribute(AttributeName = "itemtype")]
		public String Itemtype { get; set; }

		[XmlAttribute(AttributeName = "mandatory")]
		public String Mandatory { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public String Type { get; set; }

		[XmlAttribute(AttributeName = "typeview")]
		public String Typeview { get; set; }

		[XmlAttribute(AttributeName = "viewonly")]
		public String Viewonly { get; set; }

		[XmlAttribute(AttributeName = "add_enable")]
		public String AddEnable { get; set; }

		[XmlAttribute(AttributeName = "negative_value_enable")]
		public String NegativeValueEnable { get; set; }
	}

	[XmlRoot(ElementName = "Field")]
	public class Field13
	{

		[XmlElement(ElementName = "Actions")]
		public Actions6 Actions6 { get; set; }

		[XmlElement(ElementName = "DataSource")]
		public DataSource DataSource { get; set; }

		[XmlElement(ElementName = "DataTarget")]
		public DataTarget DataTarget { get; set; }

		[XmlElement(ElementName = "Details")]
		public Details7 Details7 { get; set; }

		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string Invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public string Id { get; set; }
	}

	[XmlRoot(ElementName = "EditFormSettings")]
	public class EditFormSettings
	{

		[XmlElement(ElementName = "Field")]
		public Field11 Field11 { get; set; }

		[XmlElement(ElementName = "Field")]
		public Field Field { get; set; }

		[XmlElement(ElementName = "Field")]
		public Field12 Field12 { get; set; }

		[XmlElement(ElementName = "Field")]
		public Field13 Field13 { get; set; }
	}

	[XmlRoot(ElementName = "FastStockInventoryItemsConfiguration")]
	public class FastStockInventoryItemsConfiguration
	{

		[XmlElement(ElementName = "DefaultAutomaticQuantity")]
		public string DefaultAutomaticQuantity { get; set; }

		[XmlElement(ElementName = "EditFormSettings")]
		public EditFormSettings EditFormSettings { get; set; }

		[XmlElement(ElementName = "AddDefaultQuantityMode")]
		public string AddDefaultQuantityMode { get; set; }

		[XmlElement(ElementName = "InsertNotExistInCatalogItems")]
		public string InsertNotExistInCatalogItems { get; set; }

		[XmlElement(ElementName = "InsertDetailsForNotExistInCatalogItems")]
		public string InsertDetailsForNotExistInCatalogItems { get; set; }

		[XmlElement(ElementName = "CaseSensitiveItemCode")]
		public string CaseSensitiveItemCode { get; set; }

		[XmlElement(ElementName = "CameraBarcodeScannerStockLocation")]
		public string CameraBarcodeScannerStockLocation { get; set; }

		[XmlElement(ElementName = "CameraBarcodeScannerStockInventory")]
		public string CameraBarcodeScannerStockInventory { get; set; }
	}

	[XmlRoot(ElementName = "Profile")]
	public class Profile
	{

		[XmlElement(ElementName = "InventoryProcessInformation")]
		public InventoryProcessInformation InventoryProcessInformation { get; set; }

		[XmlElement(ElementName = "InventoryProcessConfiguration")]
		public InventoryProcessConfiguration InventoryProcessConfiguration { get; set; }

		[XmlElement(ElementName = "ScannerType")]
		public string ScannerType { get; set; }

		[XmlElement(ElementName = "LocationInventoryListScreenConfiguration")]
		public LocationInventoryListScreenConfiguration LocationInventoryListScreenConfiguration { get; set; }

		[XmlElement(ElementName = "InventoryListDefaultUIConfiguration")]
		public InventoryListDefaultUIConfiguration InventoryListDefaultUIConfiguration { get; set; }

		[XmlElement(ElementName = "DatabaseSettings")]
		public DatabaseSettings DatabaseSettings { get; set; }

		[XmlElement(ElementName = "Forms")]
		public Forms Forms { get; set; }

		[XmlElement(ElementName = "Search")]
		public Search Search { get; set; }

		[XmlElement(ElementName = "ScreensConfiguration")]
		public ScreensConfiguration ScreensConfiguration { get; set; }

		[XmlElement(ElementName = "InventoryImage")]
		public InventoryImage InventoryImage { get; set; }

		[XmlElement(ElementName = "PrinterSettings")]
		public PrinterSettings PrinterSettings { get; set; }

		[XmlElement(ElementName = "RFID")]
		public RFID RFID { get; set; }

		[XmlElement(ElementName = "FastStockInventoryItemsConfiguration")]
		public FastStockInventoryItemsConfiguration FastStockInventoryItemsConfiguration { get; set; }

		[XmlElement(ElementName = "BarcodeManipulations")]
		public string BarcodeManipulations { get; set; }

		[XmlElement(ElementName = "Version")]
		public string Version { get; set; }

		[XmlElement(ElementName = "Customer")]
		public Customer Customer { get; set; }
	}


}
