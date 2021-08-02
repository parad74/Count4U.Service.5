using System.Collections.Generic;
using Count4U.Model;

namespace Monitor.Service.Model
{

	public class AdapterInitCommand
	{
		public string ImportPath { get; set; }
		public string ExportPath { get; set; }
		public string PathFilter { get; set; }
		public int EncodingPage { get; set; }
		public bool IsInvertLetters { get; set; }
		public bool IsInvertWords { get; set; }
		public int StepTotal { get; set; }
		public int StepCurrent { get; set; }
		public string Path { get; set; }
		public string Path1 { get; set; }
		public string Path2 { get; set; }
		public InventProductAdvancedFieldName InventProductAdvancedDBFieldName { get; set; }
		public Dictionary<string, string> ParmsDictionary { get; set; }
		public int CountFilesInData { get; set; }

		public CommandResultCodeEnum ResultCode { get; set; }              //общий результат
		public CommandErrorCodeEnum ErrorCode { get; set; }              //расшифровка ошибки
		public string Message { get; set; }
		//public IsSingleFileOrDirectoryEnum IsSingleFileOrDirectory	 { get; set; }


		public AdapterInitCommand()
		{
			this.ImportPath = "";
			this.ExportPath = "";
			this.PathFilter = "";
			this.IsInvertLetters = false;
			this.IsInvertWords = false;
			this.StepTotal = 0;
			this.StepCurrent = 0;
			this.Path = "";
			this.Path1 = "";
			this.Path2 = "";
			this.EncodingPage = 1255;
			this.InventProductAdvancedDBFieldName = new InventProductAdvancedFieldName();
			this.ParmsDictionary = new Dictionary<string, string>();
			this.CountFilesInData = 0;
			this.ResultCode = CommandResultCodeEnum.Unknown;
			this.ErrorCode = CommandErrorCodeEnum.none;
			this.Message = "";
		}


	}
	public static class AdapterInitCommandStaticFunction
	{
		//public static AdapterInitCommand AdapterInitCommandToOneFile(this AdapterInitCommand adapterInitCommand, string fileName)
		//{
		//	if (adapterInitCommand.Files != null)
		//	{
		//		if (adapterInitCommand.Files.Contains(fileName) == true)
		//		{
		//			adapterInitCommand.Files = new List<string>() { fileName };   //TODO 	   AdapterInitAsync for one file
		//			adapterInitCommand.CountFilesInData = 1;
		//			adapterInitCommand.FileName = fileName;
		//		}
		//		else
		//		{
		//			adapterInitCommand.Files = new List<string>();   //TODO 	   AdapterInitAsync for one file
		//			adapterInitCommand.CountFilesInData = 0;
		//			adapterInitCommand.FileName = "";
		//		}
		//	}
		//	return adapterInitCommand;
		//}
	}
}
