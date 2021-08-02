using System;
using System.Linq;

namespace Monitor.Service.Model
{
	public static class CommandResultHelper
	{


		public static CommandResult GetCommandResulByOperationCode(this CommandResult[] commandResults, OperationIndexEnum operationCode)
		{
			//выбираем по операции	??
			CommandResult commandResult = commandResults.FirstOrDefault(x => x.OperationIndexCode == operationCode);
			return commandResult;
		}

		public static CommandResult GetCommandResulByCommandResultCode(this CommandResult[] commandResults, string commandResultCode)
		{
			//выбираем по операции	??
			CommandResult commandResult = commandResults.FirstOrDefault(x => x.CommandResultCode == commandResultCode);
			return commandResult;
		}


		public static void UpdateCommandResulByOperationCodeFromAdapterIniCommand(this CommandResult commandResult, AdapterInitCommand adapterInitCommand)
		{
			commandResult.ErrorCode = adapterInitCommand.ErrorCode;
			if (adapterInitCommand.ErrorCode == CommandErrorCodeEnum.none)
			{
				commandResult.Successful = SuccessfulEnum.Successful;
				commandResult.ResultCode = CommandResultCodeEnum.Ok;
			}
			else
			{
				commandResult.Successful = SuccessfulEnum.NotSuccessful;
				commandResult.ResultCode = adapterInitCommand.ResultCode;
				commandResult.Error += adapterInitCommand.Message;
			}
		}

		public static void UpdateCommandResulByOperationCode(this CommandResult[] commandResults, CommandResult newCommandResult)
		{
			try
			{
				//выбираем по операции	надо будет переходить на учет транзакций
				CommandResult commandResult = commandResults.FirstOrDefault(x => x.OperationIndexCode == newCommandResult.OperationIndexCode);
				if (commandResult == null)
					return;


				var indexOf = Array.FindIndex(commandResults, x => x.OperationIndexCode == newCommandResult.OperationIndexCode);
				//CommandResult oldCommandResult =  fileItem.CommandResults.ElementAt(indexOf)	;
				if (indexOf != -1)
				{
					commandResults[indexOf] = newCommandResult;
				}
				return;
			}
			catch (Exception exc)
			{
				return;
			}
		}

		public static CommandResult[] UpdateCommandResultInCommandResultArray(this CommandResult[] commandResultArray, CommandResult newCommandResult)
		{
			if (commandResultArray == null)
				return commandResultArray;
			try
			{
				// выбираем по имени файла
				//выбираем по операции	надо будет переходить на учет транзакций
				CommandResult commandResult = commandResultArray.FirstOrDefault(x => x.OperationIndexCode == newCommandResult.OperationIndexCode); //&& x.TransactionCode == newCommandResult.TransactionCode);
				if (commandResult == null)
					return commandResultArray;
				try
				{
					var indexOf = Array.FindIndex(commandResultArray, x => x.OperationIndexCode == newCommandResult.OperationIndexCode);
					//CommandResult oldCommandResult =  fileItem.CommandResults.ElementAt(indexOf)	;
					if (indexOf != -1)
					{
						commandResultArray[indexOf] = newCommandResult;
					}
					return commandResultArray;
				}
				catch (Exception exc)
				{
					return commandResultArray;
				}
			}
			catch (Exception exc)
			{
				return commandResultArray;
			}
		}


		public static void UpdateCommandResulArrayFromCount4uContext(this CommandResult[] commandResults, ICount4uContext count4uContext)
		{
			foreach (CommandResult command in commandResults)
			{
				command.ProcessCode = count4uContext.ProcessCode;
				command.CustomerCode = count4uContext.CustomerCode;
				command.BranchCode = count4uContext.BranchCode;
				command.InventorCode = count4uContext.InventorCode;

				command.DBPath = count4uContext.DBPath;
			}
		}
	}
}
