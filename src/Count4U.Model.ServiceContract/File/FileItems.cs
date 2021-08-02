using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
//using System.Drawing.Imaging;
using System.Linq;
using Count4U.Common.Constants;
using Count4U.Model.Count4U;
using Count4U.Service.Contract;
using Count4U.Service.Model;
using Monitor.Service.Model;
//using Zen.Barcode;
//using Count4U.Common.UserSettings;

namespace Count4U.Service.Contract
{
	[Serializable]
	public class FileItems : ObservableCollection<FileItem>
	{
		public static FileItems FromEnumerable(IEnumerable<FileItem> list)
		{
			var collection = new FileItems();
			return Fill(collection, list);
		}

		public static FileItems Fill(FileItems collection, IEnumerable<FileItem> list)
		{
			foreach (FileItem item in list)
				collection.Add(item);
			return collection;
		}



		public FileItem CurrentItem { get; set; }

		public EventHandler CurrentChanged { get; set; }

		public long TotalCount { get; set; }

		//Ловим с хаба и заменяем на UI. Вся ифа должна вернуться с частными изменениями - результатами обработки	1
		public  FileItems UpdateCommandResultInFileItems(FileItems fileItems, CommandResult newCommandResult)
		{
			if (newCommandResult == null) return fileItems;
			try
			{
				// выбираем по имени файла
				foreach (FileItem fileItem in fileItems)
				{
					if (fileItem.Name != newCommandResult.FileName)
						continue;
					//выбираем по операции	надо будет переходить на учет транзакций
					CommandResult commandResult = fileItem.CommandResults.FirstOrDefault(x => x.OperationIndexCode == newCommandResult.OperationIndexCode); //&& x.TransactionCode == newCommandResult.TransactionCode);
					if (commandResult == null)
						return fileItems;
					try
					{
						var indexOf = Array.FindIndex(fileItem.CommandResults, x => x.OperationIndexCode == newCommandResult.OperationIndexCode);
						//CommandResult oldCommandResult =  fileItem.CommandResults.ElementAt(indexOf)	;
						if (indexOf != -1)
						{
							fileItem.CommandResults[indexOf] = newCommandResult;
							if (newCommandResult.Step == AdapterCommandStepEnum.MoveFileAfter)
							{
								if (newCommandResult.Successful == SuccessfulEnum.Successful)
								{
									fileItem.CanImport = false;
								}
							}
						}
						return fileItems;
					}
					catch (Exception exc)
					{
						string message = exc.Message;
						return fileItems;
					}
				}
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				return fileItems;
			}

			 return fileItems;
		}


	}

	public static class FileItemsStaticFunction
	{
		public static FileItems AddEnumerableIturs(this FileItems collection, IEnumerable<FileItem> list)
		{
			foreach (FileItem item in list)
				collection.Add(item);
			return collection;
		}

		public static FileItems FromDictionaryToFileItems(this Dictionary<string, FileItem> fileItemDictionary)
		{
			var collection = new FileItems();
			foreach (var item in fileItemDictionary.Values)
				collection.Add(item);
			return collection;
		}

		public static Dictionary<string, FileItem> FromFileItemsToDictionaryByFileName(this FileItems fileItems)
		{
			Dictionary<string, FileItem> dictionary = fileItems.Select(x => x).Distinct().ToDictionary(k => k.Name);
			return dictionary;
		}

		public static Dictionary<string, CommandResult[]> CommandResultArrayToDictionaryByFileName(this FileItems fileItems)
		{
			Dictionary<string, FileItem> dictionary = fileItems.Select(x => x).Distinct().ToDictionary(k => k.Name);
			Dictionary<string, CommandResult[]> dictionaryCommandResultArray = new Dictionary<string, CommandResult[]>();
			foreach (var item in dictionary)
			{
				try
				{
					dictionaryCommandResultArray[item.Key] = item.Value.CommandResults;
				}
				catch { }
			}

			return dictionaryCommandResultArray;
		}

		public static CommandResult GetCommandResultByFileNameAndOperationCode(this FileItems fileItems, string fileName, OperationIndexEnum operationCode)
		{
			CommandResult commandResult = null;
			try
			{
				FileItem fileItem = fileItems.FirstOrDefault(x => x.Name == fileName);
				if (fileItem != null)
				{
					commandResult = fileItem.CommandResults.FirstOrDefault(x => x.OperationIndexCode == operationCode);
				}
			}
			catch { }
			return commandResult;
		}

		public static SuccessfulEnum GetSuccessfulByFileNameAndOperationCode(this FileItems fileItems, string fileName, OperationIndexEnum operationCode)
		{
			CommandResult commandResult = new CommandResult(SuccessfulEnum.NotStart, CommandResultCodeEnum.Unknown, CommandErrorCodeEnum.none );
			try
			{
				FileItem fileItem = fileItems.FirstOrDefault(x => x.Name == fileName);
				if (fileItem != null)
				{
					CommandResult commandResult1 = fileItem.CommandResults.FirstOrDefault(x => x.OperationIndexCode == operationCode);
					if(commandResult1 != null) commandResult = commandResult1;
				}
			}
			catch { }
			return commandResult.Successful;
		}

		//Ловим с хаба и заменяем на UI. Вся ифа должна вернуться с частными изменениями - результатами обработки
		// выбираем по имени файла
		public static FileItems UpdateCommandResultInFileItems(this FileItems fileItems, CommandResult newCommandResult)
		{
			if (newCommandResult == null) return fileItems;
			try
			{
				// выбираем по имени файла
				foreach (FileItem fileItem in fileItems)
				{
					if (fileItem.Name != newCommandResult.FileName)
						continue;
					
					//выбираем по операции	надо будет переходить на учет транзакций
					CommandResult commandResult = fileItem.CommandResults.FirstOrDefault(x => x.OperationIndexCode == newCommandResult.OperationIndexCode);
					if (commandResult == null)
						return fileItems;
					try
					{
						var indexOf = Array.FindIndex(fileItem.CommandResults, x => x.OperationIndexCode == newCommandResult.OperationIndexCode);
						//CommandResult oldCommandResult =  fileItem.CommandResults.ElementAt(indexOf)	;
						if (indexOf != -1)
						{
							fileItem.CommandResults[indexOf] = newCommandResult;
						}
						return fileItems;
					}
					catch (Exception exc)
					{
						string message = exc.Message;
						return fileItems;
					}
				}
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				return fileItems;
			}

			 return fileItems;
		}


		
	}
}








