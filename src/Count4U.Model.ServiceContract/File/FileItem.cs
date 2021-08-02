using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using Count4U.Common.Constants;
using Count4U.Service.Model;
using Monitor.Service.Model;

namespace Count4U.Service.Contract
{

    [Serializable]
     public class FileItem
    {
       public DateTime LastModified { get; set; }
       public DateTime DateTimeCreated  { get; set; }
       public string LastModifiedString { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }
        public string Type{ get; set; }
         public bool InData { get; set; }
        public string PathInData { get; set; }
        public bool IsImporting { get; set; }
         public bool IsImported { get; set; }
         public bool CanImport { get; set; }
     	public CommandResult[] CommandResults {get; set;}

        public FileItem()
        {
            LastModified = DateTime.Now;
            DateTimeCreated = DateTime.Now;
            LastModifiedString = "";
            Name = "";
            Size = 0;
            Type = "";
            InData = false;
            PathInData = "";
            IsImporting = false;
            IsImported = false;
            CanImport = false;
        }
 

       	public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != typeof(FileItem)) return false;
			return Equals((FileItem)obj);
		}

		public bool Equals(FileItem other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return Equals(other.Name, this.Name);
		}

		public override int GetHashCode()
		{
			return (Name != null ? Name.GetHashCode() : 0);
		}
    }

    public static class FileItemStaticFunction
    {
        public static FileItem ToFileItem(this FileInfo fileInfo)
        {
            FileItem fi = new FileItem();
            fi.LastModified = fileInfo.LastWriteTime;
            fi.DateTimeCreated = fileInfo.CreationTime;
            fi.LastModifiedString = "";
            fi.Name = fileInfo.Name;
            fi.Size = fileInfo.Length;
            fi.Type = fileInfo.Extension;
            fi.InData = true;
            fi.PathInData = fileInfo.FullName;
            fi.IsImporting = false;
            fi.IsImported = false;
            fi.CanImport = true;
            return fi;
        }

       	public static SuccessfulEnum GetSuccessfulByOperationCode(this FileItem fileItem, OperationIndexEnum operationCode)
		{
			CommandResult commandResult = new CommandResult(SuccessfulEnum.NotStart, CommandResultCodeEnum.Unknown, CommandErrorCodeEnum.none );
			try
			{
				if (fileItem != null)
				{
					CommandResult commandResult1 = fileItem.CommandResults.FirstOrDefault(x => x.OperationIndexCode == operationCode);
					if (commandResult1 != null) commandResult =  commandResult1;
				}
			}
			catch { }
			return commandResult.Successful;
		}

		public static void SetSuccessfulByOperationCode(this FileItem fileItem, OperationIndexEnum operationCode, SuccessfulEnum toSuccessful)
		{
			try
			{
				if (fileItem != null)
				{
					CommandResult commandResult = fileItem.CommandResults.FirstOrDefault(x => x.OperationIndexCode == operationCode);
					if (commandResult != null)
					{
						commandResult.Successful = toSuccessful;
					}
				}
			}
			catch { }
		}

		public static CommandResultCodeEnum GetResultCodeByOperationCode(this FileItem fileItem, OperationIndexEnum operationCode)
		{
			CommandResult commandResult = new CommandResult(SuccessfulEnum.NotStart, CommandResultCodeEnum.Unknown, CommandErrorCodeEnum.none);
			try
			{
				if (fileItem != null)
				{
					CommandResult commandResult1 = fileItem.CommandResults.FirstOrDefault(x => x.OperationIndexCode == operationCode);
					if(commandResult1 != null) commandResult = commandResult1;
				}
			}
			catch { }
			return commandResult.ResultCode;
		}

		public static void SetResultCodeByOperationCode(this FileItem fileItem, OperationIndexEnum operationCode, CommandResultCodeEnum commandResultCodeEnum)
		{
			try
			{
				if (fileItem != null)
				{
					CommandResult  commandResult = fileItem.CommandResults.FirstOrDefault(x => x.OperationIndexCode == operationCode);
					if (commandResult != null)
					{
						commandResult.ResultCode = commandResultCodeEnum;
					}
				}
			}
			catch { }
		}

		public static CommandResult GetCommandResultByOperationCode(this FileItem fileItem, OperationIndexEnum operationCode)
		{
			CommandResult commandResult = new CommandResult(SuccessfulEnum.NotStart, CommandResultCodeEnum.Unknown, CommandErrorCodeEnum.none );
			try
			{
				if (fileItem != null)
				{
					CommandResult commandResult1 = fileItem.CommandResults.FirstOrDefault(x => x.OperationIndexCode == operationCode);
					if (commandResult1 != null)  commandResult = commandResult1;
				}
			}
			catch { }
			return commandResult;
		}

		public static bool SetToAllCommandResultsSuccessfulEnum(this FileItem fileItem, SuccessfulEnum toSuccessful )
		{
			 if(fileItem == null) return false;
			try
			{
				 if (fileItem.CommandResults == null) return false;
				foreach (CommandResult commandResult in fileItem.CommandResults)
				{
					try
					{
						commandResult.Successful = toSuccessful;
					}
					catch (Exception exc)
					{
						string message = exc.Message;
						return false;
					}
				}
				return true;
			}
			catch (Exception exc)
			{
				string message = exc.Message;
				return false;
			}
		}

    }
}