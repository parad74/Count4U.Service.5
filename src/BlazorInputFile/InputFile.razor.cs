using BlazorInputFile;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Count4U.Client.Component {
	public class InputFileBase : ComponentBase, IDisposable {
		[Inject]
		public IJSRuntime JSRuntime { get; set; }


		[Parameter(CaptureUnmatchedValues = true)] public Dictionary<string, object> UnmatchedParameters { get; set; }
		[Parameter] public EventCallback<IFileListEntry[]> OnChange { get; set; }
		[Parameter] public int MaxMessageSize { get; set; } = 20 * 1024; // TODO: Use SignalR default
		[Parameter] public int MaxBufferSize { get; set; } = 1024 * 1024;

		[Parameter] public string ElementId { get; set; } // this id is used by the js function 'wrapInput' which calls click()
		[Parameter] public bool IsElementHidden { get; set; } = false;

		public ElementReference inputFileElement;

		public IDisposable thisReference;

		protected override async Task OnAfterRenderAsync(bool firstRender) {
			if (firstRender) {
				thisReference = DotNetObjectReference.Create(this);
				await JSRuntime.InvokeAsync<object>("BlazorInputFile.init", inputFileElement, thisReference);
			}
		}

		internal Stream OpenFileStream(FileListEntryImpl file) {
			return SharedMemoryFileListEntryStream.IsSupported(JSRuntime)
				? (Stream)new SharedMemoryFileListEntryStream(JSRuntime, inputFileElement, file)
				: new RemoteFileListEntryStream(JSRuntime, inputFileElement, file, MaxMessageSize, MaxBufferSize);
		}

		void IDisposable.Dispose() {
			thisReference?.Dispose();
		}


		//protected override async Task OnInitializedAsync()
		//{
		//	Console.WriteLine();
		//	Console.WriteLine($"Client.ClaimsBase.OnInitializedAsync() : start");
		//	try
		//	{
		//		this.Title = "Claims from Web API";
		//		//var claimList = await ClaimService.GetClaimConvertItemsAsync();	   //работает
		//		var claimList = await this._claimService.GetClaimsFromWebApiAsync();    //тест 
		//		Console.WriteLine($"Client.ClaimsBase.OnInitializedAsync() : count processes {claimList.Count}");
		//		this._viewModel.ClaimList = claimList;
		//	}
		//	catch (Exception exc)
		//	{
		//		Console.WriteLine($"Client.ClaimsBase.OnInitializedAsync() Exception :");
		//		Console.WriteLine(exc.Message);
		//	}
		//	Console.WriteLine($"Client.ClaimsBase.OnInitializedAsync() : end");
		//}



	}

}

