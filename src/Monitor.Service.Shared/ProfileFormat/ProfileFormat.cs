using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Monitor.Service.Model;

namespace Count4U.Service.Format
{
	[Serializable()]
	public class Rootobject
	{
		public Xml xml { get; set; }
		public Profile Profile { get; set; }

		public Rootobject()
		{
			xml = new Xml();
			Profile = new Profile();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Xml")]
	public class Xml
	{
		[XmlAttribute(AttributeName = "version")]
		public string version { get; set; }


		[XmlAttribute(AttributeName = "encoding")]
		public string encoding { get; set; }

		public  Xml()
		{
			version = "";
			encoding = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Profile")]
	public class Profile
	{
		[XmlElement(ElementName = "InventoryProcessInformation")]
		public InventoryProcessInformation InventoryProcessInformation { get; set; }

		[XmlElement(ElementName = "InventoryProcessConfiguration")]
		public InventoryProcessConfiguration InventoryProcessConfiguration { get; set; }

		[XmlIgnore]
		public object[] comment;

		[XmlElement(ElementName = "ScannerType")]
		public string ScannerType { get; set; }

		[XmlElement(ElementName = "LocationInventoryListScreenConfiguration")]
		public LocationinventoryListScreenConfiguration LocationInventoryListScreenConfiguration { get; set; }

		[XmlElement(ElementName = "InventoryListDefaultUIConfiguration")]
		public InventoryListDefaultUIConfiguration InventoryListDefaultUIConfiguration { get; set; }

		[XmlElement(ElementName = "DatabaseSettings")]
		public DatabaseSettings DatabaseSettings { get; set; }

		[XmlElement(ElementName = "FastStockInventoryItemsConfiguration")]
		public FastStockInventoryItemsConfiguration FastStockInventoryItemsConfiguration { get; set; }


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

	
		[XmlIgnore]   //NOTUSE		? не понятно есть или нет
		public BarcodeManipulations BarcodeManipulations;

		[XmlElement(ElementName = "Version")]
		public string Version { get; set; }

		[XmlElement(ElementName = "RfidType")]
		public string RfidType { get; set; }

		[XmlElement(ElementName = "NetworkType")]
		public string NetworkType { get; set; }

		//[XmlElement(ElementName = "Customer")]
		//public Customer Customer { get; set; }

		public Profile()
		{
			InventoryProcessInformation = new InventoryProcessInformation();
			InventoryProcessConfiguration = new InventoryProcessConfiguration();
			comment = new object[] { };
			ScannerType = "";
			LocationInventoryListScreenConfiguration = new LocationinventoryListScreenConfiguration();
			InventoryListDefaultUIConfiguration = new InventoryListDefaultUIConfiguration();
			DatabaseSettings = new DatabaseSettings();
			Forms = new Forms();
			Search = new Search();
			ScreensConfiguration = new ScreensConfiguration();
			InventoryImage = new InventoryImage();
			PrinterSettings = new PrinterSettings();
			RFID = new RFID();
			FastStockInventoryItemsConfiguration = new FastStockInventoryItemsConfiguration();
			BarcodeManipulations = new BarcodeManipulations();
			Version = "";
			RfidType = "";
			NetworkType = "Wifi";
		//Customer = new Customer();
	}

	
	}

	[Serializable()]
	[XmlRoot(ElementName = "BarcodeManipulations")]
	public class BarcodeManipulations
	{
		[XmlElement(ElementName = "Manipulation")]
		public Manipulation Manipulation { get; set; }

		[XmlElement(ElementName = "GroupManipulation")]
		public GroupManipulation GroupManipulation { get; set; }

		public BarcodeManipulations()
		{
			Manipulation = new Manipulation(); ;
			GroupManipulation = new GroupManipulation();
		}
	}
	//inventoryPropertyId
	//[XmlAttribute(AttributeName = "inventoryPropertyId")]
	[Serializable()]
	[XmlRoot(ElementName = "Manipulation")]
	public class Manipulation
	{
		[XmlAttribute(AttributeName = "type")]
		public string manipulationType { get; set; }

		[XmlAttribute(AttributeName = "char")]
		public string manipulationChar { get; set; }

		[XmlAttribute(AttributeName = "case_sensitive")]
		public bool case_sensitive { get; set; }

		[XmlAttribute(AttributeName = "target_length")]
		public string target_length { get; set; }

		[XmlAttribute(AttributeName = "number_of_characters")]
		public string number_of_characters { get; set; }

		[XmlAttribute(AttributeName = "direction")]
		public string direction { get; set; }

		
		public Manipulation()
		{
			manipulationType = "";
			manipulationChar = "";
			case_sensitive = false;
			target_length = "";
			number_of_characters = "";
			direction = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "GroupManipulation")]
	public class GroupManipulation
	{
		[XmlElement(ElementName = "Manipulation")]
		public List<Manipulation> Manipulation { get; set; }
		public GroupManipulation()
		{
			Manipulation = new List<Manipulation>();
		}
	}




	[Serializable()]
	[XmlRoot(ElementName = "InventoryProcessInformation")]
	public class InventoryProcessInformation
	{
		[XmlElement(ElementName = "Customer")]
		public Customer Customer { get; set; }
		[XmlElement(ElementName = "Branch")]
		public Branch Branch { get; set; }
		[XmlElement(ElementName = "Inventory")]
		public Inventory Inventory { get; set; }

		public InventoryProcessInformation()
		{
			Customer = new Customer();
			Branch = new Branch();
			Inventory = new Inventory();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Customer")]
	public class Customer
	{
		[XmlAttribute(AttributeName = "name")]
		public string name { get; set; } = "";
		[XmlAttribute(AttributeName = "code")]
		public string code { get; set; } = "";

		public Customer()
		{
			name = "";
			code = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Branch")]
	public class Branch
	{
		[XmlAttribute(AttributeName = "name")]
		public string name { get; set; }
		[XmlAttribute(AttributeName = "code")]
		public string code { get; set; }
		public Branch()
		{
			name = "";
			code = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Inventory")]
	public class Inventory
	{
		[XmlAttribute(AttributeName = "code")]
		public string code { get; set; }
		[XmlAttribute(AttributeName = "created_date")]
		public string created_date { get; set; }

		//[XmlAttribute(AttributeName = "inventor_date")]
		//public string inventor_date { get; set; }

		public Inventory()
		{
			created_date = "";
			code = "";
			//inventor_date = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "InventoryProcessConfiguration")]
	public class InventoryProcessConfiguration
	{
		[XmlElement(ElementName = "InventoryProcessMode")]
		public InventoryProcessMode InventoryProcessMode { get; set; }

		public InventoryProcessConfiguration()
		{
			InventoryProcessMode = new InventoryProcessMode();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "InventoryProcessMode")]
	public class InventoryProcessMode
	{
		[XmlElement(ElementName = "AssertModeEnabled")]
		public bool AssertModeEnabled { get; set; }
		[XmlElement(ElementName = "StockModeEnabled")]
		public bool StockModeEnabled { get; set; }
		public InventoryProcessMode()
		{
			AssertModeEnabled = true;
			StockModeEnabled = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "LocationinventoryListScreenConfiguration")]
	public class LocationinventoryListScreenConfiguration
	{
		[XmlElement(ElementName = "AddNewInventoryEnabled")]
		public bool AddNewInventoryEnabled { get; set; }
		[XmlElement(ElementName = "TemplateInventoriesEnabled")]
		public bool TemplateInventoriesEnabled { get; set; }
		[XmlElement(ElementName = "SignatureToVerifyClosureOfLocationRequired")]
		public bool SignatureToVerifyClosureOfLocationRequired { get; set; }
		[XmlElement(ElementName = "AddNewInventoryOfflineEnabled")]
		public bool AddNewInventoryOfflineEnabled { get; set; }

		public LocationinventoryListScreenConfiguration()
		{
			AddNewInventoryEnabled = false;
			TemplateInventoriesEnabled = false;
			SignatureToVerifyClosureOfLocationRequired = false;
			AddNewInventoryOfflineEnabled = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "InventoryListDefaultUIConfiguration")]
	public class InventoryListDefaultUIConfiguration
	{
		[XmlElement(ElementName = "ShowInventoryImageIndicator")]
		public bool ShowInventoryImageIndicator { get; set; }

		[XmlElement(ElementName = "InventoryItemsProperties")]
		public InventoryItemsProperties InventoryItemsProperties { get; set; }

		public InventoryListDefaultUIConfiguration()
		{
			ShowInventoryImageIndicator = false;
			InventoryItemsProperties = new InventoryItemsProperties();
		}

		public InventoryListDefaultUIConfiguration(int len)
		{
			ShowInventoryImageIndicator = false;
			InventoryItemsProperties = new InventoryItemsProperties(len);
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "InventoryItemsProperties")]
	public class InventoryItemsProperties
	{
		//public Inventoryitemdisplayproperty[] InventoryItemDisplayProperty { get; set; }

		[XmlElement(ElementName = "InventoryItemDisplayProperty")]
		public List<InventoryItemDisplayProperty> InventoryItemDisplayProperty { get; set; }

		[XmlIgnore]
		public InventoryItemDisplayProperty InventoryItemDisplayPropertyEmpty { get; set; }
		public InventoryItemsProperties()
		{
			InventoryItemDisplayProperty = new List<InventoryItemDisplayProperty> ();
			InventoryItemDisplayPropertyEmpty = new InventoryItemDisplayProperty();
		}
		public InventoryItemsProperties(int lenght)
		{
			InventoryItemDisplayProperty = new List<InventoryItemDisplayProperty>();
			for( int i =0; i<lenght; i++)
			{
				InventoryItemDisplayProperty.Add(new InventoryItemDisplayProperty());
			}
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "InventoryItemDisplayProperty")]
	public class InventoryItemDisplayProperty
	{
		[XmlAttribute(AttributeName = "id")]
		public string id { get; set; }

		[XmlAttribute(AttributeName = "itemtype")]
		public string itemtype { get; set; }

		//XmlIgnore
		//public int index;

		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }
 
	
		[XmlElement(ElementName = "invalid")]
		public bool invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public int index { get; set; }

		[XmlIgnore]
		public bool IsOpen { get; set; } = true;

		public void ToggleButton()
		{
			IsOpen = !IsOpen;
		}

		public InventoryItemDisplayProperty()
		{
			id = "";
			itemtype = "";
			Title = new Title();
			invalid = false;
			//indexString = "0";
			index = 0;
		}

		public InventoryItemDisplayProperty(InventoryItemDisplayProperty item)
		{
			if (item == null) return;
			id = item.id;
			itemtype = item.itemtype;
			Title = new Title();
			if (item.Title != null)
			{
				Title.en = item.Title.en;
				Title.he = item.Title.he;
			}
			invalid = item.invalid;
			index = item.index;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Title")]
	public class Title
	{
		[XmlAttribute(AttributeName = "en")]
		public string en { get; set; }
		[XmlAttribute(AttributeName = "he")]
		public string he { get; set; }
		public Title()
		{
			en = "";
			he = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "DatabaseSettings")]
	public class DatabaseSettings
	{
		[XmlElement(ElementName = "UIDKey")]
		public string UIDKey { get; set; }

		[XmlIgnore]
		public List<UidKey> UIDKeyList { get; set; } 

		[XmlElement(ElementName = "CurrentInventoryDeviceIdProperty")]
		public string CurrentInventoryDeviceIdProperty { get; set; }

		[XmlElement(ElementName = "CurrentInventoryUserNameProperty")]
		public string CurrentInventoryUserNameProperty { get; set; }

		[XmlElement(ElementName = "ClearInventoryDataAfterUpload")]
		public bool ClearInventoryDataAfterUpload { get; set; }

		[XmlElement(ElementName = "CurrentInventoryDeviceNameProperty")]
		public string CurrentInventoryDeviceNameProperty { get; set; }

		public DatabaseSettings()
		{
			UIDKey = "";
			CurrentInventoryDeviceIdProperty = "";
			CurrentInventoryUserNameProperty = "";
			ClearInventoryDataAfterUpload = false;
			CurrentInventoryDeviceNameProperty = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Forms")]
	public class Forms
	{
		[XmlElement(ElementName = "Form")]
		public Form Form { get; set; }
		public  Forms ()
		{
			Form = new Form();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Form")]
	public class Form
	{
		[XmlAttribute(AttributeName = "id")]
		public string id { get; set; }

		[XmlElement(ElementName = "Field")]
		public List<Field> Fields { get; set; }

		[XmlElement(ElementName = "KeepAllFieldsOnItemCodeChange")]
		public bool KeepAllFieldsOnItemCodeChange { get; set; }
		public Form()
		{
			id = "";
			Fields = new List<Field> ();
			KeepAllFieldsOnItemCodeChange = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Field")]
	public class Field
	{
		[XmlElement(ElementName = "Actions")]
		public Actions Actions { get; set; }

		[XmlElement(ElementName = "DataSource")]
		public Datasource DataSource { get; set; }

		[XmlElement(ElementName = "DataTarget")]
		public Datatarget DataTarget { get; set; }

		[XmlElement(ElementName = "Details")]
		public Details Details { get; set; }

		[XmlElement(ElementName = "Titles")]
		public Titles Titles { get; set; }

		[XmlElement(ElementName = "invalid")]
		public string invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public string id { get; set; }

		[XmlIgnore]
		public bool IsOpen { get; set; } = true;
 		public void ToggleButton()
		{
			IsOpen = !IsOpen;
		}

		public  Field()
		{
			DataSource = new Datasource();
			DataTarget = new Datatarget();
			Details = new Details();
			Titles = new Titles();
			invalid = "";
			id = "";
			Actions = new Actions();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Datasource")]
	public class Datasource
	{
		[XmlAttribute(AttributeName = "fieldname")]
		public string fieldname { get; set; }

		[XmlAttribute(AttributeName = "keyboard_type")]
		public string keyboard_type { get; set; }

		[XmlAttribute(AttributeName = "tablename")]
		public string tablename { get; set; }

		[XmlAttribute(AttributeName = "fieldnametoshow")]
		public string fieldnametoshow { get; set; }

		public Datasource()
		{
			fieldname = "";
			keyboard_type = "";
			tablename = "";
			fieldnametoshow = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Datatarget")]
	public class Datatarget
	{
		[XmlAttribute(AttributeName = "fieldname")]
		public string fieldname { get; set; }

		[XmlAttribute(AttributeName = "tablename")]
		public string tablename { get; set; }

		public Datatarget()
		{
			fieldname = "";
			tablename = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Details")]
	public class Details
	{
		[XmlAttribute(AttributeName = "default")]
		public string _default { get; set; }
		[XmlAttribute(AttributeName = "id")]
		public string id { get; set; }
		[XmlAttribute(AttributeName = "itemtype")]
		public string itemtype { get; set; }
		[XmlAttribute(AttributeName = "mandatory")]
		public bool mandatory { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string type { get; set; }
		[XmlAttribute(AttributeName = "typeview")]
		public string typeview { get; set; }
		[XmlAttribute(AttributeName = "viewonly")]
		public bool viewonly { get; set; }
		[XmlAttribute(AttributeName = "camera_barcode_scanner_enable")]
		public bool camera_barcode_scanner_enable { get; set; }

		[XmlAttribute(AttributeName = "negative_value_enable")]
		public bool negative_value_enable { get; set; }

		[XmlAttribute(AttributeName = "add_enable")]
		public bool add_enable { get; set; }

		[XmlAttribute(AttributeName = "clear_enable")]
		public bool clear_enable { get; set; }

		[XmlAttribute(AttributeName = "zero_value_enable")]
		public bool zero_value_enable { get; set; }


		public Details()
		{
			_default = "";
			id = "";
			itemtype = "";
			mandatory = true;
			type = "";
			typeview = "";
			viewonly = false;
			camera_barcode_scanner_enable = false;
			negative_value_enable = false;
			add_enable = false;
			clear_enable = false;
			zero_value_enable = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Titles")]
	public class Titles
	{
		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }

		[XmlElement(ElementName = "Description")]
		public Description Description { get; set; }

		public Titles()
		{
			Title = new Title();
			Description = new Description();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Description")]
	public class Description
	{
		[XmlAttribute(AttributeName = "en")]
		public string en { get; set; }
		public Description()
		{
			en = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Actions")]
	public class Actions
	{
		[XmlAttribute(AttributeName = "SelectInFocus")]
		public bool SelectInFocus { get; set; }
	
		[XmlAttribute(AttributeName = "AutoGenerateCode")]
		public string AutoGenerateCode { get; set; }

		[XmlElement(ElementName = "EnabledFilters")]
		public Enabledfilters EnabledFilters { get; set; }

		[XmlElement(ElementName = "Validations")]
		public Validations Validations { get; set; }

		

		public Actions ()
		{
			SelectInFocus = false;
			AutoGenerateCode = "";
			EnabledFilters = new Enabledfilters();
			Validations = new Validations();
	}
	}

	
	[Serializable()]
	[XmlRoot(ElementName = "EnabledFilters")]
	public class Enabledfilters
	{
		[XmlElement(ElementName = "EnabledFiler")]
		public List<Enabledfiler> EnabledFiler { get; set; }

		public  Enabledfilters	 ()
		{
			EnabledFiler = new List<Enabledfiler>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "EnabledFilter")]
	public class Enabledfiler
	{
		[XmlElement(ElementName = "Enabled")]
		public Enabled Enabled { get; set; }

		[XmlElement(ElementName = "Filter")]
		public Filter Filter { get; set; }
		public Enabledfiler()
		{
			Enabled = new Enabled();
			Filter = new Filter();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Enabled")]
	public class Enabled
	{
		public string fieldcondition { get; set; }
	}

	public class Filter
	{
		[XmlAttribute(AttributeName = "type")]
		public string type { get; set; }

		[XmlAttribute(AttributeName = "value")]
		public string value { get; set; }

		[XmlAttribute(AttributeName = "valueToReg")]
		public string valueToReg { get; set; }

		public Filter()
		{
			type = "";
			value = "";
			valueToReg = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Search")]
	public class Search
	{
		[XmlElement(ElementName = "IgnoreChar")]
		public string IgnoreChar { get; set; }

		[XmlElement(ElementName = "SearchByScannerScreenConfiguration")]
		public SearchByScannerScreenConfiguration SearchByScannerScreenConfiguration { get; set; }
		[XmlElement(ElementName = "SearchInCatalogScreenConfiguration")]
		public SearchInCatalogScreenConfiguration SearchInCatalogScreenConfiguration { get; set; }
		[XmlElement(ElementName = "SearchInLocationScreenConfiguration")]
		public SearchInLocationScreenConfiguration SearchInLocationScreenConfiguration { get; set; }
		

		public Search()
		{
			SearchByScannerScreenConfiguration = new SearchByScannerScreenConfiguration();
			SearchInCatalogScreenConfiguration = new SearchInCatalogScreenConfiguration();
			SearchInLocationScreenConfiguration = new SearchInLocationScreenConfiguration();
			IgnoreChar = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchByScannerScreenConfiguration")]
	public class SearchByScannerScreenConfiguration
	{
		[XmlElement(ElementName = "AddNewInventoryEnabled")]
		public bool AddNewInventoryEnabled { get; set; }
		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public bool CameraBarcodeScannerEnabled { get; set; }

		[XmlElement(ElementName = "NavigateBackEnabled")]
		public bool NavigateBackEnabled { get; set; }

		[XmlElement(ElementName = "SearchByProperties")]
		public SearchByProperties SearchByProperties { get; set; }

		[XmlElement(ElementName = "SearchByScannerResultListDisplayProperties")]
		public SearchByScannerResultListDisplayProperties SearchByScannerResultListDisplayProperties { get; set; }


		public SearchByScannerScreenConfiguration()
		{
			AddNewInventoryEnabled = true;
			CameraBarcodeScannerEnabled = true;
			NavigateBackEnabled = false;
			SearchByProperties = new SearchByProperties();
			SearchByScannerResultListDisplayProperties = new SearchByScannerResultListDisplayProperties();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchByProperties")]
	public class SearchByProperties
	{
		[XmlElement(ElementName = "SearchByProperty")]
		public List<SearchByProperty> SearchByProperty { get; set; }

		public SearchByProperties ()
		{
			SearchByProperty = new List<SearchByProperty>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchByProperty")]
	public class SearchByProperty
	{
		[XmlAttribute(AttributeName = "id")]
		public string id { get; set; }

		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }

		[XmlElement(ElementName = "id")]
		public int index { get; set; }

		public SearchByProperty()
		{
			id = "";
			Title = new Title();
			index = 0;
		}
	}


	[Serializable()]
	[XmlRoot(ElementName = "SearchByScannerResultListDisplayProperties")]
	public class SearchByScannerResultListDisplayProperties
	{
		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
		public SearchByScannerResultListDisplayProperties()
		{
			SearchDisplayProperty = new List<SearchDisplayProperty>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchDisplayProperty")]
	public class SearchDisplayProperty
	{
		[XmlAttribute(AttributeName = "id")]
		public string id { get; set; }

		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }


		//[XmlElement(ElementName = "he")]
		//public string he { get; set; }
	
		[XmlElement(ElementName = "invalid")]
		public bool invalid { get; set; }

		[XmlElement(ElementName = "id")]
		public int index { get; set; }

		[XmlIgnore]
		public bool IsOpen { get; set; } = true;

		public void ToggleButton()
		{
			IsOpen = !IsOpen;
		}

		public SearchDisplayProperty()
		{
			id = "";
			index = 0;
			Title = new Title();
			invalid = false;
			//he = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInCatalogScreenConfiguration")]
	public class SearchInCatalogScreenConfiguration
	{
		[XmlElement(ElementName = "AddNewItemIntoCatalogEnabled")]
		public bool AddNewItemIntoCatalogEnabled { get; set; }
		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public bool CameraBarcodeScannerEnabled { get; set; }
		[XmlElement(ElementName = "SearchInCatalogResultListsDisplayProperties")]
		public SearchInCatalogResultListsDisplayProperties SearchInCatalogResultListsDisplayProperties { get; set; }

		public SearchInCatalogScreenConfiguration()
		{
			AddNewItemIntoCatalogEnabled = false;
			CameraBarcodeScannerEnabled = false;
			SearchInCatalogResultListsDisplayProperties = new SearchInCatalogResultListsDisplayProperties();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInCatalogResultListsDisplayProperties")]
	public class SearchInCatalogResultListsDisplayProperties
	{
		[XmlElement(ElementName = "SearchInCatalogByItemCodeResultListDisplayProperties")]
		public SearchInCatalogByItemCodeResultListDisplayProperties SearchInCatalogByItemCodeResultListDisplayProperties { get; set; }

		[XmlElement(ElementName = "SearchInCatalogByItemNameResultListDisplayProperties")]
		public SearchInCatalogByItemNameResultListDisplayProperties SearchInCatalogByItemNameResultListDisplayProperties { get; set; }

		[XmlElement(ElementName = "SearchInCatalogByItemCodeOrNameResultListDisplayProperties")]
		public SearchInCatalogByItemCodeOrNameResultListDisplayProperties SearchInCatalogByItemCodeOrNameResultListDisplayProperties { get; set; }

		
		public SearchInCatalogResultListsDisplayProperties()
		{
			SearchInCatalogByItemCodeResultListDisplayProperties = new SearchInCatalogByItemCodeResultListDisplayProperties();
			SearchInCatalogByItemNameResultListDisplayProperties = new SearchInCatalogByItemNameResultListDisplayProperties();
			SearchInCatalogByItemCodeOrNameResultListDisplayProperties = new SearchInCatalogByItemCodeOrNameResultListDisplayProperties();
		}
	}

	
	[Serializable()]
	[XmlRoot(ElementName = "SearchInCatalogByItemCodeResultListDisplayProperties")]
	public class SearchInCatalogByItemCodeResultListDisplayProperties
	{
		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
		public SearchInCatalogByItemCodeResultListDisplayProperties()
		{
			SearchDisplayProperty = new List<SearchDisplayProperty>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInCatalogByItemNameResultListDisplayProperties")]
	public class SearchInCatalogByItemNameResultListDisplayProperties
	{
		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
		public SearchInCatalogByItemNameResultListDisplayProperties()
		{
			SearchDisplayProperty = new List<SearchDisplayProperty>();
		}
	}

	
	[Serializable()]
	[XmlRoot(ElementName = "SearchInCatalogByItemCodeOrNameResultListDisplayProperties")]
	public class SearchInCatalogByItemCodeOrNameResultListDisplayProperties
	{
		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }
		public SearchInCatalogByItemCodeOrNameResultListDisplayProperties()
		{
			SearchDisplayProperty = new List<SearchDisplayProperty>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInLocationScreenConfiguration")]
	public class SearchInLocationScreenConfiguration
	{
		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public bool CameraBarcodeScannerEnabled { get; set; }

		[XmlElement(ElementName = "SearchInLocationResultListsDisplayProperties")]
		public SearchInLocationResultListsDisplayProperties SearchInLocationResultListsDisplayProperties { get; set; }

		[XmlElement(ElementName = "AddNewItemIntoCatalogEnabled")]
		public bool AddNewItemIntoCatalogEnabled { get; set; }

		public SearchInLocationScreenConfiguration()
		{
			CameraBarcodeScannerEnabled = false;
			SearchInLocationResultListsDisplayProperties = new SearchInLocationResultListsDisplayProperties();
			AddNewItemIntoCatalogEnabled = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInLocationResultListsDisplayProperties")]
	public class SearchInLocationResultListsDisplayProperties
	{
		[XmlElement(ElementName = "SearchInLocationByItemSerialResultListDisplayProperties")]
		public SearchInLocationByItemSerialResultListDisplayProperties SearchInLocationByItemSerialResultListDisplayProperties { get; set; }

		[XmlElement(ElementName = "SearchInLocationByItemCodeResultListDisplayProperties")]
		public SearchInLocationByItemCodeResultListDisplayProperties SearchInLocationByItemCodeResultListDisplayProperties { get; set; }

		[XmlElement(ElementName = "SearchInLocationByItemNameResultListDisplayProperties")]
		public SearchInLocationByItemNameResultListDisplayProperties SearchInLocationByItemNameResultListDisplayProperties { get; set; }

		public SearchInLocationResultListsDisplayProperties()
		{
			SearchInLocationByItemSerialResultListDisplayProperties = new SearchInLocationByItemSerialResultListDisplayProperties();
			SearchInLocationByItemCodeResultListDisplayProperties = new SearchInLocationByItemCodeResultListDisplayProperties();
			SearchInLocationByItemNameResultListDisplayProperties = new SearchInLocationByItemNameResultListDisplayProperties();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInLocationByItemSerialResultListDisplayProperties")]
	public class SearchInLocationByItemSerialResultListDisplayProperties
	{
		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }

		public SearchInLocationByItemSerialResultListDisplayProperties()
		{
			SearchDisplayProperty = new List<SearchDisplayProperty>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInLocationByItemCodeResultListDisplayProperties")]
	public class SearchInLocationByItemCodeResultListDisplayProperties
	{
		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }

		public SearchInLocationByItemCodeResultListDisplayProperties()
		{
			SearchDisplayProperty = new List<SearchDisplayProperty>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInLocationByItemNameResultListDisplayProperties")]
	public class SearchInLocationByItemNameResultListDisplayProperties
	{
		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<SearchDisplayProperty> SearchDisplayProperty { get; set; }

		public SearchInLocationByItemNameResultListDisplayProperties()
		{
			SearchDisplayProperty = new List<SearchDisplayProperty>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "ScreensConfiguration")]
	public class ScreensConfiguration
	{
		[XmlElement(ElementName = "AddNewLocationScreen")]
		public AddNewLocationScreen AddNewLocationScreen { get; set; }
		[XmlElement(ElementName = "ItemCodeSummaryScreen")]
		public ItemCodeSummaryScreen ItemCodeSummaryScreen { get; set; }
		[XmlElement(ElementName = "MoveInventoriesScreen")]
		public MoveInventoriesScreen MoveInventoriesScreen { get; set; }

		[XmlElement(ElementName = "AddSNInventoryItemsInFastWayScreen")]
		public AddSNInventoryItemsInFastWayScreen AddSNInventoryItemsInFastWayScreen { get; set; }

		[XmlElement(ElementName = "AddQInventoryItemsInFastWayScreen")]
		public AddQInventoryItemsInFastWayScreen AddQInventoryItemsInFastWayScreen { get; set; }


		[XmlElement(ElementName = "WarehouseScreenRFID")]
		public WarehouseScreenRFID WarehouseScreenRFID { get; set; }

		[XmlElement(ElementName = "AssertInventoryScreen")]
		public AssertInventoryScreen AssertInventoryScreen { get; set; }

		public ScreensConfiguration()
		{
			AddNewLocationScreen = new AddNewLocationScreen();
			ItemCodeSummaryScreen = new ItemCodeSummaryScreen();
			MoveInventoriesScreen = new MoveInventoriesScreen();
			AddQInventoryItemsInFastWayScreen = new AddQInventoryItemsInFastWayScreen();
			AddSNInventoryItemsInFastWayScreen = new AddSNInventoryItemsInFastWayScreen();
			WarehouseScreenRFID = new WarehouseScreenRFID();
			AssertInventoryScreen = new AssertInventoryScreen();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "AddNewLocationScreen")]
	public class AddNewLocationScreen
	{
		[XmlElement(ElementName = "ScreenEnabled")]
		public bool ScreenEnabled { get; set; }

		[XmlElement(ElementName = "ScreenEnabledOffline")]
		public bool ScreenEnabledOffline { get; set; }

		public AddNewLocationScreen()
		{
			ScreenEnabled = false;
			ScreenEnabledOffline = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "ItemCodeSummaryScreen")]
	public class ItemCodeSummaryScreen
	{
		[XmlElement(ElementName = "ScreenEnabled")]
		public bool ScreenEnabled { get; set; }
		public ItemCodeSummaryScreen()
		{
			ScreenEnabled = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "MoveInventoriesScreen")]
	public class MoveInventoriesScreen
	{
		[XmlElement(ElementName = "InventoryMoveSearchProperty")]
		public InventoryMoveSearchProperty InventoryMoveSearchProperty { get; set; }
		[XmlElement(ElementName = "ScreenEnabled")]
		public bool ScreenEnabled { get; set; }
		public MoveInventoriesScreen()
		{
			InventoryMoveSearchProperty = new InventoryMoveSearchProperty();
		   ScreenEnabled = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "InventoryMoveSearchProperty")]
	public class InventoryMoveSearchProperty
	{
		[XmlAttribute(AttributeName = "id")]
		public string id { get; set; }

		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }
		public InventoryMoveSearchProperty()
		{
			Title = new Title();
			id = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "AddQInventoryItemsInFastWayScreen")]
	public class AddQInventoryItemsInFastWayScreen
	{
		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public bool CameraBarcodeScannerEnabled { get; set; }

		[XmlElement(ElementName = "ScreenEnabled")]
		public bool ScreenEnabled { get; set; }
		public AddQInventoryItemsInFastWayScreen()
		{
			CameraBarcodeScannerEnabled = false;
			ScreenEnabled = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "AddSNInventoryItemsInFastWayScreen")]
	public class AddSNInventoryItemsInFastWayScreen
	{
		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public bool CameraBarcodeScannerEnabled { get; set; }

		[XmlElement(ElementName = "DefaultValues")]
		public Defaultvalues DefaultValues { get; set; }

		[XmlElement(ElementName = "ScreenEnabled")]
		public bool ScreenEnabled { get; set; }

		public AddSNInventoryItemsInFastWayScreen()
		{
			CameraBarcodeScannerEnabled = false;
			ScreenEnabled = false;
			DefaultValues = new Defaultvalues();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Defaultvalues")]
	public class Defaultvalues
	{
		[XmlElement(ElementName = "DefaultItemCode")]
		public string DefaultItemCode { get; set; }
		[XmlElement(ElementName = "DefaultQuantity")]
		public string DefaultQuantity { get; set; }

		public Defaultvalues()
		{
			DefaultItemCode = "";
			DefaultQuantity = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "WarehouseScreenRFID")]
	public class WarehouseScreenRFID
	{
		[XmlElement(ElementName = "ScreenEnabled")]
		public bool ScreenEnabled { get; set; }

		[XmlElement(ElementName = "WarehouseScreenRFIDConnectionBeforeOpenRequired")]
		public bool WarehouseScreenRFIDConnectionBeforeOpenRequired { get; set; }

		public WarehouseScreenRFID()
		{
			ScreenEnabled = false;
			WarehouseScreenRFIDConnectionBeforeOpenRequired = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "AssertInventoryScreen")]
	public class AssertInventoryScreen
	{
		[XmlElement(ElementName = "InventoryWizard")]
		public string InventoryWizard { get; set; }

		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public bool CameraBarcodeScannerEnabled { get; set; }

		public AssertInventoryScreen()
		{
			InventoryWizard = "";
			CameraBarcodeScannerEnabled = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "InventoryImage")]
	public class InventoryImage
	{
		[XmlElement(ElementName = "InventoryImageEnabled")]
		public bool InventoryImageEnabled { get; set; }
		[XmlElement(ElementName = "ImageQuality")]
		public int ImageQuality { get; set; }
		[XmlElement(ElementName = "InventoryImagePropertyId")]
		public string InventoryImagePropertyId { get; set; }

		public InventoryImage()
		{
			InventoryImageEnabled = false;
			ImageQuality = 80;
			InventoryImagePropertyId = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "PrinterSettings")]
	public class PrinterSettings
	{
		[XmlElement(ElementName = "ZebraPrinter")]
		public ZebraPrinter ZebraPrinter { get; set; }

		public  PrinterSettings	 ()
		{
			ZebraPrinter = new ZebraPrinter();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "ZebraPrinter")]
	public class ZebraPrinter
	{
		[XmlElement(ElementName = "PrintingFormats")]
		public PrintingFormats PrintingFormats { get; set; }
		public ZebraPrinter()
		{
			PrintingFormats = new PrintingFormats();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "PrintingFormats")]
	public class PrintingFormats
	{
		[XmlElement(ElementName = "PrintingFormat")]
		public List<PrintingFormat> PrintingFormat { get; set; }

		public PrintingFormats()
		{
			PrintingFormat = new List<PrintingFormat>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "PrintingFormat")]
	public class PrintingFormat
	{
		[XmlElement(ElementName = "Format")]
		public string Format { get; set; }

		[XmlElement(ElementName = "Name")]
		public string Name { get; set; }

		[XmlElement(ElementName = "id")]
		public int index { get; set; }

		[XmlIgnore]
		public bool IsOpen { get; set; } = true;

		public void ToggleButton()
		{
			IsOpen = !IsOpen;
		}

		[XmlElement(ElementName = "FieldsMapping")]
		public FieldsMapping FieldsMapping { get; set; }

		public PrintingFormat()
		{
			Format = "";
			Name = "";
			FieldsMapping = new FieldsMapping();
			index = 0;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "FieldsMapping")]
	public class FieldsMapping
	{
		[XmlElement(ElementName = "FieldMapping")]
		public List<FieldMapping> FieldMapping { get; set; }
		public FieldsMapping()
		{
			FieldMapping = new List<FieldMapping>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "FieldMapping")]
	public class FieldMapping
	{
		[XmlAttribute(AttributeName = "name")]
		public string name { get; set; }

		[XmlAttribute(AttributeName = "dateFormat")]
		public string dateFormat { get; set; }

		[XmlAttribute(AttributeName = "inventoryPropertyId")]
		public string inventoryPropertyId { get; set; }

		[XmlAttribute(AttributeName = "reverseValue")]
		public bool reverseValue { get; set; }

		[XmlIgnore]
		public bool IsOpen { get; set; } = true;

		public void ToggleButton()
		{
			IsOpen = !IsOpen;
		}

		public FieldMapping()
		{
			name = "";
			dateFormat = "";
			inventoryPropertyId = "";
			reverseValue = false;
		}
	}

	[Serializable()]
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

		public RFID()
		{
			QCodeType = "";
			RFIDCommands = new RFIDCommands();
			RFIDTagWritten = "";
			SNCodeType = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "RFIDCommands")]
	public class RFIDCommands
	{
		[XmlElement(ElementName = "RFIDCommand")]
		public List<RFIDCommand> RFIDCommand { get; set; }

		public RFIDCommands()
		{
			RFIDCommand = new List<RFIDCommand>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "RFIDCommand")]
	public class RFIDCommand
	{
		[XmlAttribute(AttributeName = "command")]
		public string command { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public string type { get; set; }
		public RFIDCommand()
		{
			command = "";
			type = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "FastStockInventoryItemsConfiguration")]
	public class FastStockInventoryItemsConfiguration
	{
		[XmlElement(ElementName = "DefaultAutomaticQuantity")]
		public string DefaultAutomaticQuantity { get; set; }

		[XmlElement(ElementName = "EditFormSettings")]
		public EditFormSettings EditFormSettings { get; set; }

		[XmlAttribute(AttributeName = "AddDefaultQuantityMode")]
		public string AddDefaultQuantityMode { get; set; }

		[XmlAttribute(AttributeName = "InsertNotExistInCatalogItems")]
		public string InsertNotExistInCatalogItems { get; set; }

		[XmlAttribute(AttributeName = "InsertDetailsForNotExistInCatalogItems")]
		public string InsertDetailsForNotExistInCatalogItems { get; set; }

		[XmlAttribute(AttributeName = "CaseSensitiveItemCode")]
		public string CaseSensitiveItemCode { get; set; }

		[XmlAttribute(AttributeName = "CameraBarcodeScannerStockLocation")]
		public string CameraBarcodeScannerStockLocation { get; set; }

		[XmlAttribute(AttributeName = "CameraBarcodeScannerStockInventory")]
		public string CameraBarcodeScannerStockInventory { get; set; }

		public FastStockInventoryItemsConfiguration()
		{
			DefaultAutomaticQuantity = "";
			EditFormSettings = new EditFormSettings();
			AddDefaultQuantityMode = "";
			InsertNotExistInCatalogItems = "";
			InsertDetailsForNotExistInCatalogItems = "";
			CaseSensitiveItemCode = "";
			CameraBarcodeScannerStockLocation = "";
			CameraBarcodeScannerStockInventory = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "EditFormSettings")]
	public class EditFormSettings
	{
		[XmlElement(ElementName = "Field")]
		public List<Field> Field { get; set; }

		public EditFormSettings()
		{
			Field = new List<Field>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Validations")]
	public class Validations
	{
		[XmlElement(ElementName = "Validation")]
		public Validation Validation { get; set; }
		public Validations()
		{
			Validation = new Validation();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Validation")]
	public class Validation
	{
		[XmlAttribute(AttributeName = "en")]
		public string en { get; set; }
		[XmlAttribute(AttributeName = "reg")]
		public string reg { get; set; }

		public Validation()
		{
			en = "";
			reg = "";
		}

		
	}

	public class UidKey
	{
		public string Key { get; set; }
		public string Value { get; set; }
		public bool IsOpen { get; set; } = true;
		public UidKey()
		{
			Key = "";
			Value = "";
		}
		public void ToggleButton()
		{
			IsOpen = !IsOpen;
		}

	}

	public static class ValidationCBI
	{
		public static void RefreshCBIFromProfileXml(this Count4U.Service.Format.Profile objectProfile, ProfileFile profileFileXml)
		{
			try
			{
				//Count4U.Service.Format.Profile profileDomainObject =
				//			   DeserializeXML.DeserializeXMLTextToObject<Count4U.Service.Format.Profile>(this.ProfileXml);
				objectProfile.InventoryProcessInformation.Customer.code = profileFileXml.CustomerCode != null ? profileFileXml.CustomerCode : "";
				objectProfile.InventoryProcessInformation.Customer.name = profileFileXml.CustomerName != null ? profileFileXml.CustomerName : "";
				objectProfile.InventoryProcessInformation.Branch.code = profileFileXml.BranchCode != null ? profileFileXml.BranchCode : "";
				objectProfile.InventoryProcessInformation.Branch.name = profileFileXml.BranchName != null ? profileFileXml.BranchName : "";
				objectProfile.InventoryProcessInformation.Inventory.code = profileFileXml.InventorCode != null ? profileFileXml.InventorCode : "";
				objectProfile.InventoryProcessInformation.Inventory.created_date = profileFileXml.InventorName != null ? profileFileXml.InventorName : "";
			}
			catch (Exception exp)
			{
				Console.WriteLine("RefreshCBIFromProfileXml ERROR :" + exp.Message + exp.InnerException);
			}
		}
	}

}

