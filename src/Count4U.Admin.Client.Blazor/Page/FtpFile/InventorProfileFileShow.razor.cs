using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Blazored.LocalStorage;
using Blazored.SessionStorage;
using BlazorMonacoJosn;
using BlazorMonacoXml;
using Count4U.Model.Count4U;
using Count4U.Service.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Configuration;
using Monitor.Service.Model;
using Monitor.Service.Shared;
using Monitor.Service.Urls;

namespace Count4U.Admin.Client.Blazor.Page
{
    public class InventorProfileFileShowBase : ComponentBase
    {
        [Parameter]
        public string inventorCode { get; set; }

        public ProfileFile _profileFile { get; set; }

        public MonacoEditorXml _xmlEditor { get; set; }
        public MonacoEditorJosn _josnEditor { get; set; }

        System.Xml.XmlDocument xmlDocument = new System.Xml.XmlDocument();
        public string _josnText { get; set; }

        public bool _isXmlEmpty { get; set; }

        private Count4U.Service.Format.Json.Profile myDeserializedClass { get; set; }

        [Inject]
        protected ISessionStorageService _sessionStorage { get; set; }

        [Inject]
        protected ILocalStorageService _localStorage { get; set; }

        [Inject]
        protected NavigationManager _navigationManager { get; set; }

        [Inject]
        protected IProfileFileService _profileFileService { get; set; }

        public InventorProfileFileShowBase()
        {
            this._profileFile = null;
            this._isXmlEmpty = true;

        }

        private async Task<string> XmlToJosn(string xmlText)
        {
            string jsonText = "";
            Console.WriteLine("XmlToJosn [" + xmlText.Length + "]");
            try
            {

                string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
                if (xmlText.StartsWith(_byteOrderMarkUtf8, StringComparison.Ordinal))
                {
                    var lastIndexOfUtf8 = _byteOrderMarkUtf8.Length;
                    xmlText = xmlText.Remove(0, lastIndexOfUtf8);
                }

                xmlDocument.LoadXml(xmlText);
                Console.WriteLine("XmlToJosn 2");
                jsonText = Newtonsoft.Json.JsonConvert.SerializeXmlNode(xmlDocument);
                Console.WriteLine("XmlToJosn 3");
                //Console.WriteLine(jsonText);
            }
            catch (Exception exp) { Console.WriteLine("XmlToJosn Exception [" + exp.Message + exp.InnerException + exp.StackTrace + "]"); };
            return jsonText;
        }

        private async Task XmlToObjectProfileViaJosn(string xmlText)
        {
            Console.WriteLine("XmlToObjectProfileViaJosn [" + xmlText.Length + "]");

            try
            {
                string jsonText = await XmlToJosn(xmlText);
                myDeserializedClass = Newtonsoft.Json.JsonConvert.DeserializeObject<Count4U.Service.Format.Json.Profile>(jsonText);

                Console.WriteLine(myDeserializedClass);
                //Console.WriteLine("xml :" + myDeserializedClass.Xml);
                Console.WriteLine("Customer1 :" + myDeserializedClass.InventoryProcessInformation.Customer.code + myDeserializedClass.InventoryProcessInformation.Customer.name);
                //Console.WriteLine("Customer :" + myDeserializedClass.Customer.Code + myDeserializedClass.Customer.Name);
            }
            catch (Exception exp) { Console.WriteLine("XmlToObjectProfileViaJosn Exception [" + exp.Message + "]"); };
            return;
        }

        private async Task RootToXml(string xmlText)
        {
            string ret = "";
            string jsonText = await XmlToJosn(xmlText);
            myDeserializedClass = Newtonsoft.Json.JsonConvert.DeserializeObject<Count4U.Service.Format.Json.Profile>(jsonText);

            Console.WriteLine(myDeserializedClass);

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Count4U.Service.Format.Json.Profile));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, myDeserializedClass);
                ret = textWriter.ToString();
                Console.WriteLine("RootToXml 1");
                Console.WriteLine(ret);
            }
            //return ret;
        }

        private string XmlToObjectProfile(string xmlText)
        {
            string jsonText = "";
            Console.WriteLine("XmlToObjectProfile [" + xmlText.Length + "]");
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Count4U.Service.Format.Json.Profile));
                using (StringReader reader = new StringReader(xmlText))
                {
                    var test = (Count4U.Service.Format.Json.Profile)serializer.Deserialize(reader);
                    Console.WriteLine(test);
                    Console.WriteLine("Customer1 :" + test.InventoryProcessInformation.Customer.code + test.InventoryProcessInformation.Customer.name);

                }
            }
            catch (Exception exp) { Console.WriteLine("XmlToObjectProfile Exception [" + exp.Message + "]"); };
            return jsonText;
        }


        public async Task OnButtonClick(string xmlText)
        {
            _josnText = await XmlToJosn(xmlText);
            StateHasChanged();
        }

        public async Task SaveObjectAsync()
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Count4U.Service.Format.Json.Profile));
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, _profileFile.ProfileJsonObject);
                Console.WriteLine("SaveObjectAsync 1 ");
                Console.WriteLine(_profileFile.ProfileXml);
                _profileFile.ProfileXml = textWriter.ToString();
                //Console.WriteLine("RootToXml 1");
                //Console.WriteLine(ret);
            }
            Console.WriteLine("SaveObjectAsync 2 ");
            Console.WriteLine(_profileFile.ProfileXml);
            ProfileFile profileFile = _profileFile;
            profileFile.ProfileJsonObject = null;
            profileFile.ProfileJosn = "";
            await _profileFileService.Update(profileFile, @"http://localhost:12389");
            this._navigationManager.NavigateTo("inventorgrid/" + _profileFile.BranchCode);
        }
        protected async Task GetProfileFile()
        {
            Console.WriteLine();
            Console.WriteLine($"Client.InventorProfileFileShowBase.GetProfileFiles() : start");

            if (this._profileFileService != null)
            {
                try
                {
                    Console.WriteLine($"Client.InventorProfileFileShowBase.GetProfileFiles() 1");
                    this._profileFile = await this._profileFileService.GetProfileFileByInventorCode(inventorCode, @"http://localhost:12389");
                    this.StateHasChanged();
                    if (string.IsNullOrWhiteSpace(this._profileFile.ProfileXml) == false)
                    {
                        this._isXmlEmpty = false;
                        // Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() 2 {this._profileFile.ProfileXml} ");
                        this._profileFile.ProfileJosn = await XmlToJosn(this._profileFile.ProfileXml);
                        this.StateHasChanged();
                        myDeserializedClass = Newtonsoft.Json.JsonConvert.DeserializeObject<Count4U.Service.Format.Json.Profile>(this._profileFile.ProfileJosn);
                        this._profileFile.ProfileJsonObject = myDeserializedClass;
                        Console.WriteLine($"Client.InventorProfileFileShowBase.GetProfileFiles() 2 {this._profileFile.ProfileJsonObject.ToString()} ");
                        //!!! From JosnObject to XML работает надо переписать через запись через MemoryStreem
                        //XmlSerializer xmlSerializer = new XmlSerializer(typeof(Count4U.Service.Format.Json.Root));
                        //using (StringWriter textWriter = new StringWriter())
                        //{
                        //    xmlSerializer.Serialize(textWriter, myDeserializedClass);
                        //   string  ret = textWriter.ToString();
                        //    Console.WriteLine("RootToXml 1");
                        //    Console.WriteLine(ret);
                        //}
                    }
                    else
                    {
                        this._isXmlEmpty = true;
                    }
                    ///Console.WriteLine($"Client.InventorProfileGridBase.GetProfileFiles() 2 {this._profileFile.ProfileXml} ");
                    //foreach (var profileFile in this._profileFiles)
                    //{
                    //	if (profileFile == null) continue; // такого не должно быть

                    //	profileFile.Members = await this._profileFileService.GetInventorCodeListFromDb(profileFile, @"http://localhost:12389");
                    //}
                    Console.WriteLine($"Client.InventorProfileFileShowBase.GetProfileFiles() 3");
                }
                catch (Exception exc)
                {
                    Console.WriteLine($"Client.InventorProfileFileShowBase.GetProfileFiles() Exception :");
                    Console.WriteLine(exc.Message);
                }
            }
            else
            {
                Console.WriteLine($"Client.InventorProfileFileShowBase.GetProfileFiles() : _profileFileService is null");
                //this._profileFile = new ProfileFile();
                Console.WriteLine($"Client.InventorProfileFileShowBase.GetRoles() : end");
            }
        }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine();
            Console.WriteLine($"Client.InventorProfileFileShowBase.OnInitializedAsync() : start");
            try
            {
                await this.GetProfileFile();
                Console.WriteLine($"Client.InventorProfileFileShowBase.OnInitializedAsync() : GetAuthenticationUrls");
            }
            catch (Exception exc)
            {
                Console.WriteLine($"Client.InventorProfileFileShowBase.OnInitializedAsync() Exception :");
                Console.WriteLine(exc.Message);
            }
            Console.WriteLine($"Client.InventorProfileFileShowBase.OnInitializedAsync() : end");
        }

    }



}
