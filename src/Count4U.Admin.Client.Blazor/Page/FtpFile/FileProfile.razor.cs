using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using Count4U.Service.Shared;
using Service.Model;
using Microsoft.JSInterop;
using Newtonsoft.Json;
using System.Dynamic;
using Newtonsoft.Json.Converters;
using Count4U.Admin.Client.Blazor.I18nText;

namespace Count4U.Admin.Client.Blazor.Page.FtpFile
{
	public class FileProfileBase : ComponentBase
	{
		[Inject]
		public IConfiguration Configuration { get; set; }
		[Inject]
		public HttpClient Http { get; set; }

        [Inject]
        protected Toolbelt.Blazor.I18nText.I18nText I18nText { get; set; }

        protected GetResources LocalizationResources { get; set; }


        public Count4U.Service.Format.Json.Customer _customerObject { get; set; }
        public Count4U.Service.Format.Json.Profile _profileObject { get; set; }

        //[Inject]
        //IJSRuntime jsRuntime { get; set; }

        public FileProfileBase()
		{
            _customerObject = new Count4U.Service.Format.Json.Customer();
            //       inTitle = @"<? xml version = '1.0' encoding = 'utf-8' ?>
            // <Profile>
            //<InventoryProcessInformation>
            //				 <Customer name = 'NextLine' code = '900'/>
            //	  <Branch name = '' code = '900-002'/>
            //	<Inventory code = '634584ed-9a1d-4aa6-91b1-76cbc5981981' created_date = '2020/1/23'/>
            //</InventoryProcessInformation>
            // <BarcodeManipulations> </BarcodeManipulations>
            //               <ScannerType>Barcode</ScannerType>
            //               <LocationInventoryListScreenConfiguration>
            //                       <AddNewInventoryEnabled>true</AddNewInventoryEnabled>
            //                       <TemplateInventoriesEnabled>false</TemplateInventoriesEnabled>
            //                       <SignatureToVerifyClosureOfLocationRequired>true</SignatureToVerifyClosureOfLocationRequired>
            //               </LocationInventoryListScreenConfiguration>
            //<Version> 1 </ Version>
            //<Customer name = 'NextLine1' code = '9001' />
            // </Profile>";


            inTitle = @"<?xml version = '1.0' encoding = 'utf-8'?>
        <InventoryListDefaultUIConfiguration>
        <ShowInventoryImageIndicator> false </ShowInventoryImageIndicator>
        <InventoryItemsProperties>
            <InventoryItemDisplayProperty id = 'Catalog.ItemName' itemtype = 'SN:Q'>
                   <Title en = 'Item Name' he = 'תיאור פריט '/>
                      <invalid> false </invalid>
                      <id> 1 </id>
                   </InventoryItemDisplayProperty>
                  <InventoryItemDisplayProperty id = 'Catalog.ItemCode' itemtype = 'SN:Q'>
                         <Title en = 'Item Code' he = 'קוד פריט' />
                            <invalid> false </invalid>
                            <id> 2 </id>
                        </InventoryItemDisplayProperty>
                        <InventoryItemDisplayProperty id = 'Quantity' itemtype = 'SN:Q'>
                               <Title en = 'Quantity' he = 'כמות'/>
                                  <invalid> false </invalid>
                                  <id> 3 </id>
                              </InventoryItemDisplayProperty>
                              <InventoryItemDisplayProperty id = 'SerialNumberLocal' itemtype = 'SN'>
                                     <Title en = 'SN local' he = 'סריאלי מקומי' />
                                        <invalid> false </invalid>
                                        <id> 4 </id>
                                    </InventoryItemDisplayProperty>
                                            </InventoryItemsProperties>
                                        </InventoryListDefaultUIConfiguration>";

            //  Profile: { "InventoryProcessInformation":[{ "Customer":[{ "_attributes":{ "name":"NextLine","code":"900"} }],"Branch":[{ "_attributes":{ "name":"","code":"900-002"} }],"Inventory":[{ "_attributes":{ "code":"634584ed-9a1d-4aa6-91b1-76cbc5981981","created_date":"2020/1/23"} }]}],
            //"BarcodeManipulations":[{ }],
            //"Version":[{ "_text":[" 1 "]}],
            //"Customer":[{ "_attributes":{ "name":"NextLine1","code":"9001"} }]}

            //Profile: { "InventoryProcessInformation":[{ "Customer":[{ "_attributes":{ "name":"NextLine","code":"900"} }],"Branch":[{ "_attributes":{ "name":"","code":"900-002"} }],"Inventory":[{ "_attributes":{ "code":"634584ed-9a1d-4aa6-91b1-76cbc5981981","created_date":"2020/1/23"} }]}],
            //"BarcodeManipulations":[{ }],
            //"ScannerType":[{ "_text":["Barcode"]}],
            //"LocationInventoryListScreenConfiguration":[{ "AddNewInventoryEnabled":[{ "_text":["true"]}],"TemplateInventoriesEnabled":[{ "_text":["false"]}],"SignatureToVerifyClosureOfLocationRequired":[{ "_text":["true"]}]}],
            //"Version":[{ "_text":[" 1 "]}],
            //"Customer":[{ "_attributes":{ "name":"NextLine1","code":"9001"} }]}

            //dynamic configProfile = JsonConvert.DeserializeObject<ExpandoObject>(profile.ToString(), new ExpandoObjectConverter());
            //Console.WriteLine(@"configProfile.Customer.attributes.name :" + configProfile.Customer[0]._attributes.name);
            //Console.WriteLine(@"configProfile.Customer.attributes.code :" + configProfile.Customer[0]._attributes.code);
            //Console.WriteLine(@"configProfile.Version :" + configProfile.Version[0]._text[0]);
            //Console.WriteLine(@"configProfile.ScannerType :" + configProfile.ScannerType[0]._text[0]);
            //Console.WriteLine(@"configProfile.AddNewInventoryEnabled :" + configProfile.LocationInventoryListScreenConfiguration[0].AddNewInventoryEnabled._text[0]);
            //Console.WriteLine(@"configProfile.TemplateInventoriesEnabled :" + configProfile.LocationInventoryListScreenConfiguration[0].TemplateInventoriesEnabled._text[0]);
            //Console.WriteLine(@"configProfile.SignatureToVerifyClosureOfLocationRequired :" + configProfile.LocationInventoryListScreenConfiguration[0].SignatureToVerifyClosureOfLocationRequired._text[0]);
        }

        public string inTitle { get; set; }
		public string outTitle { get; set; }

        //protected override async Task OnAfterRenderAsync(bool firstRender)
        //{
        //    Console.Write(inTitle);
        //    Console.WriteLine();
        //    if (firstRender)
        //    {
        //        //	outTitle = await jsRuntime.InvokeAsync<string>("BlazorUniversity.profileModel", inTitle);
        //        var josnObject = await jsRuntime.InvokeAsync<object>("BlazorUniversity.setDataJsObjectFromXml", inTitle);
        //        if (josnObject != null)
        //        {

        //            try
        //            {
        //                System.Text.Json.JsonElement customer = await jsRuntime.InvokeAsync<System.Text.Json.JsonElement>("BlazorUniversity.findInProfile0", "Customer");
        //                Console.WriteLine($"customer.ValueKind = {customer.ValueKind}");

        //                dynamic config = JsonConvert.DeserializeObject<ExpandoObject>(customer.ToString(), new ExpandoObjectConverter());

        //                Console.WriteLine($"Deserialized JSON into {config.GetType()}");
        //                //customerExpando.Name = NextLine1
        //                //customerExpando.code = 9001
        //                try
        //                {
        //                    Console.WriteLine($"customerExpando.Name = {config._attributes.name}");
        //                }
        //                catch { }
        //                try
        //                {
        //                    Console.WriteLine($"customerExpando.code = {config._attributes.code}");
        //                }
        //                catch { }

        //                config._attributes.name = "newName";
        //                config._attributes.code = "newCode";
        //                try
        //                {
        //                    Console.WriteLine($"customerExpando.Name = {config._attributes.name}");
        //                }
        //                catch { }
        //                try
        //                {
        //                    Console.WriteLine($"customerExpando.code = {config._attributes.code}");
        //                }
        //                catch { }



        //                string currentXml = await jsRuntime.InvokeAsync<string>("BlazorUniversity.getXml");
        //                Console.WriteLine($"current Xml - XML {currentXml}");

        //                //customer ={"_attributes":{"name":"","code":""}}
        //                Console.WriteLine("Customer =" + customer.ToString());
        //                Count4U.Service.Format.Json.Customer myDeserializedClass =
        //                    JsonConvert.DeserializeObject<Count4U.Service.Format.Json.Customer>(customer.ToString());
        //                Console.WriteLine("myDeserializedClass = " + myDeserializedClass.ToString());
        //                Console.WriteLine("Customer.Name =" + myDeserializedClass.Name);
        //                Console.WriteLine("Customer.Code =" + myDeserializedClass.Code);

        //                System.Text.Json.JsonElement inventory = await jsRuntime.InvokeAsync<System.Text.Json.JsonElement>("BlazorUniversity.findInInventoryProcessInformation0", "Customer");
        //                Console.WriteLine("InventoryProcessInformation =" + inventory.ToString());

        //                dynamic config1 = JsonConvert.DeserializeObject<ExpandoObject>(inventory.ToString(), new ExpandoObjectConverter());

        //                Console.WriteLine($"Deserialized JSON into 1 {config1.GetType()}");

        //                //customerObject1.Name = NextLine
        //                //customerObject1.code = 900
        //                try
        //                {
        //                    Console.WriteLine($"customerObject1.Name = {config1._attributes.name}");
        //                }
        //                catch { }
        //                try
        //                {
        //                    Console.WriteLine($"customerObject1.code = {config1._attributes.code}");
        //                }
        //                catch { }

        //                //InventoryProcessInformation =
        //                //{ "Customer":[{ "_attributes":{ "name":"NextLine","code":"900"} }],"Branch":[{ "_attributes":{ "name":"","code":"900-002"} }],"Inventory":[{ "_attributes":{ "code":"634584ed-9a1d-4aa6-91b1-76cbc5981981","created_date":"2020/1/23"} }]}
        //                Count4U.Service.Format.Json.Customer myDeserializedClass1 =
        //                JsonConvert.DeserializeObject<Count4U.Service.Format.Json.Customer>(inventory.ToString());
        //                Console.WriteLine("myDeserializedClass1 = " + myDeserializedClass1.ToString());
        //                //customer ={"_attributes":{"name":"","code":""}}
        //                Console.WriteLine("Customer1.Name =" + myDeserializedClass1.Name);
        //                Console.WriteLine("Customer1.Code =" + myDeserializedClass1.Code);



        //                Console.Write($"TYPE: {customer.GetType()}");
        //            }
        //            catch { }



        //            Console.WriteLine();
        //            outTitle = await jsRuntime.InvokeAsync<string>("BlazorUniversity.dataJsObject2Xml", josnObject);
        //            Console.Write(outTitle);
        //            try
        //            {
        //                string outTitle1 = await jsRuntime.InvokeAsync<string>("BlazorUniversity.xml2json", inTitle);
        //                //{ "_instruction":[{ "":"xml version = '1.0' encoding = 'utf-8' "}],
        //                //	"Profile":[{ "InventoryProcessInformation":[{ "Customer":[{ "_attributes":{ "name":"NextLine","code":"900"} }],
        //                //			"Branch":[{ "_attributes":{ "name":"","code":"900-002"} }],
        //                //			"Inventory":[{ "_attributes":{ "code":"634584ed-9a1d-4aa6-91b1-76cbc5981981","created_date":"2020/1/23"} }]}],
        //                //		"BarcodeManipulations":[{ }],"Version":[{ "_text":[" 1 "]}],"Customer":[{ "_attributes":{ "name":"","code":""} }]}]}
        //                Console.Write($"xml2json: {outTitle1}");
        //            }
        //            catch { }

        //        }
        //    }
        //}
    }
}
