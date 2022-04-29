using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using BlazorMonacoXml;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using Monitor.Service.Model;
using Monitor.Service.Shared;
using Monitor.Service.Shared.MapperExpandoObject;
using Count4U.Service.Format;
using System.Xml.Linq;
using Microsoft.AspNetCore.SignalR.Client;
using Count4U.Admin.Client.Blazor.I18nText;
using Monitor.Service.Urls;
using Count4U.Service.Shared;
using Count4U.Model.Common;

namespace Count4U.Admin.Client.Page
{
    public class ObjectProfileXmlFileEditBase : ComponentBase
    {
        [Parameter]
        public string objectCode { get; set; }
        [Parameter]
        public string email { get; set; }
        public bool Expanded { get; set; } = false;

        public string CssEditorContent { get; set; } = "editorContentHidden";


        public bool Ping { get; set; }
        public bool PingMonitor { get; set; }
        public bool PingSignalRHub { get; set; }
        public string StorageMonitorWebApiUrl { get; set; }
        public string StorageSignalRHubUrl { get; set; }
         public bool IsSubmit { get; set; } = false;

        public ProfileFile _profileXmlFile { get; set; }

        public MonacoDiffEditorXml _xmlDiffEditor { get; set; }

        public Count4U.Service.Format.Profile _profileDomainObject { get; set; }

        [Inject]
        protected IHubChatSignalRRepository _hubSignalRRepository { get; set; }

        [Inject]
        protected IHubCommandSignalRRepository _hubCommandSignalRRepository { get; set; }

        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected GetResources LocalizationResources;

        [Inject]
        protected Toolbelt.Blazor.I18nText.I18nText I18nText { get; set; }
        //public Employee employee { get; set; }
        //public EditContext ProfileContext { get; set; }

        public string _originalProfileXml { get; set; }
        public string _modifiedProfileXml { get; set; }

        public bool _isXmlEmpty { get; set; }

        public IReadOnlyDictionary<string, object> AdditionalAttributes { get; set; } = new Dictionary<string, Object>() { { "background", "#2fe06a" } };

        [Inject]
        protected ISessionStorageService _sessionStorage { get; set; }

        [Inject]
        protected ILocalStorageService _localStorage { get; set; }

        [Inject]
        protected NavigationManager _navigationManager { get; set; }

        [Inject]
        protected IProfileFileService _profileFileService { get; set; }

        [Inject]
        protected IJSRuntime _jsRuntime { get; set; }

        [Inject]
        protected IJwtService _jwtService { get; set; }

        [Inject]
        protected IClaimService _claimService { get; set; }
        public List<InventoryItemDisplayProperty> InventoryitemdisplaypropertyList { get; set; }
        //public int InventoryitemdisplaypropertyListMaxIndex { get; set; }
        public List<ValueItem> FieldList { get; set; }
        public List<ValueItem> FieldList2 { get; set; }
        public List<ValueItem> FieldList3 { get; set; }
        public List<ValueItem> FieldList4 { get; set; }
        
        public List<ValueItem> FieldCatalogList3 { get; set; }
        public List<ValueItem> ItemType { get; set; }
        public List<ValueItem> UIDKey1 { get; set; }
        public List<ValueItem> UIDKey2 { get; set; }
        public List<ValueItem> UIDKey3 { get; set; }
        public List<ValueItem> UIDKey4 { get; set; }

        public List<ValueItem> CurrentInventoryDeviceIdProperty { get; set; }
        public List<ValueItem> CurrentInventoryUserNameProperty { get; set; }
        public List<ValueItem> CurrentInventoryDeviceNameProperty { get; set; }



        public ObjectProfileXmlFileEditBase()
        {
            this._profileXmlFile = null;        //file Xml from ftp
            this._isXmlEmpty = true;
            this._originalProfileXml = "";
            this._modifiedProfileXml = "";
            this._profileDomainObject = null;
          //  this._profileEntety = new System.Text.Json.JsonElement();


            UIDKey1 = new List<ValueItem>();
            UIDKey2 = new List<ValueItem>();
            UIDKey3 = new List<ValueItem>();
            UIDKey4 = new List<ValueItem>();

            InventoryitemdisplaypropertyList = new List<InventoryItemDisplayProperty>();
            //  InventoryitemdisplaypropertyListMaxIndex = 0;

            CurrentInventoryDeviceIdProperty = new List<ValueItem>();
            CurrentInventoryUserNameProperty = new List<ValueItem>();
            CurrentInventoryDeviceNameProperty = new List<ValueItem>();

            FieldList = new List<ValueItem>()
            {
                 new ValueItem() { Key = "", Value = "", CanDrag = true },
                new ValueItem() { Key = "ItemCode", Value = "ItemCode", CanDrag = true },
                new ValueItem() { Key = "SerialNumberLocal", Value = "SerialNumberLocal" , CanDrag = true},
                new ValueItem() { Key = "SerialNumberSupplier", Value = "SerialNumberSupplier", CanDrag = true},
                new ValueItem() { Key = "Quantity", Value = "Quantity", CanDrag = true},
                new ValueItem() { Key = "LocationCode", Value = "LocationCode", CanDrag = true},
                new ValueItem() { Key = "PropertyStr1", Value = "PropertyStr1", CanDrag = true},
                new ValueItem() { Key = "PropertyStr2", Value = "PropertyStr2", CanDrag = true},
                new ValueItem() { Key = "PropertyStr3", Value = "PropertyStr3", CanDrag = true},
                new ValueItem() { Key = "PropertyStr4", Value = "PropertyStr4", CanDrag = true},
                new ValueItem() { Key = "PropertyStr5", Value = "PropertyStr5", CanDrag = true},
                new ValueItem() { Key = "PropertyStr6", Value = "PropertyStr6", CanDrag = true},
                new ValueItem() { Key = "PropertyStr7", Value = "PropertyStr7", CanDrag = true},
                new ValueItem() { Key = "PropertyStr8", Value = "PropertyStr8", CanDrag = true},
                new ValueItem() { Key = "PropertyStr9", Value = "PropertyStr9", CanDrag = true},
                new ValueItem() { Key = "PropertyStr10", Value = "PropertyStr10", CanDrag = true},
                new ValueItem() { Key = "PropertyStr11", Value = "PropertyStr11", CanDrag = true},
                new ValueItem() { Key = "PropertyStr12", Value = "PropertyStr12", CanDrag = true},
                new ValueItem() { Key = "PropertyStr13", Value = "PropertyStr13", CanDrag = true},
                new ValueItem() { Key = "PropertyStr14", Value = "PropertyStr14", CanDrag = true},
                new ValueItem() { Key = "PropertyStr15", Value = "PropertyStr15", CanDrag = true},
                new ValueItem() { Key = "PropertyStr16", Value = "PropertyStr16", CanDrag = true},
                new ValueItem() { Key = "PropertyStr17", Value = "PropertyStr17", CanDrag = true},
                new ValueItem() { Key = "PropertyStr18", Value = "PropertyStr18", CanDrag = true},
                new ValueItem() { Key = "PropertyStr19", Value = "PropertyStr19", CanDrag = true},
                new ValueItem() { Key = "PropertyStr20", Value = "PropertyStr20", CanDrag = true}

            };

            FieldList2 = new List<ValueItem>()
            {
                new ValueItem() { Key = "", Value = ""},
                new ValueItem() { Key = "CurrentInventory.ItemCode", Value = "CurrentInventory.ItemCode"},
                new ValueItem() { Key = "CurrentInventory.SerialNumberLocal", Value = "CurrentInventory.SerialNumberLocal"},
                new ValueItem() { Key = "CurrentInventory.SerialNumberSupplier", Value = "CurrentInventory.SerialNumberSupplier"},
                new ValueItem() { Key = "CurrentInventory.Quantity", Value = "CurrentInventory.Quantity", CanDrag = true},
                new ValueItem() { Key = "CurrentInventory.LocationCode", Value = "CurrentInventory.LocationCode"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr1", Value = "CurrentInventory.PropertyStr1"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr2", Value = "CurrentInventory.PropertyStr2"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr3", Value = "CurrentInventory.PropertyStr3" },
                new ValueItem() { Key = "CurrentInventory.PropertyStr4", Value = "CurrentInventory.PropertyStr4"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr5", Value = "CurrentInventory.PropertyStr5"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr6", Value = "CurrentInventory.PropertyStr6"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr7", Value = "CurrentInventory.PropertyStr7"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr8", Value = "CurrentInventory.PropertyStr8"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr9", Value = "CurrentInventory.PropertyStr9"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr10", Value = "CurrentInventory.PropertyStr10"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr11", Value = "CurrentInventory.PropertyStr11"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr12", Value = "CurrentInventory.PropertyStr12"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr13", Value = "CurrentInventory.PropertyStr13"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr14", Value = "CurrentInventory.PropertyStr14"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr15", Value = "CurrentInventory.PropertyStr15"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr16", Value = "CurrentInventory.PropertyStr16"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr17", Value = "CurrentInventory.PropertyStr17"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr18", Value = "CurrentInventory.PropertyStr18"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr19", Value = "CurrentInventory.PropertyStr19"},
                new ValueItem() { Key = "CurrentInventory.PropertyStr20", Value = "CurrentInventory.PropertyStr20"}  ,
                 new ValueItem() { Key = "Catalog.ItemCode", Value = "Catalog.ItemCode"},
                new ValueItem() { Key = "Catalog.ItemName", Value = "Catalog.ItemName"},
                new ValueItem() { Key = "Catalog.ItemType", Value = "Catalog.ItemType"},
                new ValueItem() { Key = "Catalog.FamilyCode", Value = "Catalog.FamilyCode"},
                new ValueItem() { Key = " Catalog.FamilyName", Value = " Catalog.FamilyName"},
                new ValueItem() { Key = "Catalog.SectionCode", Value = "Catalog.SectionCode"},
                new ValueItem() { Key = "Catalog.SubSectionName", Value = "Catalog.SubSectionName"},
                new ValueItem() { Key = "Catalog.PriceBuy", Value = "Catalog.PriceBuy"},
                new ValueItem() { Key = "Catalog.PriceSell", Value = "Catalog.PriceSell"},
                new ValueItem() { Key = "Catalog.SupplierCode", Value = "Catalog.SupplierCode"},
                new ValueItem() { Key = " Catalog.SupplierName", Value = " Catalog.SupplierName"}  ,
                 new ValueItem() { Key = "Catalog.UnitTypeCode", Value = "Catalog.UnitTypeCode"},
                new ValueItem() { Key = "Catalog.Description", Value = "Catalog.Description"},
            };

            FieldList3 = new List<ValueItem>()
            {
                new ValueItem() { Key = "", Value = "", CanDrag = true},
                new ValueItem() { Key = "PropertyStr1", Value = "PropertyStr1", CanDrag = true},
                new ValueItem() { Key = "PropertyStr2", Value = "PropertyStr2", CanDrag = true},
                new ValueItem() { Key = "PropertyStr3", Value = "PropertyStr3", CanDrag = true},
                new ValueItem() { Key = "PropertyStr4", Value = "PropertyStr4", CanDrag = true},
                new ValueItem() { Key = "PropertyStr5", Value = "PropertyStr5", CanDrag = true},
                new ValueItem() { Key = "PropertyStr6", Value = "PropertyStr6", CanDrag = true},
                new ValueItem() { Key = "PropertyStr7", Value = "PropertyStr7", CanDrag = true},
                new ValueItem() { Key = "PropertyStr8", Value = "PropertyStr8", CanDrag = true},
                new ValueItem() { Key = "PropertyStr9", Value = "PropertyStr9", CanDrag = true},
                new ValueItem() { Key = "PropertyStr10", Value = "PropertyStr10", CanDrag = true},
                new ValueItem() { Key = "PropertyStr11", Value = "PropertyStr11", CanDrag = true},
                new ValueItem() { Key = "PropertyStr12", Value = "PropertyStr12", CanDrag = true},
                new ValueItem() { Key = "PropertyStr13", Value = "PropertyStr13", CanDrag = true},
                new ValueItem() { Key = "PropertyStr14", Value = "PropertyStr14", CanDrag = true},
                new ValueItem() { Key = "PropertyStr15", Value = "PropertyStr15", CanDrag = true},
                new ValueItem() { Key = "PropertyStr16", Value = "PropertyStr16", CanDrag = true},
                new ValueItem() { Key = "PropertyStr17", Value = "PropertyStr17", CanDrag = true},
                new ValueItem() { Key = "PropertyStr18", Value = "PropertyStr18", CanDrag = true},
                new ValueItem() { Key = "PropertyStr19", Value = "PropertyStr19", CanDrag = true},
                new ValueItem() { Key = "PropertyStr20", Value = "PropertyStr20", CanDrag = true}

            };

            FieldCatalogList3 = new List<ValueItem>()
             {
                new ValueItem() { Key = "", Value = "" },
                new ValueItem() { Key = "ItemCode", Value = "ItemCode" },
                new ValueItem() { Key = "ItemName", Value = "ItemName" },
                new ValueItem() { Key = "ItemType", Value = "ItemType" },
                new ValueItem() { Key = "FamilyCode", Value = "FamilyCode" },
                new ValueItem() { Key = " FamilyName", Value = " FamilyName" },
                new ValueItem() { Key = "SectionCode", Value = "SectionCode" },
                new ValueItem() { Key = "SubSectionName", Value = "SubSectionName" },
                new ValueItem() { Key = "PriceBuy", Value = "PriceBuy" },
                new ValueItem() { Key = "PriceSell", Value = "PriceSell" },
                new ValueItem() { Key = "SupplierCode", Value = "SupplierCode" },
                new ValueItem() { Key = " SupplierName", Value = " SupplierName" }  ,
                 new ValueItem() { Key = "UnitTypeCode", Value = "UnitTypeCode" },
                new ValueItem() { Key = "Description", Value = "Description" },
            };

            ItemType = new List<ValueItem>()
            {
                 new ValueItem() { Key = "", Value = "" },
                new ValueItem() { Key = "SN", Value = "SN" },
                new ValueItem() { Key = "Q", Value = "Q" },
                new ValueItem() { Key = "SN:Q", Value = "SN:Q" },
            };

            FieldList4 = new List<ValueItem>()
            {
                     new ValueItem() { Key = "Catalog.ItemCode", Value = "Catalog.ItemCode"},
                new ValueItem() { Key = "Catalog.ItemName", Value = "Catalog.ItemName"},
                new ValueItem() { Key = "Catalog.ItemType", Value = "Catalog.ItemType"},
                new ValueItem() { Key = "Catalog.FamilyCode", Value = "Catalog.FamilyCode"},
                new ValueItem() { Key = " Catalog.FamilyName", Value = " Catalog.FamilyName"},
                new ValueItem() { Key = "Catalog.SectionCode", Value = "Catalog.SectionCode"},
                new ValueItem() { Key = "Catalog.SubSectionName", Value = "Catalog.SubSectionName"},
                new ValueItem() { Key = "Catalog.PriceBuy", Value = "Catalog.PriceBuy"},
                new ValueItem() { Key = "Catalog.PriceSell", Value = "Catalog.PriceSell"},
                new ValueItem() { Key = "Catalog.SupplierCode", Value = "Catalog.SupplierCode"},
                new ValueItem() { Key = " Catalog.SupplierName", Value = " Catalog.SupplierName"}  ,
                 new ValueItem() { Key = "Catalog.UnitTypeCode", Value = "Catalog.UnitTypeCode"},
                new ValueItem() { Key = "Catalog.Description", Value = "Catalog.Description"},

                new ValueItem() { Key = "", Value = ""},
                new ValueItem() { Key = "ItemCode", Value = "ItemCode"},
                new ValueItem() { Key = "SerialNumberLocal", Value = "SerialNumberLocal"},
                new ValueItem() { Key = "SerialNumberSupplier", Value = "SerialNumberSupplier"},
                new ValueItem() { Key = "Quantity", Value = "Quantity"},
                new ValueItem() { Key = "LocationCode", Value = "LocationCode"},
                new ValueItem() { Key = "PropertyStr1", Value = "PropertyStr1"},
                new ValueItem() { Key = "PropertyStr2", Value = "PropertyStr2"},
                new ValueItem() { Key = "PropertyStr3", Value = "PropertyStr3" },
                new ValueItem() { Key = "PropertyStr4", Value = "PropertyStr4"},
                new ValueItem() { Key = "PropertyStr5", Value = "PropertyStr5"},
                new ValueItem() { Key = "PropertyStr6", Value = "PropertyStr6"},
                new ValueItem() { Key = "PropertyStr7", Value = "PropertyStr7"},
                new ValueItem() { Key = "PropertyStr8", Value = "PropertyStr8"},
                new ValueItem() { Key = "PropertyStr9", Value = "PropertyStr9"},
                new ValueItem() { Key = "PropertyStr10", Value = "PropertyStr10"},
                new ValueItem() { Key = "PropertyStr11", Value = "PropertyStr11"},
                new ValueItem() { Key = "PropertyStr12", Value = "PropertyStr12"},
                new ValueItem() { Key = "PropertyStr13", Value = "PropertyStr13"},
                new ValueItem() { Key = "PropertyStr14", Value = "PropertyStr14"},
                new ValueItem() { Key = "PropertyStr15", Value = "PropertyStr15"},
                new ValueItem() { Key = "PropertyStr16", Value = "PropertyStr16"},
                new ValueItem() { Key = "PropertyStr17", Value = "PropertyStr17"},
                new ValueItem() { Key = "PropertyStr18", Value = "PropertyStr18"},
                new ValueItem() { Key = "PropertyStr19", Value = "PropertyStr19"},
                new ValueItem() { Key = "PropertyStr20", Value = "PropertyStr20"}  ,
                 new ValueItem() { Key = "Catalog.ItemCode", Value = "Catalog.ItemCode"},
                new ValueItem() { Key = "Catalog.ItemName", Value = "Catalog.ItemName"},
                new ValueItem() { Key = "Catalog.ItemType", Value = "Catalog.ItemType"},
                new ValueItem() { Key = "Catalog.FamilyCode", Value = "Catalog.FamilyCode"},
                new ValueItem() { Key = " Catalog.FamilyName", Value = " Catalog.FamilyName"},
                new ValueItem() { Key = "Catalog.SectionCode", Value = "Catalog.SectionCode"},
                new ValueItem() { Key = "Catalog.SubSectionName", Value = "Catalog.SubSectionName"},
                new ValueItem() { Key = "Catalog.PriceBuy", Value = "Catalog.PriceBuy"},
                new ValueItem() { Key = "Catalog.PriceSell", Value = "Catalog.PriceSell"},
                new ValueItem() { Key = "Catalog.SupplierCode", Value = "Catalog.SupplierCode"},
                new ValueItem() { Key = " Catalog.SupplierName", Value = " Catalog.SupplierName"}  ,
                 new ValueItem() { Key = "Catalog.UnitTypeCode", Value = "Catalog.UnitTypeCode"},
                new ValueItem() { Key = "Catalog.Description", Value = "Catalog.Description"},

                 new ValueItem() { Key = "Location.LocationCode", Value = "Location.LocationCode"},
                 new ValueItem() { Key = "Location.Description", Value = "Location.Description"},
                    new ValueItem() { Key = "Location.Level1Code", Value = "Location.Level1Code"},
                    new ValueItem() { Key = "Location.Level1Name", Value = "Location.Level1Name"},
                    new ValueItem() { Key = "Location.Level2Code", Value = "Location.Level2Code"},
                    new ValueItem() { Key = "Location.Level2Name", Value = "Location.Level2Name"},
                    new ValueItem() { Key = "Location.Level3Code", Value = "Location.Level3Code"},
                    new ValueItem() { Key = "Location.Level3Name", Value = "Location.Level3Name"},
                    new ValueItem() { Key = "Location.Level4Code", Value = "Location.Level4Code"},
                    new ValueItem() { Key = "Location.Level4Name", Value = "Location.Level4Name"},
                    new ValueItem() { Key = "Location.IturCode", Value = "Location.IturCode"}     ,

                    new ValueItem() { Key = "SpecialField.CustomerName", Value = "SpecialField.CustomerName"},
                    new ValueItem() { Key = "SpecialField.CurrentDate", Value = "SpecialField.CurrentDate"},
                    new ValueItem() { Key = "SpecialField.UserName", Value = "SpecialField.UserName"},
                   
            };
        }

        public async Task RefreshList(ValueItem item)
        {
            FieldList.Remove(item);
            StateHasChanged();
        }

        public async Task CustomerEdit()
        {
            // "/customerprofileanduseredit/{code}"
            if (string.IsNullOrWhiteSpace(email) == true) email = objectCode + @"@customer.com";
            this._navigationManager.NavigateTo("customerprofileanduseredit/" + objectCode + "/" + email);
        }
        public async Task SaveObjectAsync()
        {
            try
            {
                IsSubmit = true;
                StateHasChanged();
                Console.WriteLine("Client.ObjectProfileXmlFileEditBase.SaveObjectAsync() Start");
                if (this._profileDomainObject == null)
                {
                    Console.WriteLine("Client.ObjectProfileXmlFileEditBase.SaveObjectAsync() ERROR :  _profileDomainObject is null");
                    return;
                }
                if (this._profileFileService == null)
                {
                    Console.WriteLine("Client.ObjectProfileXmlFileEditBase.SaveObjectAsync() ERROR :  _profileFileService is null");
                    return;
                }

                if (_profileDomainObject == null)
                {
                    Console.WriteLine("Client.ObjectProfileXmlFileEditBase.SaveObjectAsync() ERROR :  _profileDomainObject is null");
                    return;
                }
    
                this._profileDomainObject.RefreshCBIFromProfileXml(this._profileXmlFile);
               // this._profileDomainObject.DatabaseSettings.UIDKey = this._profileDomainObject.DatabaseSettings.UIDKeyArray.join;
                this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty =
                this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty.Where(x => x.index > 0).OrderBy(x => x.index).ToList();

                this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty =
                 this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty.Where(x => x.id != string.Empty).OrderBy(x => x.index).ToList();
                string[] array = this._profileDomainObject.DatabaseSettings.UIDKeyList.Select(x => x.Key).ToArray();
                this._profileDomainObject.DatabaseSettings.UIDKey = String.Join("|", array);
                string currentXml = _profileDomainObject.SerializeToXml();

                //  this._profileXmlFile = await this._profileFileService.GetProfileFileByInventorCode(inventorCode, @"http://localhost:12389");
                if (this._profileXmlFile == null)
                {
                    Console.WriteLine("Client.ObjectProfileXmlFileEditBase.SaveObjectAsync() ERROR :  _profileXmlFile is null");
                    return;     //Error
                }
                this._profileXmlFile.ProfileXml = currentXml;
                this._profileXmlFile.Code = this.objectCode;
                
               Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.SaveObjectAsync() :  objectCode = {objectCode}");
                this._profileFileService.RunUpdateFtpAndDbProfiles = await this._profileFileService.AddToQueueUpdateFtpAndDbRun(this._profileXmlFile, @"http://localhost:12389");
                //StateHasChanged();

                try
                {
                    this._modifiedProfileXml = this._profileFileService.RunUpdateFtpAndDbProfiles[2].ProfileXml;
                    await _xmlDiffEditor.SetModifiedValue(this._modifiedProfileXml);

                    this._profileDomainObject = DeserializeXML.DeserializeXMLTextToObject<Count4U.Service.Format.Profile>(this._profileFileService.RunUpdateFtpAndDbProfiles[2].ProfileXml);

                    //TODO вынести в функцию
                    this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty =
                   this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty.Where(x => x.index > 0).OrderBy(x => x.index).ToList();
                    //this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty.Add(new InventoryItemDisplayProperty());

                    StateHasChanged();
                }
                catch { }
            }
            catch (Exception exp)
            {
                Console.WriteLine("Client.ObjectProfileXmlFileEditBase.SaveObjectAsync() : Exception [" + exp.Message + "]");
            }
            //IsSubmit = true;
            //StateHasChanged();
        }

        protected async Task Reset()
        {
            Console.WriteLine();
            Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.Reset() : start");

            if (this._profileFileService != null)
            {
                try
                {
                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.Reset() objectCode =={objectCode}");
                     if (string.IsNullOrWhiteSpace(this._originalProfileXml) == true)
                    {
                        this._isXmlEmpty = true;
                        this._modifiedProfileXml = "";
                         await _xmlDiffEditor.SetModifiedValue("");
                         await _xmlDiffEditor.SetOriginalValue("");
                         this.StateHasChanged();
                        return;
                    }
                    this._modifiedProfileXml = _originalProfileXml;
                    this._isXmlEmpty = false;
                     this._profileXmlFile.ProfileXml = this._originalProfileXml;      //?? 
                     //can be null
                    this._profileDomainObject =
                          DeserializeXML.DeserializeXMLTextToObject<Count4U.Service.Format.Profile>(this._originalProfileXml);
                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.Reset() 3");
                    try
                    {
                        await _xmlDiffEditor.SetOriginalValue(this._originalProfileXml);
                        await _xmlDiffEditor.SetModifiedValue(this._modifiedProfileXml);
                        StateHasChanged();
                    }
                    catch { }
                    this.StateHasChanged();
                }
                catch (Exception exc)
                {
                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.Reset() Exception :");
                    Console.WriteLine(exc.Message);
                }
            }
            else
            {
                Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.Reset() : _profileFileService is null");
                Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.Reset() : end");
            }
        }

        protected async Task GetProfileFile()
        {
            Console.WriteLine();
            Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.GetProfileFiles() : start");

            this._profileXmlFile = null;        //file Xml from ftp
            this._isXmlEmpty = true;
            this._originalProfileXml = "";
            this._modifiedProfileXml = "";
            this._profileDomainObject = null;
           // this._profileEntety = new System.Text.Json.JsonElement();

            if (this._profileFileService != null)
            {
                try
                {
                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.GetProfileFiles() 1");
                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.GetProfileFiles() objectCode =={objectCode}");
                    this._profileXmlFile = await this._profileFileService.GetProfileFileByCode(objectCode, @"http://localhost:12389");

                    //TEST
                   // Count4U.Service.Format.Profile pf = await this._profileFileService.GetProfileFileObjectByCode(objectCode, @"http://localhost:12389");
                    //   this._profileXmlFile = await this._profileFileService.GetProfileFileByInventorCode(objectCode, @"http://localhost:12389");
                    if (this._profileXmlFile == null)
                    {
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(this._profileXmlFile.ProfileXml) == false)
                    {
                        this._isXmlEmpty = false;
                         this._profileXmlFile.FixProfileXml();
                        this._originalProfileXml = this._profileXmlFile.ProfileXml;

                        //Console.WriteLine(" Client.ObjectProfileFileEditBase.GetProfileFile() >> 1");
                        //Exception error = DeserializeXML.TryDeserializeXMLTextToObject<Count4U.Service.Format.Profile>(this._originalProfileXml);
                        //Console.WriteLine($" Client.ObjectProfileFileEditBase.GetProfileFile() >>error {error.Message} {error.InnerException} {error.StackTrace}");
                        // this._profileDomainObject = await this._profileFileService.GetProfileFileObjectByCode(objectCode, @"http://localhost:12389");
                        if (string.IsNullOrWhiteSpace(this._originalProfileXml) == true)
                        {
                            Console.WriteLine($" Client.ObjectProfileFileEditBase.GetProfileFile() >> this._profileXmlFile.ProfileXml == null");
                            return;
                        }

                        this._profileDomainObject = DeserializeXML.DeserializeXMLTextToObject<Count4U.Service.Format.Profile>(this._profileXmlFile.ProfileXml);

                        if (this._profileDomainObject == null)
                        {
                            Console.WriteLine($" Client.ObjectProfileFileEditBase.GetProfileFile() >>error this._profileDomainObject == null");
                            return;
                        }
                        //TODO вынести в функцию
                        string[] uidKeyArray = this._profileDomainObject.DatabaseSettings.UIDKey.Split("|");

                        this._profileDomainObject.DatabaseSettings.UIDKeyList = new List<UidKey>();
                        int count = uidKeyArray.Count() > 3 ? uidKeyArray.Count() : 3;
                        Console.WriteLine($" Client.ObjectProfileXmlFileEditBase.GetProfileFile() >>CAUNT uidKeyArray {count}");

                        for (int i = 0; i < count; i++)
                        {
                            this._profileDomainObject.DatabaseSettings.UIDKeyList.Add(new UidKey());
                        }
                       
                        for (int i = 0; i < count; i++)
                        {
                           // if (i >= 4) continue;
                            this._profileDomainObject.DatabaseSettings.UIDKeyList[i].Key = uidKeyArray[i];
                            this._profileDomainObject.DatabaseSettings.UIDKeyList[i].Value = uidKeyArray[i];
                        }

                         this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty =
                        this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty.Where(x => x.index > 0).OrderBy(x => x.index).ToList();
                        //this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty.Add(new InventoryItemDisplayProperty());

                        Console.WriteLine($" Client.ObjectProfileXmlFileEditBase.GetProfileFile() >>this._profileDomainObject == null {this._profileDomainObject == null}");
                        if (this._profileDomainObject != null)
                        {
                            Console.WriteLine($" Client.ObjectProfileXmlFileEditBase.GetProfileFile() >>this._profileDomainObject.InventoryItemDisplayProperty.Count3 " +
                                $"{ this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty.Count()}");
                        }
                        //Console.WriteLine(" Client.ObjectProfileXmlFileEditBase.GetProfileFile() >> this._originalProfile is " + this._profileXmlFile.ProfileXml);
                        //  this._profileEntety = await _jsRuntime.InvokeAsync<System.Text.Json.JsonElement>("BlazorUniversity.setDataJsObjectFromXml", this._originalProfileXml);
                        //Console.WriteLine($"Client.ObjectProfileFileEditBase.GetProfileFile() !!!ToProfileDomainObject profile >> {_profileEntety.ToString()}");
                    }
                    else
                    {
                        this._isXmlEmpty = true;
                         Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.GetProfileFiles() ProfileXml is empty");
                    }

                    //await _xmlDiffEditor.SetModifiedValue(this._modifiedProfileXml);
                    //await _xmlDiffEditor.SetOriginalValue(this._originalProfileXml);
                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.GetProfileFiles() 3");
                }
                catch (Exception exc)
                {
                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.GetProfileFiles() Exception :");
                    Console.WriteLine(exc.Message);
                }
            }
            else
            {
                Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.GetProfileFiles() : _profileFileService is null");
                Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.GetProfileFiles() : end");
            }
        }

        public async Task Notify(string notify)
        {
            if (this._hubSignalRRepository.HubChatConnection == null)
                return;
            string dt = DateTime.Now.ToString("HH:mm:ss.f");
            if (this._hubSignalRRepository.HubChatConnection.State == HubConnectionState.Connected)
            {
                await this._hubSignalRRepository.HubChatConnection.SendAsync(SignalRClientRunFunctionOnHub.SendNotify, $"{dt}   {notify}");
            }
        }

        protected override async Task OnInitializedAsync()
        {
            this.StorageMonitorWebApiUrl = "";
            this.StorageSignalRHubUrl = "";
            this.Ping = false;
            this.PingMonitor = false;
            this.PingSignalRHub = false;

            if (this._profileFileService != null)
            {
                this._profileFileService.RunUpdateFtpAndDbProfiles = null;

            }
            else
            {
                Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnInitializedAsync() : _profileFileService is null");
            }

            Console.WriteLine();
            Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnInitializedAsync() : start");

            try
            {
                this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);

                if (this._localStorage != null)
                {
                    this.StorageMonitorWebApiUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.monitorWebapiUrl);
                    this.StorageSignalRHubUrl = await this._localStorage.GetItemAsync<string>(SessionStorageKey.signalRHubUrl);
                    if (string.IsNullOrWhiteSpace(this.StorageMonitorWebApiUrl) == false)
                    {
                        string result = await this._claimService.PingWebApiMonitorAsync();
                        if (result == PingOpetarion.Pong)
                        { this.PingMonitor = true; }
                    }

                    if (string.IsNullOrWhiteSpace(this.StorageSignalRHubUrl) == false)
                    {
                        string result = await this._claimService.PingSignalRHubAsync();
                        if (result == PingOpetarion.Pong)
                        { this.PingSignalRHub = true; }

                    }
                }
                if (this._sessionStorage == null)
                {
                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnInitializedAsync() : _sessionStorage is null");
                }
                else if (this._jwtService == null)
                {
                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnInitializedAsync() : _jwtService is null");
                }
                else
                {
                    //  string tokenFromStorage = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authToken);
                    //  Console.WriteLine($"Client.InventorProfileFileEditBase.OnInitializedAsync() : got Token");
                }
                await this.GetProfileFile();
                Expanded = false;
                CssEditorContent = "editorContentHidden";
                try
                {
                    this._modifiedProfileXml = "";
                    await _xmlDiffEditor.SetOriginalValue(this._originalProfileXml);
                    await _xmlDiffEditor.SetModifiedValue(this._modifiedProfileXml);
                    StateHasChanged();
                }
                catch { }

                //  StateHasChanged();
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnInitializedAsync() Exception :");
                Console.WriteLine(exc.Message);
            }
            Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnInitializedAsync() : end");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
                try
                {
                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() Start FirstRender");
                    string signalRHubFromLocalStorage = await this._localStorage.GetItemAsync<string>(SessionStorageKey.signalRHubUrl);
                   Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() 1 2 {signalRHubFromLocalStorage}");
                    string commandHubAddress = Opetarion.UrlCombine(signalRHubFromLocalStorage, Monitor.Service.Model.SignalRHub.CommandHub);

                    Console.WriteLine("Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() command hubConnection : ");
                    Uri hubaddres = NavigationManager.ToAbsoluteUri(commandHubAddress);
                    if (_hubCommandSignalRRepository == null)
                    {
                        Console.WriteLine("ERROR : Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() _hubSignalRRepository is null");
                        return;
                    }

                    Console.WriteLine("Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() hubConnection  try build : " + hubaddres.AbsolutePath + "     " + hubaddres.AbsoluteUri);
                    _hubCommandSignalRRepository.HubCommandConnection = new HubConnectionBuilder()
                      .WithUrl(hubaddres)
                      .WithAutomaticReconnect()
                      // .ConfigureLogging(logging => {
                      //	logging.SetMinimumLevel(LogLevel.Information);
                      //	logging.AddConsole();
                      //})
                      .Build();
                    Console.WriteLine("Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() hubConnection : builded");
                    if (this._hubCommandSignalRRepository.HubCommandConnection == null)
                    {
                        Console.WriteLine("ERROR : Client.IndexBase.OnAfterRenderAsync() _hubCommandSignalRRepository.HubCommandConnection is null");
                        return;
                    }


                    Console.WriteLine("Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() IsCommandConnected1R : " + IsCommandConnected);
                    await _hubCommandSignalRRepository.HubCommandConnection.StartAsync();
                    Console.WriteLine("Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() StartAsync IsCommandConnected2R : " + IsCommandConnected);

                    //if (Collapsed == false)
                    //{
                    // // await _xmlDiffEditor.SetModifiedValue(this._modifiedProfileXml);
                    //  await _xmlDiffEditor.SetOriginalValue(this._originalProfileXml);
                    ////  StateHasChanged();
                    // }

                    this._hubCommandSignalRRepository.HubCommandConnection.On<ProfileFile>(SignalRHubPublishFunction.ReceiveProfileFile, (result) =>
                    {
                        Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() Start On<ProfileFile> {result.Code}");
                        Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() result.Step {result.Step}");
                        Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() result.Successful {result.Successful}");
                        //this._importFromPdaService.FileItemsInData = this._importFromPdaService.FileItemsInData.UpdateCommandResultInFileItems(
                        // this._importFromPdaService.FileItemsInData, result);
                        // this._importFromPdaService.RunImportCommandResults.UpdateCommandResulByOperationCode(result);

                        this._profileFileService.RunUpdateFtpAndDbProfiles.UpdateProfileFileByOperationCode(result);
                       // this._profileFileService.RunUpdateFtpAndDbProfiles.UpdateProfileFileByOperationCode(result);

                        //SaveOrUpdatOnFtp = 5,
                        //UpdateOrInsertInventorFromFtpToDb = 6,
                        //GetByInventorCodeFromFtp = 7,
                        if (result.Step == ProfiFileStepEnum.SaveOrUpdatOnFtp)
                        {
                            Expanded = false;
                            CssEditorContent = "editorContentHidden";
                            this.StateHasChanged();

                            if (result.Successful == SuccessfulEnum.Successful)
                            {
                                Console.WriteLine($"{ProfiFileStepEnum.SaveOrUpdatOnFtp.ToString()} : {SuccessfulEnum.Successful.ToString()}");
                            }
                        }
                        else if (result.Step == ProfiFileStepEnum.UpdateOrInsertObjectFromFtpToDb)
                        {
                            if (result.Successful == SuccessfulEnum.Successful)
                            {
                                Console.WriteLine($"{ProfiFileStepEnum.UpdateOrInsertObjectFromFtpToDb.ToString()} : {SuccessfulEnum.Successful.ToString()}");
                                // result.FixProfileXml();

                                this._modifiedProfileXml = "";
                                if (string.IsNullOrWhiteSpace(result.ProfileXml) == false)
                                {
                                    this._isXmlEmpty = false;
                                    this._profileXmlFile.FixProfileXml();
                                    this._originalProfileXml = this._profileXmlFile.ProfileXml;
                                    this._modifiedProfileXml = "";

                                    //can be null
                                    this._profileDomainObject =
                                    DeserializeXML.DeserializeXMLTextToObject<Count4U.Service.Format.Profile>(result.ProfileXml);
                                   
                                }
                                else 
                                {
                                    this._isXmlEmpty = true;
                                    this._originalProfileXml = "";
                                    this._modifiedProfileXml = "";
                                    this._profileDomainObject = null;
                              
                                }
                                // this.GetProfileFile().Wait();
                                IsSubmit = false;
                                Console.WriteLine($"{ProfiFileStepEnum.UpdateOrInsertObjectFromFtpToDb.ToString()} Wait end with Successful");
                            }
                            if (result.Successful == SuccessfulEnum.NotSuccessful)
                            {
                                IsSubmit = false;
                                Console.WriteLine($"{ProfiFileStepEnum.UpdateOrInsertObjectFromFtpToDb.ToString()} Wait end  with NotSuccessful");
                            }
                            this.StateHasChanged();
                        }
                        //else if (result.Step == ProfiFileStepEnum.GetByCodeFromFtp)
                        //{
                        //    if (result.Successful == SuccessfulEnum.Successful)
                        //    {
                        //        Console.WriteLine($"{ProfiFileStepEnum.SaveOrUpdatOnFtp.ToString()} : {SuccessfulEnum.Successful.ToString()}");
                        //    }
                        //}
                        this.StateHasChanged();
                    });

                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() : GetProfileFile");
                }
                catch (Exception exc)
                {
                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnAfterRenderAsync() Exception :");
                    Console.WriteLine(exc.Message);
                }


                //if (string.IsNullOrWhiteSpace(this._originalProfile) == false)
                //{
                //    var josnObject = await _jsRuntime.InvokeAsync<object>("BlazorUniversity.setDataJsObjectFromXml", this._originalProfile);
                //}
                //else
                //{
                //    Console.WriteLine("this._originalProfile is null");
                //}


                //	outTitle = await jsRuntime.InvokeAsync<string>("BlazorUniversity.profileModel", inTitle);
                //  var josnObject = await _jsRuntime.InvokeAsync<object>("BlazorUniversity.setDataJsObjectFromXml", this._originalProfile);

                //System.Text.Json.JsonElement customer = await jsRuntime.InvokeAsync<System.Text.Json.JsonElement>("BlazorUniversity.findInProfile0", "Customer");
                //dynamic config = JsonConvert.DeserializeObject<ExpandoObject>(customer.ToString(), new ExpandoObjectConverter());
                //_customerObject.Name = config._attributes.name;
                //_customerObject.Code = config._attributes.code;


                //this._profileObject.InventoryProcessInformation.Customer.name = configProfile.Customer[0]._attributes.name;
                //this._profileObject.InventoryProcessInformation.Customer.code = configProfile.Customer[0]._attributes.code;

            }
        }

        public async Task OnExpanded()
        {
            Expanded = !Expanded;
            if(Expanded == false)  CssEditorContent = "editorContentHidden";
            else CssEditorContent = "editorContent";
            this.StateHasChanged();
            try
            {
                this._modifiedProfileXml = "";
                Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnExpanded() 1");
                if (_xmlDiffEditor != null)
                {
                    await _xmlDiffEditor.SetModifiedValue(this._modifiedProfileXml);
                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnExpanded() 2");
                    await _xmlDiffEditor.SetOriginalValue(this._originalProfileXml);
                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnExpanded() 3");
                    StateHasChanged();
                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnExpanded() 4");
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.OnExpanded() Exception :");
                Console.WriteLine(exc.Message);
                Console.WriteLine(exc.InnerException);
            }
        }

         public async Task CheckObjectAsync()
        {
            this.StateHasChanged();
            if (Expanded == true)
            {
                try
                {
                    if (this._profileDomainObject == null)
                    {
                        Console.WriteLine("Client.ObjectProfileXmlFileEditBase.CheckObjectAsync() ERROR :  _profileDomainObject is null");
                    }
                    this._profileDomainObject.RefreshCBIFromProfileXml(this._profileXmlFile);        
                    
                    this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty =
                        this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty.Where(x => x.index > 0).OrderBy(x => x.index).ToList();
                    this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty =
                         this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty.Where(x => x.id != string.Empty).OrderBy(x => x.index).ToList();
                    string[] array = this._profileDomainObject.DatabaseSettings.UIDKeyList.Select(x => x.Key).ToArray();
                    this._profileDomainObject.DatabaseSettings.UIDKey = String.Join("|", array);
                    Console.WriteLine($"Client.ObjectProfileXmlFileEditBase.UIDKey {this._profileDomainObject.DatabaseSettings.UIDKey}");
                    string currentXml = _profileDomainObject.SerializeToXml();
                   //this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty.Add(new InventoryItemDisplayProperty());

                
                    this._modifiedProfileXml = currentXml;
                     await _xmlDiffEditor.SetOriginalValue(this._originalProfileXml);
                    await _xmlDiffEditor.SetModifiedValue(this._modifiedProfileXml);
                    Console.WriteLine("Client.ObjectProfileXmlFileEditBase.CheckObjectAsync() _modifiedProfileXml ok 3");
                    StateHasChanged();
                }
                catch (Exception exp)
                {
                    Console.WriteLine("Client.ObjectProfileXmlFileEditBase.CheckObjectAsync() : Exception [" + exp.Message + "]");
                }
            }
        }

        public async Task DeleteItem(InventoryItemDisplayProperty item)
        {
            InventoryitemdisplaypropertyList.Remove(item);
        }

        public async Task Up(InventoryItemDisplayProperty item)
        {
            int fromIndex = item.index;
            var array = InventoryitemdisplaypropertyList.Where(x => x.index < fromIndex && x.index > 0).OrderByDescending(x => x.index).ToArray();
            if (array.Length > 0)
            {
                int toIndex = array[0].index;
                array[0].index = fromIndex;
                item.index = toIndex;

                InventoryitemdisplaypropertyList = InventoryitemdisplaypropertyList.Where(x => x.index > 0).OrderBy(x => x.index).ToList();
                int k = 1;
                foreach (var it in InventoryitemdisplaypropertyList)
                {
                    it.index = k;
                    k++;
                }
                InventoryitemdisplaypropertyList.Add(new InventoryItemDisplayProperty());
                //StateHasChanged();
            }
            else
            {
                InventoryitemdisplaypropertyList = InventoryitemdisplaypropertyList.Where(x => x.index > 0).OrderBy(x => x.index).ToList();
                int k = 1;
                foreach (var it in InventoryitemdisplaypropertyList)
                {
                    it.index = k;
                    k++;
                }
                InventoryitemdisplaypropertyList.Add(new InventoryItemDisplayProperty());
                Console.WriteLine($"NOT Up {array.Length}");
                return;
            }

            Console.WriteLine($"InventoryitemdisplaypropertyListMaxIndex   {InventoryitemdisplaypropertyList?.Count - 1}");
        }

        public async Task Down(InventoryItemDisplayProperty item)
        {
            //  InventoryitemdisplaypropertyListMaxIndex = 0;
            int fromIndex = item.index;
            var array = InventoryitemdisplaypropertyList.Where(x => x.index > fromIndex && x.index > 0).OrderBy(x => x.index).ToArray();
            if (array.Length > 0)
            {
                int toIndex = array[0].index;
                array[0].index = fromIndex;
                item.index = toIndex;

                InventoryitemdisplaypropertyList = InventoryitemdisplaypropertyList.Where(x => x.index > 0).OrderBy(x => x.index).ToList();
                int k = 0;
                foreach (var it in InventoryitemdisplaypropertyList)
                {
                    k++;
                    it.index = k;
                }
                //InventoryitemdisplaypropertyListMaxIndex = k ;
                InventoryitemdisplaypropertyList.Add(new InventoryItemDisplayProperty());
            }
            else
            {
                InventoryitemdisplaypropertyList = InventoryitemdisplaypropertyList.Where(x => x.index > 0).OrderBy(x => x.index).ToList();
                int k = 0;
                foreach (var it in InventoryitemdisplaypropertyList)
                {
                    k++;
                    it.index = k;
                }
                // InventoryitemdisplaypropertyListMaxIndex = k;
                InventoryitemdisplaypropertyList.Add(new InventoryItemDisplayProperty());
                Console.WriteLine($"NOT Down {array.Length}");
                return;
            }

            Console.WriteLine($"InventoryitemdisplaypropertyListMaxIndex   {InventoryitemdisplaypropertyList?.Count - 1}");

        }

        public bool IsCommandConnected => _hubCommandSignalRRepository.HubCommandConnection.State == HubConnectionState.Connected;

    }
    //public enum ScannerTypeEnum1 { RFID, Barcode }

}

