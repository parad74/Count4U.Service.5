using System;
using System.Collections.Generic;
using Monitor.Service.Model;
using Count4U.Model;
using Newtonsoft.Json;
using System.Dynamic;
using System.Linq;
using Newtonsoft.Json.Converters;
using Count4U.Service.Format.Json;
using System.Xml.Serialization;
using System.IO;
using System.Xml.Linq;

namespace Monitor.Service.Shared.MapperExpandoObject
{
	public static class ProfileMapper
	{
		public static Count4U.Service.Format.Json.Profile ToProfileDomainObject(this string entity)
		{
			Count4U.Service.Format.Json.Profile profileObject = new Count4U.Service.Format.Json.Profile();
			if (string.IsNullOrWhiteSpace(entity) == true)
				return profileObject;
			
			profileObject.InventoryProcessInformation = new Count4U.Service.Format.Json.Inventoryprocessinformation();
			try
			{
				dynamic profileEntity = JsonConvert.DeserializeObject<ExpandoObject>(entity, new ExpandoObjectConverter());
				//https://makolyte.com/csharp-deserialize-json-to-dynamic-object/
				//string json = "{\"endpoints\":[{\"name\":\"prod\",  \"enabled\":true },{\"name\":\"dev\", \"enabled\":true},{\"name\":\"qa\", \"enabled\":false}]}"; //see JSON section below for pretty printed JSON

				//dynamic config = JsonConvert.DeserializeObject<ExpandoObject>(json, new ExpandoObjectConverter());

				//Console.WriteLine($"Deserialized JSON into {config.GetType()}");

				//foreach (var enabledEndpoint in ((IEnumerable<dynamic>)config.endpoints).Where(t => t.enabled))
				//{
				//	Console.WriteLine($"{enabledEndpoint.name} is enabled");
				//}

				//string fileName = couponData.GetType().GetProperty("LogoName").GetValue(couponData, null);

				if (profileEntity == null) Console.WriteLine("profileEntity if null 1");

				dynamic _proofile = profileEntity.Profile[0];
				if (_proofile == null) return profileObject;

				//======================	InventoryProcessInformation  ===========================================

				dynamic _inventoryProcessInformation = _proofile.InventoryProcessInformation[0];
				try
				{
					dynamic _customer = _inventoryProcessInformation.Customer[0];
					profileObject.InventoryProcessInformation.Customer.name = _customer._attributes.name;
					profileObject.InventoryProcessInformation.Customer.code = _customer._attributes.code;
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception ToProfileDomainObject _inventoryProcessInformation_customer :" + exc.Message);
				}

				try
				{
					dynamic _branch = _inventoryProcessInformation.Branch[0];
					profileObject.InventoryProcessInformation.Branch.name = _branch._attributes.name;
					profileObject.InventoryProcessInformation.Branch.code = _branch._attributes.code;
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception ToProfileDomainObject _inventoryProcessInformation_branch :" + exc.Message);
				}

				try
				{
					dynamic _inventor = _inventoryProcessInformation.Inventory[0];
					profileObject.InventoryProcessInformation.Inventory.created_date = _inventor._attributes.created_date;
					profileObject.InventoryProcessInformation.Inventory.code = _inventor._attributes.code;
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception ToProfileDomainObject _inventoryProcessInformation_inventor :" + exc.Message);
				}


				//======================	Customer  ===========================================
				try
				{
					dynamic _customer = _proofile.Customer[0];
					profileObject.Customer.name = _customer._attributes.name;
					profileObject.Customer.code = _customer._attributes.code;
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception ToProfileDomainObject _customer :" + exc.Message);
				}

				//< div class="radio-group-profile">
				//         <input id = "rfid" ng-model="$ctrl.scannerType._text" type="radio" value="RFID"><label for="rfid">RFID</label>
				//         <input id = "barcode" ng-model="$ctrl.scannerType._text" type="radio" value="Barcode" ><label for="barcode" >Barcode</label>
				//     </div>

				//======================	ScannerType  ===========================================

				dynamic _scannerType = _proofile.ScannerType[0];
				try
				{
					profileObject.ScannerType = _scannerType._text[0];
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception ToProfileDomainObject _scannerType :" + exc.Message);
				}

				//Console.WriteLine(@"configProfile.AddNewInventoryEnabled :" + configProfile.LocationInventoryListScreenConfiguration[0].AddNewInventoryEnabled._text[0]);
				//Console.WriteLine(@"configProfile.TemplateInventoriesEnabled :" + configProfile.LocationInventoryListScreenConfiguration[0].TemplateInventoriesEnabled._text[0]);
				//Console.WriteLine(@"configProfile.SignatureToVerifyClosureOfLocationRequired :" + configProfile.LocationInventoryListScreenConfiguration[0].SignatureToVerifyClosureOfLocationRequired._text[0]);

				//dynamic _locationInventoryListScreenConfiguration = _proofile.LocationInventoryListScreenConfiguration[0];
				//try
				//{
				//	Console.WriteLine("ToProfileDomainObject 1 _locationInventoryListScreenConfiguration.AddNewInventoryEnabled :" + _locationInventoryListScreenConfiguration.AddNewInventoryEnabled);	  //List
				//}
				//catch (Exception exc)
				//{
				//	Console.WriteLine("Exception ToProfileDomainObject 11 _ocationInventoryListScreenConfiguration :" + exc.Message);
				//}
				//try
				//{
				//	Console.WriteLine("ToProfileDomainObject 2  _locationInventoryListScreenConfiguration.AddNewInventoryEnabled[0] :" + _locationInventoryListScreenConfiguration.AddNewInventoryEnabled[0]);	//Object
				//}
				//catch (Exception exc)
				//{
				//	Console.WriteLine("Exception ToProfileDomainObject 21 _locationInventoryListScreenConfiguration :" + exc.Message);
				//}
				//try
				//{
				//	Console.WriteLine("ToProfileDomainObject 3 _locationInventoryListScreenConfiguration.AddNewInventoryEnabled[0]._text  :" + _locationInventoryListScreenConfiguration.AddNewInventoryEnabled[0]._text);
				//}
				//catch (Exception exc)
				//{
				//	Console.WriteLine("Exception ToProfileDomainObject 31 _locationInventoryListScreenConfiguration :" + exc.Message);
				//}

				//try
				//{
				//	Console.WriteLine("ToProfileDomainObject 4 _locationInventoryListScreenConfiguration.AddNewInventoryEnabled[0]._text[0]  :" + _locationInventoryListScreenConfiguration.AddNewInventoryEnabled[0]._text[0]);	  //true
				//}
				//catch (Exception exc)
				//{
				//	Console.WriteLine("Exception ToProfileDomainObject 41 _locationInventoryListScreenConfiguration :" + exc.Message);
				//}

				//======================	 LocationInventoryListScreenConfiguration  ===========================================

				dynamic _locationInventoryListScreenConfiguration = _proofile.LocationInventoryListScreenConfiguration[0];

				try
				{
					profileObject.LocationInventoryListScreenConfiguration.AddNewInventoryEnabled = _locationInventoryListScreenConfiguration.AddNewInventoryEnabled[0]._text[0] == "true" ? true : false;
					profileObject.LocationInventoryListScreenConfiguration.TemplateInventoriesEnabled = _locationInventoryListScreenConfiguration.TemplateInventoriesEnabled[0]._text[0] == "true" ? true : false; 
					profileObject.LocationInventoryListScreenConfiguration.SignatureToVerifyClosureOfLocationRequired = _locationInventoryListScreenConfiguration.SignatureToVerifyClosureOfLocationRequired[0]._text[0] == "true" ? true : false; 
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception ToProfileDomainObject _locationInventoryListScreenConfiguration :" + exc.Message);
				}

				dynamic _databaseSettings = _proofile.DatabaseSettings[0];

				try
				{
					profileObject.DatabaseSettings.UIDKey = _databaseSettings.UIDKey[0]._text[0] ;
					profileObject.DatabaseSettings.CurrentInventoryDeviceIdProperty = _databaseSettings.CurrentInventoryDeviceIdProperty[0]._text[0];
					profileObject.DatabaseSettings.CurrentInventoryUserNameProperty = _databaseSettings.CurrentInventoryUserNameProperty[0]._text[0];
					profileObject.DatabaseSettings.ClearInventoryDataAfterUpload = _databaseSettings.ClearInventoryDataAfterUpload[0]._text[0] == "true" ? true : false;
					profileObject.DatabaseSettings.CurrentInventoryDeviceNameProperty = _databaseSettings.CurrentInventoryDeviceNameProperty[0]._text[0];
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception ToProfileDomainObject _databaseSettings :" + exc.Message);
				}

				
				//======================	 InventoryListDefaultUIConfiguration  ===========================================

			
				try
				{
					dynamic _inventoryListDefaultUIConfiguration = _proofile.InventoryListDefaultUIConfiguration[0];
					//_proofile.InventoryListDefaultUIConfiguration[0].InventoryItemsProperties[0].InventoryItemDisplayProperty[0]._attributes.id	  //"Catalog.ItemName"
					dynamic _inventoryItemDisplayPropertyArray = _proofile.InventoryListDefaultUIConfiguration[0].InventoryItemsProperties[0].InventoryItemDisplayProperty;


					//_proofile.InventoryListDefaultUIConfiguration[0].ShowInventoryImageIndicator[0]._text[0]
					profileObject.InventoryListDefaultUIConfiguration.ShowInventoryImageIndicator = _inventoryListDefaultUIConfiguration.ShowInventoryImageIndicator[0]._text[0] == "true" ? true : false;
					foreach (var item in _inventoryItemDisplayPropertyArray) 
					{
						if (item == null) continue;
						int index = 0;
						try
						{
							bool ret = Int32.TryParse(item.id[0]._text[0], out index);
							Console.WriteLine("ToProfileDomainObject item.id[0]._text[0] :" + item.id[0]._text[0]);
						}
						catch (Exception exc)
						{
							Console.WriteLine("Exception 111 tem.id[0]._text[0] :" + exc.Message);
						}

						bool invalid = false;
						try
						{
							invalid = item.invalid[0]._text[0] == "true" ? true : false; 
							//Console.WriteLine("ToProfileDomainObject item.invalid[0]._text[0]:" + item.invalid[0]._text[0]);
						}
						catch (Exception exc)
						{
							Console.WriteLine("Exception 222  item.invalid[0]._text[0] :" + exc.Message);
						}

						//profileObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty.Add(
						//	new Count4U.Service.Format.Json.Inventoryitemdisplayproperty() { id = item._attributes.id });
						string attributes_id = "";
						string attributes_itemtype = "";
						try
						{
							if (item._attributes != null)
							{
								attributes_id = item._attributes.id != null ? item._attributes.id : "";
								//Console.WriteLine("ToProfileDomainObject item._attributes.id:" + item._attributes.id);
								attributes_itemtype = item._attributes.itemtype != null ? item._attributes.itemtype : "";
								//Console.WriteLine("ToProfileDomainObject item._attributes.itemtype:" + item._attributes.itemtype);
							}
						}
						catch (Exception exc)
						{
							Console.WriteLine("Exception 333  item._attributes :" + exc.Message);
						}

						string title_en = "";
						string title_he = "";
						try
						{
							if (item.Title[0] != null)
							{
								if (item.Title[0]._attributes != null)
								{
									title_en = item.Title[0]._attributes.en != null ? item.Title[0]._attributes.en : "";
									//Console.WriteLine("ToProfileDomainObject item.Title[0]._attributes.en :" + item.Title[0]._attributes.en);
									title_he = item.Title[0]._attributes.he != null ? item.Title[0]._attributes.he : "";
									//Console.WriteLine("ToProfileDomainObject item.Title[0]._attributes.he :" + item.Title[0]._attributes.he);
								}
							}
						}
						catch (Exception exc)
						{
							Console.WriteLine("Exception 444  item.Title[0] :" + exc.Message);
						}

						Count4U.Service.Format.Json.InventoryItemDisplayProperty prop = new Count4U.Service.Format.Json.InventoryItemDisplayProperty()
						{
							index = index,
							//indexString = index.ToString(),
							id = attributes_id,
							itemtype = attributes_itemtype,
							invalid = invalid,
							Title = new Count4U.Service.Format.Json.Title() { en = title_en, he = title_he }
						};
						profileObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty.Add(prop);
					}
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception Main ToProfileDomainObject _inventoryListDefaultUIConfiguration :" + exc.Message);
				}

				//======================	 RFID  ===========================================

				try
				{
					dynamic _rfid = _proofile.RFID[0];
				//_proofile.InventoryListDefaultUIConfiguration[0].InventoryItemsProperties[0].InventoryItemDisplayProperty[0]._attributes.id	  //"Catalog.ItemName"
				//dynamic _inventoryItemDisplayPropertyArray = _proofile.InventoryListDefaultUIConfiguration[0].InventoryItemsProperties[0].InventoryItemDisplayProperty;
				dynamic _rfidCommandArray = _proofile.RFID[0].RFIDCommands[0].RFIDCommand;
				
					//_proofile.InventoryListDefaultUIConfiguration[0].ShowInventoryImageIndicator[0]._text[0]
					profileObject.RFID.QCodeType = _rfid.QCodeType[0]._text[0];
					Console.WriteLine("profileObject.RFID.QCodeType:" + profileObject.RFID.QCodeType);
					profileObject.RFID.SNCodeType = _rfid.SNCodeType[0]._text[0];
					Console.WriteLine("profileObject.RFID.SNCodeType:" + profileObject.RFID.SNCodeType);
					profileObject.RFID.RFIDTagWritten = _rfid.RFIDTagWritten[0]._text[0];
					Console.WriteLine("profileObject.RFID.RFIDTagWritten:" + profileObject.RFID.RFIDTagWritten);
					foreach (var item in _rfidCommandArray)
					{
  						if (item == null) continue;
						//int index = 0;

						string attributes_command = "";
						string attributes_type = "";
						try
						{
							if (item._attributes != null)
							{
								attributes_command = item._attributes.command != null ? item._attributes.command : "";
								Console.WriteLine("ToProfileDomainObject item._attributes.command:" + item._attributes.command);
								attributes_type = item._attributes.type != null ? item._attributes.type : "";
								Console.WriteLine("ToProfileDomainObject item._attributes.type:" + item._attributes.type);
							}
						}
						catch (Exception exc)
						{
							Console.WriteLine("Exception 333  item._attributes :" + exc.Message);
						}

				
						Count4U.Service.Format.Json.Rfidcommand command = new Count4U.Service.Format.Json.Rfidcommand()
						{
							 command = attributes_command,
							type = attributes_type

						};
						profileObject.RFID.RFIDCommands.RFIDCommand.Add(command);
					}
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception _rfid :" + exc.Message);
				}

			}
			catch (Exception exc)
			{
				Console.WriteLine(exc.Message);

			}
			return profileObject;
		}

		
		public static string ApplyProfileJosnStringChanges(this string entity, Count4U.Service.Format.Json.Profile domainObject,
			string inventoryItemsPropertiesJosn)
		{
			if (domainObject == null)
				return null;

			
			try
			{
				//Console.WriteLine($"ApplyProfileJosnStringChanges entity : {entity}");
				Console.WriteLine($"ApplyProfileJosnStringChanges inventoryItemsPropertiesJosn : {inventoryItemsPropertiesJosn}");
				
				Console.WriteLine("ApplyProfileJosnStringChanges InventoryProcessInformation 111");
				dynamic profileEntity = JsonConvert.DeserializeObject<ExpandoObject>(entity, new ExpandoObjectConverter());
				Console.WriteLine("ApplyProfileJosnStringChanges InventoryProcessInformation 222");
				try
				{
					if (profileEntity == null) Console.WriteLine($"profileEntity if Empty");
					Console.WriteLine("ApplyProfileJosnStringChanges InventoryProcessInformation 333");
					if (profileEntity.Profile[0] == null) Console.WriteLine($"profileEntity.Profile[0] if Empty");
					Console.WriteLine("ApplyProfileJosnStringChanges InventoryProcessInformation 444");
					if (profileEntity.Profile[0].InventoryProcessInformation[0] == null) Console.WriteLine($"profileEntity.Profile[0].InventoryProcessInformation[0] if Empty");
					if(profileEntity.Profile[0].InventoryProcessInformation[0].Customer[0] == null) Console.WriteLine($"profileEntity.Profile[0].InventoryProcessInformation[0].Customer[0] if Empty");
					if (profileEntity.Profile[0].InventoryProcessInformation[0].Customer[0]._attributes == null) Console.WriteLine($"profileEntity.Profile[0].InventoryProcessInformation[0].Customer[0]._attributes if Empty");
					profileEntity.Profile[0].InventoryProcessInformation[0].Customer[0]._attributes.code = domainObject.InventoryProcessInformation.Customer.code;
					profileEntity.Profile[0].InventoryProcessInformation[0].Customer[0]._attributes.name = domainObject.InventoryProcessInformation.Customer.name;
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception ApplyProfileJosnStringChanges InventoryProcessInformation .Customer[0] :" + exc.Message);
				}

				

				Console.WriteLine("ApplyProfileJosnStringChanges InventoryProcessInformation 2");
				try
				{
						profileEntity.Profile[0].InventoryProcessInformation[0].Branch[0]._attributes.code = domainObject.InventoryProcessInformation.Branch.code;
					profileEntity.Profile[0].InventoryProcessInformation[0].Branch[0]._attributes.name = domainObject.InventoryProcessInformation.Branch.name;
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception ApplyProfileJosnStringChanges InventoryProcessInformation .Branch[0] :" + exc.Message);
				}

				Console.WriteLine("ApplyProfileJosnStringChanges InventoryProcessInformation 3");
				try
				{
					profileEntity.Profile[0].InventoryProcessInformation[0].Inventory[0]._attributes.code = domainObject.InventoryProcessInformation.Inventory.code;
					profileEntity.Profile[0].InventoryProcessInformation[0].Inventory[0]._attributes.created_date = domainObject.InventoryProcessInformation.Inventory.created_date;
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception ApplyProfileJosnStringChanges InventoryProcessInformation .Inventory[0] :" + exc.Message);
				}

				Console.WriteLine("ApplyProfileJosnStringChanges InventoryProcessInformation 4");
				try
				{
					profileEntity.Profile[0].Customer[0]._attributes.code = domainObject.Customer.code;
					profileEntity.Profile[0].Customer[0]._attributes.name = domainObject.Customer.name;
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception ApplyProfileJosnStringChanges .Customer[0] :" + exc.Message);
				}

				Console.WriteLine("ApplyProfileJosnStringChanges InventoryProcessInformation 5");
				try
				{
					profileEntity.Profile[0].ScannerType[0]._text[0] = domainObject.ScannerType;
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception ApplyProfileJosnStringChanges .ScannerType[0] :" + exc.Message);
				}


				Console.WriteLine("ApplyProfileJosnStringChanges InventoryProcessInformation 6");
				try
				{
					profileEntity.Profile[0].LocationInventoryListScreenConfiguration[0].AddNewInventoryEnabled[0]._text[0] = domainObject.LocationInventoryListScreenConfiguration.AddNewInventoryEnabled ? "true" : "false";
					profileEntity.Profile[0].LocationInventoryListScreenConfiguration[0].TemplateInventoriesEnabled[0]._text[0] = domainObject.LocationInventoryListScreenConfiguration.TemplateInventoriesEnabled ? "true" : "false";
					profileEntity.Profile[0].LocationInventoryListScreenConfiguration[0].SignatureToVerifyClosureOfLocationRequired[0]._text[0] = domainObject.LocationInventoryListScreenConfiguration.SignatureToVerifyClosureOfLocationRequired ? "true" : "false";
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception ApplyProfileJosnStringChanges .LocationInventoryListScreenConfiguration[0] :" + exc.Message);
				}

				Console.WriteLine("ApplyProfileJosnStringChanges InventoryProcessInformation 7");
				try
				{
					profileEntity.Profile[0].DatabaseSettings[0].UIDKey[0]._text[0] = domainObject.DatabaseSettings.UIDKey;
					profileEntity.Profile[0].DatabaseSettings[0].CurrentInventoryDeviceIdProperty[0]._text[0] = domainObject.DatabaseSettings.CurrentInventoryDeviceIdProperty;
					profileEntity.Profile[0].DatabaseSettings[0].CurrentInventoryUserNameProperty[0]._text[0] = domainObject.DatabaseSettings.CurrentInventoryUserNameProperty;
					profileEntity.Profile[0].DatabaseSettings[0].ClearInventoryDataAfterUpload[0]._text[0] = domainObject.DatabaseSettings.ClearInventoryDataAfterUpload ? "true" : "false";
					profileEntity.Profile[0].DatabaseSettings[0].CurrentInventoryDeviceNameProperty[0]._text[0] = domainObject.DatabaseSettings.CurrentInventoryDeviceNameProperty;
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception ApplyProfileJosnStringChanges .DatabaseSettings[0] :" + exc.Message);
				}

				//======================	 InventoryListDefaultUIConfiguration  ===========================================

				try
				{
					//Console.WriteLine("InventoryListDefaultUIConfiguration :" + profileEntity.Profile[0].InventoryListDefaultUIConfiguration[0].ShowInventoryImageIndicator[0]._text[0]);
					//Console.WriteLine("InventoryListDefaultUIConfiguration 2 :" + inventoryItemsPropertiesJosnEntity);
					//IDictionary<string, object> dictionary_object = inventoryItemsPropertiesJosnEntity;     //	   InventoryListDefaultUIConfiguration[0]
					//foreach (var d in dictionary_object)
					//{
					//	Console.WriteLine("1::" + d.Key + "::" + d.Value);            //InventoryListDefaultUIConfiguration
					//	try
					//	{
					//		var list = d.Value as List<object>;

					//		foreach (var l2 in list)           //	   InventoryListDefaultUIConfiguration[0].InventoryItemsProperties
					//		{                                            // 	   InventoryListDefaultUIConfiguration[0].ShowInventoryImageIndicator
					//			Console.WriteLine("2::" + l2.ToString());
					//			IDictionary<string, object> dictionary_object2 = l2 as ExpandoObject;
					//			foreach (var d2 in dictionary_object2)
					//			{
					//				Console.WriteLine("3::" + d2.Key + "::" + d2.Value);         //InventoryItemsProperties 	 //ShowInventoryImageIndicator
					//			}
					//		}
					//	}
					//	catch { }
					//}

					//try
					//{
					//	Console.WriteLine("::  4" + inventoryItemsPropertiesJosnEntity[0].InventoryItemsProperties);
					//	Console.WriteLine("::  5" + inventoryItemsPropertiesJosnEntity[0].ShowInventoryImageIndicator);
					//}
					//catch { }

					//profileEntity.Profile[0].InventoryListDefaultUIConfiguration[0].ShowInventoryImageIndicator[0]._text[0] = domainObject.InventoryListDefaultUIConfiguration.ShowInventoryImageIndicator ? "true" : "false";

					if (string.IsNullOrWhiteSpace(inventoryItemsPropertiesJosn) == false)
					{
						dynamic inventoryItemsPropertiesJosnEntity = JsonConvert.DeserializeObject<ExpandoObject>(inventoryItemsPropertiesJosn, new ExpandoObjectConverter());
						Console.WriteLine("ApplyProfileJosnStringChanges InventoryProcessInformation 8");
						profileEntity.Profile[0].InventoryListDefaultUIConfiguration[0] = inventoryItemsPropertiesJosnEntity;
					}

			
					//InventoryItemsProperties[0]

					int k = 0;
					foreach (var item in domainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty.OrderBy(x => x.index))
					{
						int i = item.index - 1;
						if (i < 0) continue;
						Console.WriteLine("i :" + i);
						profileEntity.Profile[0].InventoryListDefaultUIConfiguration[0].InventoryItemsProperties[0].InventoryItemDisplayProperty[k]._attributes.id = item.id;
						profileEntity.Profile[0].InventoryListDefaultUIConfiguration[0].InventoryItemsProperties[0].InventoryItemDisplayProperty[k]._attributes.itemtype = item.itemtype;
						profileEntity.Profile[0].InventoryListDefaultUIConfiguration[0].InventoryItemsProperties[0].InventoryItemDisplayProperty[k].invalid[0]._text[0] = item.invalid ? "true" : "false";
						profileEntity.Profile[0].InventoryListDefaultUIConfiguration[0].InventoryItemsProperties[0].InventoryItemDisplayProperty[k].id[0]._text[0] = item.index.ToString();
						profileEntity.Profile[0].InventoryListDefaultUIConfiguration[0].InventoryItemsProperties[0].InventoryItemDisplayProperty[k].Title[0]._attributes.en = item.Title.en;
						profileEntity.Profile[0].InventoryListDefaultUIConfiguration[0].InventoryItemsProperties[0].InventoryItemDisplayProperty[k].Title[0]._attributes.he = item.Title.he;
						Console.WriteLine("item.Title.en :" + item.Title.en);
						k ++;

					}


				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception ApplyProfileJosnStringChanges .InventoryListDefaultUIConfiguration[0] :" + exc.Message);
				}

				Console.WriteLine("ApplyProfileJosnStringChanges InventoryProcessInformation 9");
				try
				{
					profileEntity.Profile[0].RFID[0].QCodeType[0]._text[0] = domainObject.RFID.QCodeType;
					profileEntity.Profile[0].RFID[0].SNCodeType[0]._text[0] = domainObject.RFID.SNCodeType;
					profileEntity.Profile[0].RFID[0].RFIDTagWritten[0]._text[0] = domainObject.RFID.RFIDTagWritten;

					profileEntity.Profile[0].LocationInventoryListScreenConfiguration[0].TemplateInventoriesEnabled[0]._text[0] = domainObject.LocationInventoryListScreenConfiguration.TemplateInventoriesEnabled ? "true" : "false";
					profileEntity.Profile[0].LocationInventoryListScreenConfiguration[0].SignatureToVerifyClosureOfLocationRequired[0]._text[0] = domainObject.LocationInventoryListScreenConfiguration.SignatureToVerifyClosureOfLocationRequired ? "true" : "false";

					int k = 0;
					foreach (var item in domainObject.RFID.RFIDCommands.RFIDCommand)
					{
						profileEntity.Profile[0].RFID[0].RFIDCommands[0].RFIDCommand[k]._attributes.command = item.command;
						profileEntity.Profile[0].RFID[0].RFIDCommands[0].RFIDCommand[k]._attributes.type = item.type;
						k++;
					}
				}
				catch (Exception exc)
				{
					Console.WriteLine("Exception _rfid :" + exc.Message);
				}

				if(profileEntity == null) Console.WriteLine("profileEntity if null ");
				string configProfileString = JsonConvert.SerializeObject(profileEntity, new ExpandoObjectConverter());
				return configProfileString;
			}
			catch (Exception exc)
			{
				Console.WriteLine("Exception ApplyProfileJosnStringChanges : " + exc.Message);
				return null;
			}

	//entity.ProfileFileUID = domainObject.ProfileFileUID != null ? domainObject.ProfileFileUID : "";
	//return new Monitor.Sqlite.CodeFirst.ProfileFile()
	//{
	//	ID = domainObject.ID,
	//	ProfileFileUID = domainObject.ProfileFileUID != null ? domainObject.ProfileFileUID : "",

	//};
}
		public static Count4U.Service.Format.Json.Profile ToProfileSimpleDomainObject(this string entity)
		{
			if (string.IsNullOrWhiteSpace(entity) == true)
				return null;
			return new Count4U.Service.Format.Json.Profile()
			{
				//ID = entity.ID,
				//ProfileFileUID = entity.ProfileFileUID != null ? entity.ProfileFileUID : "",
			};
		}

	


		//??
		//public static void ApplyProfileChanges(this string entity, Count4U.Service.Format.Json.Profile domainObject)
		//{
		//	if (domainObject == null)
		//		return;
		//	//entity.ID = domainObject.ID;
		//	//entity.ProfileFileUID = domainObject.ProfileFileUID != null ? domainObject.ProfileFileUID : "";
	
		//}
	}


	public static class StringLenth
	{
		public static string CutLength(this string stringValue, int MaxLength)
		{
			stringValue = stringValue.Trim();
			if (string.IsNullOrWhiteSpace(stringValue) == true)
				return "";
			if (stringValue.Length <= MaxLength)
				return stringValue;
			else
				return stringValue.Substring(0, MaxLength);
		}


		public static string ToXml(
		this Count4U.Service.Format.Json.InventoryItemsProperties inventoryItemDisplayPropertyList)
		{
			string xml = "";
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Count4U.Service.Format.Json.InventoryItemsProperties));
			using (StringWriter textWriter = new StringWriter())
			{
				xmlSerializer.Serialize(textWriter, inventoryItemDisplayPropertyList);
				xml = textWriter.ToString();
				XDocument xdoc = XDocument.Parse(xml);
				xdoc.Descendants()
				   .Attributes()
				   .Where(x => x.IsNamespaceDeclaration)
				   .Remove();
				XElement xelement = xdoc.Descendants("InventoryItemsProperties").FirstOrDefault();
				xml = xelement.ToString();
				Console.WriteLine(xml);
			}
			return xml;
		}

		public static string FixedInventoryListDefaultUIConfigurationXml(this string xml, bool showInventoryImageIndicator)
		{
			string ret = xml;
			try
			{
				Console.WriteLine("FixedInventoryListDefaultUIConfigurationXml >>>> 1 :: " + xml.Length.ToString());
				string s1 = @"<InventoryListDefaultUIConfiguration>";
				string s2 = @"<InventoryListDefaultUIConfiguration>" + Environment.NewLine 
					+ $"        <ShowInventoryImageIndicator>{showInventoryImageIndicator.ToString().ToLower()}</ShowInventoryImageIndicator>";
				ret = xml.Replace(s1, s2);
				Console.WriteLine("FixedInventoryListDefaultUIConfigurationXml 6 >>>> " + ret.Length.ToString());
			}
			catch (Exception exp)
			{
				Console.WriteLine(" Exception FixedInventoryListDefaultUIConfigurationXml >>>> " + exp.Message);
			}
			return ret;
		}


		public static string ToXml(
		this Count4U.Service.Format.Json.Inventorylistdefaultuiconfiguration inventorylistdefaultuiconfiguration)
		{
			string xml = "";
			XmlSerializer xmlSerializer = new XmlSerializer(typeof(Count4U.Service.Format.Json.Inventorylistdefaultuiconfiguration));
			using (StringWriter textWriter = new StringWriter())
			{
				xmlSerializer.Serialize(textWriter, inventorylistdefaultuiconfiguration);
				
				xml = textWriter.ToString();
				XDocument xdoc = XDocument.Parse(xml);
				//xmlns: xsi = "http://www.w3.org/2001/XMLSchema-instance" xmlns: xsd = "http://www.w3.org/2001/XMLSchema
				xdoc.Descendants()
					   .Attributes()
					   .Where(x => x.IsNamespaceDeclaration)
					   .Remove();
				XElement xelement = xdoc.Descendants("InventoryListDefaultUIConfiguration").FirstOrDefault();
				xml = xelement.ToString();
				Console.WriteLine(xml);
			}
			return xml;
		}


		public static string InnerXML(this XElement el)
			{
				var reader = el.CreateReader();
				reader.MoveToContent();
				return reader.ReadInnerXml();
			}

	}

	
}