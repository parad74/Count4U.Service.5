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

        public bool Ping { get; set; }
        public bool PingMonitor { get; set; }
        public bool PingSignalRHub { get; set; }
        public string StorageMonitorWebApiUrl { get; set; }
        public string StorageSignalRHubUrl { get; set; }

        public ProfileFile _profileXmlFile { get; set; }

        public MonacoDiffEditorXml _xmlDiffEditor { get; set; }

        public Count4U.Service.Format.Profile _profileDomainObject { get; set; }

        [Inject]
        protected IHubChatSignalRRepository _hubSignalRRepository { get; set; }

        [Inject]
        protected IHubCommandSignalRRepository _hubCommandSignalRRepository { get; set; }

        protected GetResources LocalizationResources;

        [Inject]
        protected Toolbelt.Blazor.I18nText.I18nText I18nText { get; set; }
        //public Employee employee { get; set; }
        //public EditContext ProfileContext { get; set; }

        public string _originalProfileXml { get; set; }
        public string _modifiedProfileXml { get; set; }

        public System.Text.Json.JsonElement _profileEntety { get; set; }

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
            this._profileEntety = new System.Text.Json.JsonElement();


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
                new ValueItem() { Key = "ItemCode", Value = "ItemCode"},
                new ValueItem() { Key = "SerialNumberLocal", Value = "SerialNumberLocal"},
                new ValueItem() { Key = "SerialNumberSupplier", Value = "SerialNumberSupplier"},
                new ValueItem() { Key = "Quantity", Value = "Quantity", CanDrag = true},
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
            };

            FieldList3 = new List<ValueItem>()
            {
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


            ItemType = new List<ValueItem>()
            {
                new ValueItem() { Key = "SN", Value = "SN" },
                new ValueItem() { Key = "Q", Value = "Q" },
                new ValueItem() { Key = "SN:Q", Value = "SN:Q" },
            };
        }

        public async Task RefreshList(ValueItem item)
        {
            FieldList.Remove(item);
            StateHasChanged();
        }
        public async Task SaveObjectAsync()
        {
            try
            {
                if (this._profileDomainObject == null)
                {
                    Console.WriteLine("Client.ObjectProfileFileEditBase.SaveObjectAsync() ERROR :  _profileDomainObject is null");
                    return;
                }
                if (this._profileFileService == null)
                {
                    Console.WriteLine("Client.ObjectProfileFileEditBase.SaveObjectAsync() ERROR :  _profileFileService is null");
                    return;
                }

                //string uidKey1 = "";
                //string uidKey2 = "";
                //string uidKey3 = "";
                //string uidKey4 = "";
                //string currentInventoryDeviceIdProperty = "";
                //string currentInventoryUserNameProperty = "";
                //string currentInventoryDeviceNameProperty = "";
                //this._profileFileService.RunUpdateFtpAndDbProfiles = null;

                //try { uidKey1 = UIDKey1[0].Key; } catch { }
                //try { uidKey2 = UIDKey2[0].Key; } catch { }
                //try { uidKey3 = UIDKey3[0].Key; } catch { }
                //try { uidKey4 = UIDKey4[0].Key; } catch { }
                //try { currentInventoryDeviceIdProperty = CurrentInventoryDeviceIdProperty[0].Key; } catch { }
                //try { currentInventoryUserNameProperty = CurrentInventoryUserNameProperty[0].Key; } catch { }
                //try { currentInventoryDeviceNameProperty = CurrentInventoryDeviceNameProperty[0].Key; } catch { }

                //this._profileDomainObject.DatabaseSettings.CurrentInventoryDeviceIdProperty = currentInventoryDeviceIdProperty;
                //this._profileDomainObject.DatabaseSettings.CurrentInventoryUserNameProperty = currentInventoryUserNameProperty;
                //this._profileDomainObject.DatabaseSettings.CurrentInventoryDeviceNameProperty = currentInventoryDeviceNameProperty;
                //this._profileDomainObject.DatabaseSettings.UIDKey = $"{uidKey1}|{uidKey2}|{uidKey3}|{uidKey4}";
                //this._profileDomainObject.InventoryListDefaultUIConfiguration.InventoryItemsProperties.InventoryItemDisplayProperty =
                //    InventoryitemdisplaypropertyList.Where(x => x.index != 0).Select(x => x).ToList();

                //Count4U.Service.Format.InventoryItemsProperties inventoryItemsProperties =
                //    new Count4U.Service.Format.InventoryItemsProperties(InventoryitemdisplaypropertyList.Where(x => x.index != 0).Select(x => x).ToList().Count);
                ////inventoryItemsProperties.InventoryItemDisplayProperty = InventoryitemdisplaypropertyList;
                //string inventoryItemsPropertiesXml = inventoryItemsProperties.ToXml();
                //Console.WriteLine("inventoryItemsPropertiesXml : " + inventoryItemsPropertiesXml);

                //string inventoryItemsPropertiesJosn = await _jsRuntime.InvokeAsync<string>("BlazorUniversity.xml2json", inventoryItemsPropertiesXml);

                //string configProfileString = _profileEntety.ToString().ApplyProfileJosnStringChanges(this._profileDomainObject, inventoryItemsPropertiesJosn);

                //if (string.IsNullOrWhiteSpace(configProfileString) == true)
                //{
                //    Console.WriteLine("Client.ObjectProfileFileEditBase.SaveObjectAsync() ERROR :  configProfileString is empty");
                //}

                //string currentXml = await _jsRuntime.InvokeAsync<string>("BlazorUniversity.josn2xml", configProfileString);
                //currentXml = currentXml.FixedInventoryListDefaultUIConfigurationXml(this._profileDomainObject.InventoryListDefaultUIConfiguration.ShowInventoryImageIndicator);
                //await _xmlDiffEditor.SetModifiedValue(currentXml);
                ////this._modifiedProfileXml = currentXml;
                //Console.WriteLine("Client.ObjectProfileFileEditBase.SaveObjectAsync() _modifiedProfileXml ok ");
                //StateHasChanged();

                ////  this._profileXmlFile = await this._profileFileService.GetProfileFileByInventorCode(inventorCode, @"http://localhost:12389");
                //if (this._profileXmlFile == null)
                //{
                //    return;     //Error
                //}
                //this._profileXmlFile.ProfileXml = currentXml;
                ////this._profileXmlFile = await this._profileFileService.SaveOrUpdateProfileFileOnFtp(this._profileXmlFile, @"http://localhost:12389");
                ////Console.WriteLine("Client.InventorProfileFileEditBase.SaveObjectAsync() SaveOrUpdateProfileFileOnFtp ok ");
                ////this._profileXmlFile = await this._profileFileService.UpdateOrInsertProfileFileInventorFromFtpToDb(this._profileXmlFile, @"http://localhost:12389");
                ////Console.WriteLine("Client.InventorProfileFileEditBase.SaveObjectAsync() UpdateOrInsertProfileFileInventorFromFtpToDb ok ");
                ////this._profileXmlFile = await this._profileFileService.GetProfileFileByInventorCode(inventorCode, @"http://localhost:12389");
                ////Console.WriteLine("Client.InventorProfileFileEditBase.SaveObjectAsync() GetProfileFileByInventorCode ok ");
                ////this._modifiedProfileXml = this._profileXmlFile.ProfileXml;

                //// ProfileFile objectProfileFile = await this._profileFileService.GetProfileFileByCode(objectCode, @"http://localhost:12389");

                ////this._profileXmlFile.Code = this.objectCode;
                //this._profileFileService.RunUpdateFtpAndDbProfiles = await this._profileFileService.AddToQueueUpdateFtpAndDbRun(this._profileXmlFile, @"http://localhost:12389");
                //StateHasChanged();

                //try
                //{
                //    this._modifiedProfileXml = this._profileFileService.RunUpdateFtpAndDbProfiles[2].ProfileXml;
                //    StateHasChanged();
                //}
                //catch { }


            }
            catch (Exception exp)
            {
                Console.WriteLine("Client.ObjectProfileFileEditBase.SaveObjectAsync() : Exception [" + exp.Message + "]");
            }

        }


        protected async Task GetProfileFile()
        {
            Console.WriteLine();
            Console.WriteLine($"Client.ObjectProfileFileEditBase.GetProfileFiles() : start");

            this._profileXmlFile = null;        //file Xml from ftp
            this._isXmlEmpty = true;
            this._originalProfileXml = "";
            this._modifiedProfileXml = "";
            this._profileDomainObject = null;
            this._profileEntety = new System.Text.Json.JsonElement();

            if (this._profileFileService != null)
            {
                try
                {
                    Console.WriteLine($"Client.ObjectProfileFileEditBase.GetProfileFiles() 1");
                    Console.WriteLine($"Client.ObjectProfileFileEditBase.GetProfileFiles() objectCode =={objectCode}");
                    this._profileXmlFile = await this._profileFileService.GetProfileFileByCode(objectCode, @"http://localhost:12389");
                    //   this._profileXmlFile = await this._profileFileService.GetProfileFileByInventorCode(objectCode, @"http://localhost:12389");
                    if (this._profileXmlFile == null)
                    {
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(this._profileXmlFile.ProfileXml) == false)
                    {
                        this._isXmlEmpty = false;
                       // this._profileXmlFile.FixProfileXml();
                        this._originalProfileXml = this._profileXmlFile.ProfileXml;

                        //Console.WriteLine(" Client.ObjectProfileFileEditBase.GetProfileFile() >> 1");
                        //Exception error = DeserializeXML.TryDeserializeXMLTextToObject<Count4U.Service.Format.Profile>(this._originalProfileXml);
                        //Console.WriteLine($" Client.ObjectProfileFileEditBase.GetProfileFile() >>error {error.Message} {error.InnerException} {error.StackTrace}");
                        this._profileDomainObject = await this._profileFileService.GetProfileFileObjectByCode(objectCode, @"http://localhost:12389");

                        //this._profileDomainObject = DeserializeXML.DeserializeXMLTextToObject<Count4U.Service.Format.Profile>(this._originalProfileXml);
                        Console.WriteLine($" Client.ObjectProfileFileEditBase.GetProfileFile() >>this._profileDomainObject == null {this._profileDomainObject == null}");
                        Console.WriteLine(" Client.ObjectProfileFileEditBase.GetProfileFile() >> this._originalProfile is " + this._profileXmlFile.ProfileXml);
                      //  this._profileEntety = await _jsRuntime.InvokeAsync<System.Text.Json.JsonElement>("BlazorUniversity.setDataJsObjectFromXml", this._originalProfileXml);
                        //Console.WriteLine($"Client.ObjectProfileFileEditBase.GetProfileFile() !!!ToProfileDomainObject profile >> {_profileEntety.ToString()}");
                    }
                    else
                    {
                        this._isXmlEmpty = true;
                        Console.WriteLine($"Client.ObjectProfileFileEditBase.GetProfileFiles() ProfileXml is empty");
                    }
                    Console.WriteLine($"Client.ObjectProfileFileEditBase.GetProfileFiles() 3");
                }
                catch (Exception exc)
                {
                    Console.WriteLine($"Client.ObjectProfileFileEditBase.GetProfileFiles() Exception :");
                    Console.WriteLine(exc.Message);
                }
            }
            else
            {
                Console.WriteLine($"Client.ObjectProfileFileEditBase.GetProfileFiles() : _profileFileService is null");
                Console.WriteLine($"Client.ObjectProfileFileEditBase.GetRoles() : end");
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
                Console.WriteLine($"Client.ObjectProfileFileEditBase.OnInitializedAsync() : _profileFileService is null");
            }

            Console.WriteLine();
            Console.WriteLine($"Client.ObjectProfileFileEditBase.OnInitializedAsync() : start");

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
                    Console.WriteLine($"Client.ObjectProfileFileEditBase.OnInitializedAsync() : _sessionStorage is null");
                }
                else if (this._jwtService == null)
                {
                    Console.WriteLine($"Client.ObjectProfileFileEditBase.OnInitializedAsync() : _jwtService is null");
                }
                else
                {
                    //  string tokenFromStorage = await this._sessionStorage.GetItemAsync<string>(SessionStorageKey.authToken);
                    //  Console.WriteLine($"Client.InventorProfileFileEditBase.OnInitializedAsync() : got Token");


                }
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Client.ObjectProfileFileEditBase.OnInitializedAsync() Exception :");
                Console.WriteLine(exc.Message);
            }
            Console.WriteLine($"Client.ObjectProfileFileEditBase.OnInitializedAsync() : end");
        }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {

            if (firstRender)
            {
                try
                {
                    await this.GetProfileFile();
                    await _xmlDiffEditor.SetModifiedValue(this._modifiedProfileXml);
                    await _xmlDiffEditor.SetOriginalValue(this._originalProfileXml);

                    StateHasChanged();

                    this._hubCommandSignalRRepository.HubCommandConnection.On<ProfileFile>(SignalRHubPublishFunction.ReceiveProfileFile, (result) =>
                    {
                        Console.WriteLine($"Client.ObjectProfileFileEditBase.OnAfterRenderAsync() Start On<ProfileFile> {result.Code}");
                        //this._importFromPdaService.FileItemsInData = this._importFromPdaService.FileItemsInData.UpdateCommandResultInFileItems(
                        // this._importFromPdaService.FileItemsInData, result);
                        // this._importFromPdaService.RunImportCommandResults.UpdateCommandResulByOperationCode(result);

                        this._profileFileService.RunUpdateFtpAndDbProfiles.UpdateProfileFileByOperationCode(result);
                        this._profileFileService.RunUpdateFtpAndDbProfiles.UpdateProfileFileByOperationCode(result);

                        //SaveOrUpdatOnFtp = 5,
                        //UpdateOrInsertInventorFromFtpToDb = 6,
                        //GetByInventorCodeFromFtp = 7,
                        if (result.Step == ProfiFileStepEnum.SaveOrUpdatOnFtp)
                        {
                            if (result.Successful == SuccessfulEnum.Successful)
                            {
                            }
                        }
                        else if (result.Step == ProfiFileStepEnum.UpdateOrInsertObjectFromFtpToDb)
                        {
                            if (result.Successful == SuccessfulEnum.Successful)
                            {
                            }
                        }
                        else if (result.Step == ProfiFileStepEnum.GetByCodeFromFtp)
                        {
                            if (result.Successful == SuccessfulEnum.Successful)
                            {
                            }
                        }
                        this.StateHasChanged();
                    });

                    Console.WriteLine($"Client.ObjectProfileFileEditBase.OnAfterRenderAsync() : GetProfileFile");
                }
                catch (Exception exc)
                {
                    Console.WriteLine($"Client.ObjectProfileFileEditBase.OnAfterRenderAsync() Exception :");
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

        public async Task CheckObjectAsync()
        {

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

        public async Task InitObjectAsync()
        {

            if (string.IsNullOrWhiteSpace(this._originalProfileXml) == true)
            {
                Console.WriteLine("this._originalProfile is null");
                return;
            }

            this._profileDomainObject = DeserializeXML.DeserializeXMLTextToObject<Count4U.Service.Format.Profile>(this._originalProfileXml);

        }


    }




    public enum ScannerTypeEnum { RFID, Barcode }
}

