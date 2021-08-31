using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Count4U.Admin.Client.Blazor.I18nText;
using Microsoft.AspNetCore.Components;
using Monitor.Service.Shared;

namespace Count4U.Admin.Client.Blazor.Page
{
    public class BranchProfileBase : ComponentBase
    {
        public List<ValueItem> MyFirstList { get; set; }
        public List<ValueItem> MySecondList { get; set; }
        public List<ValueItem> FieldList { get; set; }

        public List<ValueItem> SourceList { get; set; }
        public GetResources LocalizationResources { get; set; }

        [Inject]
        protected Toolbelt.Blazor.I18nText.I18nText I18nText { get; set; }

        public BranchProfileBase()
        {

            MyFirstList = new List<ValueItem>()
            {
                //   new ValueItem(){Key = "Item2", Value = "Item2", Used = true},
            };

            MySecondList = new List<ValueItem>()
            {
                //  new ValueItem(){Key = "Item1", Value = "Item1", Used = true },
            };

            FieldList = new List<ValueItem>()
          {
                 new ValueItem(){Key = "Item1", Value = "Item1" },
                new ValueItem(){Key = "Item2", Value = "Item2"},
                new ValueItem(){Key = "Item3", Value = "Item3"},
                new ValueItem(){Key = "Item4", Value = "Item4"},
                new ValueItem(){Key = "Item5", Value = "Item5"},
                new ValueItem(){Key = "Item6", Value = "Item6"},
                new ValueItem(){Key = "Item7", Value = "Item7"},
            };

        }

        public async Task RefreshList(ValueItem item)
        {
            FieldList.Remove(item);
            StateHasChanged();
        }

        protected override async Task OnInitializedAsync()
        {
            Console.WriteLine();
            Console.WriteLine($"Client.BranchProfileBase.OnInitializedAsync() : start");
            try
            {
                this.LocalizationResources = await this.I18nText.GetTextTableAsync<GetResources>(this);
                if (this.LocalizationResources == null)
                {
                    Console.WriteLine($"Client.BranchProfileBase.OnInitializedAsync() : LocalizationResources is null");
                }
            }
            catch (Exception ecx)
            {
                Console.WriteLine("Client.BranchProfileBase.OnInitializedAsync() Exception : ");
                Console.WriteLine(ecx.Message);
            }
            Console.WriteLine($"Client.BranchProfileBase.OnInitializedAsync() : end");
        }

        //public List<ValueItem> FieldList
        //{
        //    get
        //    {
        //        return SourceList;
        //    }

        //}
    }




}
