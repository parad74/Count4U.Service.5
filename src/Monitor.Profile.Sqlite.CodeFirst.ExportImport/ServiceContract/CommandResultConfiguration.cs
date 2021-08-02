using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity.ModelConfiguration;

namespace Monitor.Sqlite.CodeFirst
{
	public class CommandResultConfiguration : EntityTypeConfiguration<CommandResult>
	{
		public CommandResultConfiguration()
		{
			this.ToTable("CommandResult");
			this.Property(p => p.CommandUID).HasMaxLength(100).IsRequired();
			this.Property(p => p.QueueCode).HasMaxLength(50);
			this.Property(p => p.QueueParentCode).HasMaxLength(50);
			this.Property(p => p.FileName).HasMaxLength(250);
			this.Property(p => p.CommandResultCode).HasMaxLength(50);
			this.Property(p => p.ParentCommandResultCode).HasMaxLength(50);
			this.Property(p => p.ClientAddress).HasMaxLength(250);
			this.Property(p => p.WebApiAddress).HasMaxLength(250);
			this.Property(p => p.HubAddress).HasMaxLength(250);
			this.Property(p => p.User).HasMaxLength(50);
			this.Property(p => p.AdapterName).HasMaxLength(50);
			this.Property(p => p.ProcessCode).HasMaxLength(50);
			this.Property(p => p.CustomerCode).HasMaxLength(50);
			this.Property(p => p.BranchCode).HasMaxLength(50);
			this.Property(p => p.InventorCode).HasMaxLength(50);
			this.Property(p => p.DBPath).HasMaxLength(250);
			this.Property(p => p.SessionCode).HasMaxLength(50);
			this.Property(p => p.ServiceName).HasMaxLength(50);
			this.Property(p => p.ControllerName).HasMaxLength(50);
			this.Property(p => p.AddInQueueTimeString).HasMaxLength(50);
			this.Property(p => p.StartTimeString).HasMaxLength(50);
			this.Property(p => p.ExecutionTimeString).HasMaxLength(50);
			this.Property(p => p.TotalTimeString).HasMaxLength(50);
			this.Property(p => p.CompleteTimeString).HasMaxLength(50);
		  this.Property(p => p.Error).HasMaxLength(500);
			this.Property(p => p.Message).HasMaxLength(500);
			this.Property(p => p.Path).HasMaxLength(500);
			this.Property(p => p.Path1).HasMaxLength(500);
			this.Property(p => p.Path2).HasMaxLength(500);
			this.Property(p => p.Notify).HasMaxLength(250);
			this.Property(p => p.Notify1).HasMaxLength(250);
			this.Property(p => p.Notify2).HasMaxLength(250);
			this.Property(p => p.Notify3).HasMaxLength(250);
			this.Property(p => p.Tag).HasMaxLength(50);
			this.Property(p => p.Tag1).HasMaxLength(50);
			this.Property(p => p.Tag2).HasMaxLength(50);
			this.Property(p => p.Tag3).HasMaxLength(50);
			this.Property(p => p.ConnectionID).HasMaxLength(50);
			this.Property(p => p.AuthenticationAddress).HasMaxLength(250);
			this.Property(p => p.MonitorAddress).HasMaxLength(250);
			this.Property(p => p.Email).HasMaxLength(250);
			this.Property(p => p.SendedEmailDateTimeString).HasMaxLength(50);

		}
	}
}

