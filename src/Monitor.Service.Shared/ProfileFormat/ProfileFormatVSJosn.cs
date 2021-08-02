using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Count4U.Service.Format.Json
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
		public Inventoryprocessinformation InventoryProcessInformation { get; set; }

		[XmlElement(ElementName = "InventoryProcessConfiguration")]
		public Inventoryprocessconfiguration InventoryProcessConfiguration { get; set; }

		[NonSerialized()]
		public object[] comment;

		[XmlElement(ElementName = "ScannerType")]
		public string ScannerType { get; set; }

		[XmlElement(ElementName = "LocationInventoryListScreenConfiguration")]
		public Locationinventorylistscreenconfiguration LocationInventoryListScreenConfiguration { get; set; }

		[XmlElement(ElementName = "InventoryListDefaultUIConfiguration")]
		public Inventorylistdefaultuiconfiguration InventoryListDefaultUIConfiguration { get; set; }

		[XmlElement(ElementName = "DatabaseSettings")]
		public Databasesettings DatabaseSettings { get; set; }

		[XmlElement(ElementName = "Forms")]
		public Forms Forms { get; set; }

		[XmlElement(ElementName = "Search")]
		public Search Search { get; set; }

		[XmlElement(ElementName = "ScreensConfiguration")]
		public Screensconfiguration ScreensConfiguration { get; set; }

		[XmlElement(ElementName = "InventoryImage")]
		public Inventoryimage InventoryImage { get; set; }

		[XmlElement(ElementName = "PrinterSettings")]
		public Printersettings PrinterSettings { get; set; }

		[XmlElement(ElementName = "RFID")]
		public RFID RFID { get; set; }

		[XmlElement(ElementName = "FastStockInventoryItemsConfiguration")]
		public Faststockinventoryitemsconfiguration FastStockInventoryItemsConfiguration { get; set; }

		[NonSerialized()]   //NOTUSE
		public string BarcodeManipulations;

		[XmlElement(ElementName = "Version")]
		public string Version { get; set; }

		[XmlElement(ElementName = "Customer")]
		public Customer Customer { get; set; }

		public Profile()
		{
			InventoryProcessInformation = new Inventoryprocessinformation();
			InventoryProcessConfiguration = new Inventoryprocessconfiguration();
			comment = new object[] { };
			ScannerType = "";
			LocationInventoryListScreenConfiguration = new Locationinventorylistscreenconfiguration();
			InventoryListDefaultUIConfiguration = new Inventorylistdefaultuiconfiguration();
			DatabaseSettings = new Databasesettings();
			Forms = new Forms();
			Search = new Search();
			ScreensConfiguration = new Screensconfiguration();
			InventoryImage = new Inventoryimage();
			PrinterSettings = new Printersettings();
			RFID = new RFID();
			FastStockInventoryItemsConfiguration = new Faststockinventoryitemsconfiguration();
			BarcodeManipulations = "";
			Version = "";
			Customer = new Customer();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "InventoryProcessInformation")]
	public class Inventoryprocessinformation
	{
		[XmlElement(ElementName = "Customer")]
		public Customer Customer { get; set; }
		[XmlElement(ElementName = "Branch")]
		public Branch Branch { get; set; }
		[XmlElement(ElementName = "Inventory")]
		public Inventory Inventory { get; set; }

		public Inventoryprocessinformation()
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
		public string name { get; set; }
		[XmlAttribute(AttributeName = "code")]
		public string code { get; set; }

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

		[XmlAttribute(AttributeName = "inventor_date")]
		public string inventor_date { get; set; }

		public Inventory()
		{
			created_date = "";
			code = "";
			inventor_date = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "InventoryProcessConfiguration")]
	public class Inventoryprocessconfiguration
	{
		[XmlElement(ElementName = "InventoryProcessMode")]
		public Inventoryprocessmode InventoryProcessMode { get; set; }

		public Inventoryprocessconfiguration()
		{
			InventoryProcessMode = new Inventoryprocessmode();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "InventoryProcessMode")]
	public class Inventoryprocessmode
	{
		[XmlElement(ElementName = "AssertModeEnabled")]
		public string AssertModeEnabled { get; set; }
		[XmlElement(ElementName = "StockModeEnabled")]
		public string StockModeEnabled { get; set; }
		public Inventoryprocessmode()
		{
			AssertModeEnabled = "";
			StockModeEnabled = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "LocationinventoryListScreenConfiguration")]
	public class Locationinventorylistscreenconfiguration
	{
		[XmlElement(ElementName = "AddNewInventoryEnabled")]
		public bool AddNewInventoryEnabled { get; set; }
		[XmlElement(ElementName = "TemplateInventoriesEnabled")]
		public bool TemplateInventoriesEnabled { get; set; }
		[XmlElement(ElementName = "SignatureToVerifyClosureOfLocationRequired")]
		public bool SignatureToVerifyClosureOfLocationRequired { get; set; }
		[XmlElement(ElementName = "AddNewInventoryOfflineEnabled")]
		public string AddNewInventoryOfflineEnabled { get; set; }

		public Locationinventorylistscreenconfiguration()
		{
			AddNewInventoryEnabled = false;
			TemplateInventoriesEnabled = false;
			SignatureToVerifyClosureOfLocationRequired = false;
			AddNewInventoryOfflineEnabled = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "InventoryListDefaultUIConfiguration")]
	public class Inventorylistdefaultuiconfiguration
	{
		[XmlElement(ElementName = "ShowInventoryImageIndicator")]
		public bool ShowInventoryImageIndicator { get; set; }

		[XmlElement(ElementName = "InventoryItemsProperties")]
		public InventoryItemsProperties InventoryItemsProperties { get; set; }

		public Inventorylistdefaultuiconfiguration()
		{
			ShowInventoryImageIndicator = false;
			InventoryItemsProperties = new InventoryItemsProperties();
		}

		public Inventorylistdefaultuiconfiguration(int len)
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
		public InventoryItemsProperties()
		{
			InventoryItemDisplayProperty = new List<InventoryItemDisplayProperty> ();
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

		//[NonSerialized]
		//public int index;

		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }

		[XmlElement(ElementName = "invalid")]
		public bool invalid { get; set; }

		
		[XmlElement(ElementName = "id")]
		public int index { get; set; }


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
	public class Databasesettings
	{
		[XmlElement(ElementName = "UIDKey")]
		public string UIDKey { get; set; }

		[XmlElement(ElementName = "CurrentInventoryDeviceIdProperty")]
		public string CurrentInventoryDeviceIdProperty { get; set; }

		[XmlElement(ElementName = "CurrentInventoryUserNameProperty")]
		public string CurrentInventoryUserNameProperty { get; set; }

		[XmlElement(ElementName = "ClearInventoryDataAfterUpload")]
		public bool ClearInventoryDataAfterUpload { get; set; }

		[XmlElement(ElementName = "CurrentInventoryDeviceNameProperty")]
		public string CurrentInventoryDeviceNameProperty { get; set; }

		public Databasesettings()
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
		public string KeepAllFieldsOnItemCodeChange { get; set; }
		public Form()
		{
			id = "";
			Fields = new List<Field> ();
			KeepAllFieldsOnItemCodeChange = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "Field")]
	public class Field
	{
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

		[XmlElement(ElementName = "Actions")]
		public Actions Actions { get; set; }

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
		public string mandatory { get; set; }
		[XmlAttribute(AttributeName = "type")]
		public string type { get; set; }
		[XmlAttribute(AttributeName = "typeview")]
		public string typeview { get; set; }
		[XmlAttribute(AttributeName = "viewonly")]
		public string viewonly { get; set; }
		[XmlAttribute(AttributeName = "camera_barcode_scanner_enable")]
		public string camera_barcode_scanner_enable { get; set; }

		[XmlAttribute(AttributeName = "negative_value_enable")]
		public string negative_value_enable { get; set; }

		[XmlAttribute(AttributeName = "add_enable")]
		public string add_enable { get; set; }

		[XmlAttribute(AttributeName = "clear_enable")]
		public string clear_enable { get; set; }

		[XmlAttribute(AttributeName = "zero_value_enable")]
		public string zero_value_enable { get; set; }


		public Details()
		{
			_default = "";
			id = "";
			itemtype = "";
			mandatory = "";
			type = "";
			typeview = "";
			viewonly = "";
			camera_barcode_scanner_enable = "";
			negative_value_enable = "";
			add_enable = "";
			clear_enable = "";
			zero_value_enable = "";
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
		public string SelectInFocus { get; set; }
	
		[XmlAttribute(AttributeName = "AutoGenerateCode")]
		public string AutoGenerateCode { get; set; }
		[XmlElement(ElementName = "EnabledFilters")]
		public Enabledfilters EnabledFilters { get; set; }

		public Actions ()
		{
			SelectInFocus = "";
			AutoGenerateCode = "";
			EnabledFilters = new Enabledfilters();
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
		[XmlElement(ElementName = "SearchByScannerScreenConfiguration")]
		public Searchbyscannerscreenconfiguration SearchByScannerScreenConfiguration { get; set; }
		[XmlElement(ElementName = "SearchInCatalogScreenConfiguration")]
		public Searchincatalogscreenconfiguration SearchInCatalogScreenConfiguration { get; set; }
		[XmlElement(ElementName = "SearchInLocationScreenConfiguration")]
		public Searchinlocationscreenconfiguration SearchInLocationScreenConfiguration { get; set; }
		[XmlElement(ElementName = "IgnoreChar")]
		public string IgnoreChar { get; set; }

		public Search()
		{
			SearchByScannerScreenConfiguration = new Searchbyscannerscreenconfiguration();
			SearchInCatalogScreenConfiguration = new Searchincatalogscreenconfiguration();
			SearchInLocationScreenConfiguration = new Searchinlocationscreenconfiguration();
			IgnoreChar = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchByScannerScreenConfiguration")]
	public class Searchbyscannerscreenconfiguration
	{
		[XmlElement(ElementName = "AddNewInventoryEnabled")]
		public string AddNewInventoryEnabled { get; set; }
		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public string CameraBarcodeScannerEnabled { get; set; }

		[XmlElement(ElementName = "NavigateBackEnabled")]
		public string NavigateBackEnabled { get; set; }

		[XmlElement(ElementName = "SearchByProperties")]
		public Searchbyproperties SearchByProperties { get; set; }

		[XmlElement(ElementName = "SearchByScannerResultListDisplayProperties")]
		public Searchbyscannerresultlistdisplayproperties SearchByScannerResultListDisplayProperties { get; set; }


		public Searchbyscannerscreenconfiguration()
		{
			AddNewInventoryEnabled = "";
			CameraBarcodeScannerEnabled = "";
			NavigateBackEnabled = "";
			SearchByProperties = new Searchbyproperties();
			SearchByScannerResultListDisplayProperties = new Searchbyscannerresultlistdisplayproperties();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchByProperties")]
	public class Searchbyproperties
	{
		[XmlElement(ElementName = "SearchByProperty")]
		public List<Searchbyproperty> SearchByProperty { get; set; }

		public Searchbyproperties ()
		{
			SearchByProperty = new List<Searchbyproperty>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchByProperty")]
	public class Searchbyproperty
	{
		[XmlAttribute(AttributeName = "id")]
		public string id { get; set; }

		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }

		public Searchbyproperty()
		{
			id = "";
			Title = new Title();
		}
	}


	[Serializable()]
	[XmlRoot(ElementName = "SearchByScannerResultListDisplayProperties")]
	public class Searchbyscannerresultlistdisplayproperties
	{
		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<Searchdisplayproperty> SearchDisplayProperty { get; set; }
		public Searchbyscannerresultlistdisplayproperties()
		{
			SearchDisplayProperty = new List<Searchdisplayproperty>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchDisplayProperty")]
	public class Searchdisplayproperty
	{
		[XmlAttribute(AttributeName = "id")]
		public string id { get; set; }

		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }

		[XmlElement(ElementName = "invalid")]
		public bool invalid { get; set; }

		[XmlElement(ElementName = "he")]
		public string he { get; set; }

		[XmlElement(ElementName = "id")]
		public string index { get; set; }

		public Searchdisplayproperty()
		{

			id = "";
			Title = new Title();
			invalid = false;
			he = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInCatalogScreenConfiguration")]
	public class Searchincatalogscreenconfiguration
	{
		[XmlElement(ElementName = "AddNewItemIntoCatalogEnabled")]
		public bool AddNewItemIntoCatalogEnabled { get; set; }
		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public bool CameraBarcodeScannerEnabled { get; set; }
		[XmlElement(ElementName = "SearchInCatalogResultListsDisplayProperties")]
		public Searchincatalogresultlistsdisplayproperties SearchInCatalogResultListsDisplayProperties { get; set; }

		public Searchincatalogscreenconfiguration()
		{
			AddNewItemIntoCatalogEnabled = false;
			CameraBarcodeScannerEnabled = false;
			SearchInCatalogResultListsDisplayProperties = new Searchincatalogresultlistsdisplayproperties();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInCatalogResultListsDisplayProperties")]
	public class Searchincatalogresultlistsdisplayproperties
	{
		[XmlElement(ElementName = "SearchInCatalogByItemCodeResultListDisplayProperties")]
		public Searchincatalogbyitemcoderesultlistdisplayproperties SearchInCatalogByItemCodeResultListDisplayProperties { get; set; }

		[XmlElement(ElementName = "SearchInCatalogByItemNameResultListDisplayProperties")]
		public Searchincatalogbyitemnameresultlistdisplayproperties SearchInCatalogByItemNameResultListDisplayProperties { get; set; }

		public Searchincatalogresultlistsdisplayproperties()
		{
			SearchInCatalogByItemCodeResultListDisplayProperties = new Searchincatalogbyitemcoderesultlistdisplayproperties();
			SearchInCatalogByItemNameResultListDisplayProperties = new Searchincatalogbyitemnameresultlistdisplayproperties();
		}
	}

	
	[Serializable()]
	[XmlRoot(ElementName = "SearchInCatalogByItemCodeResultListDisplayProperties")]
	public class Searchincatalogbyitemcoderesultlistdisplayproperties
	{
		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<Searchdisplayproperty> SearchDisplayProperty { get; set; }
		public Searchincatalogbyitemcoderesultlistdisplayproperties()
		{
			SearchDisplayProperty = new List<Searchdisplayproperty>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInCatalogByItemNameResultListDisplayProperties")]
	public class Searchincatalogbyitemnameresultlistdisplayproperties
	{
		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<Searchdisplayproperty> SearchDisplayProperty { get; set; }
		public Searchincatalogbyitemnameresultlistdisplayproperties()
		{
			SearchDisplayProperty = new List<Searchdisplayproperty>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInLocationScreenConfiguration")]
	public class Searchinlocationscreenconfiguration
	{
		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public bool CameraBarcodeScannerEnabled { get; set; }

		[XmlElement(ElementName = "SearchInLocationResultListsDisplayProperties")]
		public Searchinlocationresultlistsdisplayproperties SearchInLocationResultListsDisplayProperties { get; set; }

		[XmlElement(ElementName = "AddNewItemIntoCatalogEnabled")]
		public bool AddNewItemIntoCatalogEnabled { get; set; }

		public Searchinlocationscreenconfiguration()
		{
			CameraBarcodeScannerEnabled = false;
			SearchInLocationResultListsDisplayProperties = new Searchinlocationresultlistsdisplayproperties();
			AddNewItemIntoCatalogEnabled = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInLocationResultListsDisplayProperties")]
	public class Searchinlocationresultlistsdisplayproperties
	{
		[XmlElement(ElementName = "SearchInLocationByItemSerialResultListDisplayProperties")]
		public Searchinlocationbyitemserialresultlistdisplayproperties SearchInLocationByItemSerialResultListDisplayProperties { get; set; }

		[XmlElement(ElementName = "SearchInLocationByItemCodeResultListDisplayProperties")]
		public Searchinlocationbyitemcoderesultlistdisplayproperties SearchInLocationByItemCodeResultListDisplayProperties { get; set; }

		[XmlElement(ElementName = "SearchInLocationByItemNameResultListDisplayProperties")]
		public Searchinlocationbyitemnameresultlistdisplayproperties SearchInLocationByItemNameResultListDisplayProperties { get; set; }

		public Searchinlocationresultlistsdisplayproperties()
		{
			SearchInLocationByItemSerialResultListDisplayProperties = new Searchinlocationbyitemserialresultlistdisplayproperties();
			SearchInLocationByItemCodeResultListDisplayProperties = new Searchinlocationbyitemcoderesultlistdisplayproperties();
			SearchInLocationByItemNameResultListDisplayProperties = new Searchinlocationbyitemnameresultlistdisplayproperties();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInLocationByItemSerialResultListDisplayProperties")]
	public class Searchinlocationbyitemserialresultlistdisplayproperties
	{
		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<Searchdisplayproperty> SearchDisplayProperty { get; set; }

		public Searchinlocationbyitemserialresultlistdisplayproperties()
		{
			SearchDisplayProperty = new List<Searchdisplayproperty>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInLocationByItemCodeResultListDisplayProperties")]
	public class Searchinlocationbyitemcoderesultlistdisplayproperties
	{
		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<Searchdisplayproperty> SearchDisplayProperty { get; set; }

		public Searchinlocationbyitemcoderesultlistdisplayproperties()
		{
			SearchDisplayProperty = new List<Searchdisplayproperty>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "SearchInLocationByItemNameResultListDisplayProperties")]
	public class Searchinlocationbyitemnameresultlistdisplayproperties
	{
		[XmlElement(ElementName = "SearchDisplayProperty")]
		public List<Searchdisplayproperty> SearchDisplayProperty { get; set; }

		public Searchinlocationbyitemnameresultlistdisplayproperties()
		{
			SearchDisplayProperty = new List<Searchdisplayproperty>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "ScreensConfiguration")]
	public class Screensconfiguration
	{
		[XmlElement(ElementName = "AddNewLocationScreen")]
		public Addnewlocationscreen AddNewLocationScreen { get; set; }
		[XmlElement(ElementName = "ItemCodeSummaryScreen")]
		public Itemcodesummaryscreen ItemCodeSummaryScreen { get; set; }
		[XmlElement(ElementName = "MoveInventoriesScreen")]
		public Moveinventoriesscreen MoveInventoriesScreen { get; set; }
		[XmlElement(ElementName = "AddQInventoryItemsInFastWayScreen")]
		public Addqinventoryitemsinfastwayscreen AddQInventoryItemsInFastWayScreen { get; set; }
		[XmlElement(ElementName = "AddSNInventoryItemsInFastWayScreen")]
		public Addsninventoryitemsinfastwayscreen AddSNInventoryItemsInFastWayScreen { get; set; }
		[XmlElement(ElementName = "WarehouseScreenRFID")]
		public Warehousescreenrfid WarehouseScreenRFID { get; set; }
		[XmlElement(ElementName = "AssertInventoryScreen")]
		public Assertinventoryscreen AssertInventoryScreen { get; set; }

		public Screensconfiguration()
		{
			AddNewLocationScreen = new Addnewlocationscreen();
			ItemCodeSummaryScreen = new Itemcodesummaryscreen();
			MoveInventoriesScreen = new Moveinventoriesscreen();
			AddQInventoryItemsInFastWayScreen = new Addqinventoryitemsinfastwayscreen();
			AddSNInventoryItemsInFastWayScreen = new Addsninventoryitemsinfastwayscreen();
			WarehouseScreenRFID = new Warehousescreenrfid();
			AssertInventoryScreen = new Assertinventoryscreen();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "AddNewLocationScreen")]
	public class Addnewlocationscreen
	{
		[XmlElement(ElementName = "ScreenEnabled")]
		public bool ScreenEnabled { get; set; }

		[XmlElement(ElementName = "ScreenEnabledOffline")]
		public bool ScreenEnabledOffline { get; set; }

		public Addnewlocationscreen()
		{
			ScreenEnabled = false;
			ScreenEnabledOffline = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "ItemCodeSummaryScreen")]
	public class Itemcodesummaryscreen
	{
		[XmlElement(ElementName = "ScreenEnabled")]
		public bool ScreenEnabled { get; set; }
		public Itemcodesummaryscreen()
		{
			ScreenEnabled = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "MoveInventoriesScreen")]
	public class Moveinventoriesscreen
	{
		[XmlElement(ElementName = "InventoryMoveSearchProperty")]
		public Inventorymovesearchproperty InventoryMoveSearchProperty { get; set; }
		[XmlElement(ElementName = "ScreenEnabled")]
		public bool ScreenEnabled { get; set; }
		public Moveinventoriesscreen()
		{
			InventoryMoveSearchProperty = new Inventorymovesearchproperty();
		   ScreenEnabled = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "InventoryMoveSearchProperty")]
	public class Inventorymovesearchproperty
	{
		[XmlAttribute(AttributeName = "id")]
		public string id { get; set; }

		[XmlElement(ElementName = "Title")]
		public Title Title { get; set; }
		public Inventorymovesearchproperty()
		{
			Title = new Title();
			id = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "AddQInventoryItemsInFastWayScreen")]
	public class Addqinventoryitemsinfastwayscreen
	{
		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public bool CameraBarcodeScannerEnabled { get; set; }

		[XmlElement(ElementName = "ScreenEnabled")]
		public bool ScreenEnabled { get; set; }
		public Addqinventoryitemsinfastwayscreen()
		{
			CameraBarcodeScannerEnabled = false;
			ScreenEnabled = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "AddSNInventoryItemsInFastWayScreen")]
	public class Addsninventoryitemsinfastwayscreen
	{
		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public bool CameraBarcodeScannerEnabled { get; set; }

		[XmlElement(ElementName = "DefaultValues")]
		public Defaultvalues DefaultValues { get; set; }

		[XmlElement(ElementName = "ScreenEnabled")]
		public bool ScreenEnabled { get; set; }

		public Addsninventoryitemsinfastwayscreen()
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
	public class Warehousescreenrfid
	{
		[XmlElement(ElementName = "ScreenEnabled")]
		public bool ScreenEnabled { get; set; }

		[XmlElement(ElementName = "WarehouseScreenRFIDConnectionBeforeOpenRequired")]
		public bool WarehouseScreenRFIDConnectionBeforeOpenRequired { get; set; }

		public Warehousescreenrfid()
		{
			ScreenEnabled = false;
			WarehouseScreenRFIDConnectionBeforeOpenRequired = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "AssertInventoryScreen")]
	public class Assertinventoryscreen
	{
		[XmlElement(ElementName = "InventoryWizard")]
		public string InventoryWizard { get; set; }

		[XmlElement(ElementName = "CameraBarcodeScannerEnabled")]
		public bool CameraBarcodeScannerEnabled { get; set; }

		public Assertinventoryscreen()
		{
			InventoryWizard = "";
			CameraBarcodeScannerEnabled = false;
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "InventoryImage")]
	public class Inventoryimage
	{
		[XmlElement(ElementName = "InventoryImageEnabled")]
		public bool InventoryImageEnabled { get; set; }
		[XmlElement(ElementName = "ImageQuality")]
		public string ImageQuality { get; set; }
		[XmlElement(ElementName = "InventoryImagePropertyId")]
		public string InventoryImagePropertyId { get; set; }

		public Inventoryimage()
		{
			InventoryImageEnabled = false;
			ImageQuality = "";
			InventoryImagePropertyId = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "PrinterSettings")]
	public class Printersettings
	{
		[XmlElement(ElementName = "ZebraPrinter")]
		public Zebraprinter ZebraPrinter { get; set; }

		public  Printersettings	 ()
		{
			ZebraPrinter = new Zebraprinter();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "ZebraPrinter")]
	public class Zebraprinter
	{
		[XmlElement(ElementName = "PrintingFormats")]
		public Printingformats PrintingFormats { get; set; }
		public Zebraprinter()
		{
			PrintingFormats = new Printingformats();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "PrintingFormats")]
	public class Printingformats
	{
		[XmlElement(ElementName = "PrintingFormat")]
		public Printingformat PrintingFormat { get; set; }

		public Printingformats()
		{
			PrintingFormat = new Printingformat();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "PrintingFormat")]
	public class Printingformat
	{
		[XmlElement(ElementName = "Format")]
		public string Format { get; set; }

		[XmlElement(ElementName = "FieldsMapping")]
		public Fieldsmapping FieldsMapping { get; set; }

		public Printingformat()
		{
			Format = "";
			FieldsMapping = new Fieldsmapping();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "FieldsMapping")]
	public class Fieldsmapping
	{
		[XmlElement(ElementName = "FieldMapping")]
		public List<Fieldmapping> FieldMapping { get; set; }
		public Fieldsmapping()
		{
			FieldMapping = new List<Fieldmapping>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "FieldMapping")]
	public class Fieldmapping
	{
		[XmlAttribute(AttributeName = "name")]
		public string name { get; set; }

		[XmlAttribute(AttributeName = "dateFormat")]
		public string dateFormat { get; set; }

		[XmlAttribute(AttributeName = "inventoryPropertyId")]
		public string inventoryPropertyId { get; set; }

		[XmlAttribute(AttributeName = "reverseValue")]
		public string reverseValue { get; set; }

		public Fieldmapping()
		{
			name = "";
			dateFormat = "";
			inventoryPropertyId = "";
			reverseValue = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "RFID")]
	public class RFID
	{
		[XmlElement(ElementName = "QCodeType")]
		public string QCodeType { get; set; }

		[XmlElement(ElementName = "RFIDCommands")]
		public Rfidcommands RFIDCommands { get; set; }

		[XmlElement(ElementName = "RFIDTagWritten")]
		public string RFIDTagWritten { get; set; }

		[XmlElement(ElementName = "SNCodeType")]
		public string SNCodeType { get; set; }

		public RFID()
		{
			QCodeType = "";
			RFIDCommands = new Rfidcommands();
			RFIDTagWritten = "";
			SNCodeType = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "RFID")]
	public class Rfidcommands
	{
		[XmlElement(ElementName = "RFIDCommand")]
		public List<Rfidcommand> RFIDCommand { get; set; }

		public Rfidcommands()
		{
			RFIDCommand = new List<Rfidcommand>();
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "RFIDCommand")]
	public class Rfidcommand
	{
		[XmlAttribute(AttributeName = "command")]
		public string command { get; set; }

		[XmlAttribute(AttributeName = "type")]
		public string type { get; set; }
		public Rfidcommand()
		{
			command = "";
			type = "";
		}
	}

	[Serializable()]
	[XmlRoot(ElementName = "FastStockInventoryItemsConfiguration")]
	public class Faststockinventoryitemsconfiguration
	{
		[XmlElement(ElementName = "DefaultAutomaticQuantity")]
		public string DefaultAutomaticQuantity { get; set; }

		[XmlElement(ElementName = "EditFormSettings")]
		public Editformsettings EditFormSettings { get; set; }

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

		public Faststockinventoryitemsconfiguration()
		{
			DefaultAutomaticQuantity = "";
			EditFormSettings = new Editformsettings();
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
	public class Editformsettings
	{
		[XmlElement(ElementName = "Field")]
		public List<Field> Field { get; set; }

		public Editformsettings()
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

	

}
