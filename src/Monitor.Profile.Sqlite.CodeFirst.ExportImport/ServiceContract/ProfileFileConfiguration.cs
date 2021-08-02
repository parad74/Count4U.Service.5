using System.Data.Entity.ModelConfiguration;

namespace Monitor.Sqlite.CodeFirst
{
	public class ProfileFileConfiguration : EntityTypeConfiguration<ProfileFile>
	{
		public ProfileFileConfiguration()
		{
			this.ToTable("ProfileFile");
			this.Property(p => p.ProfileFileUID).HasMaxLength(100).IsRequired();
			this.Property(p => p.Code).HasMaxLength(250);
			this.Property(p => p.ParentCode).HasMaxLength(50);
			this.Property(p => p.CustomerCode).HasMaxLength(50);
			this.Property(p => p.BranchCode).HasMaxLength(50);
			this.Property(p => p.InventorCode).HasMaxLength(50);
			this.Property(p => p.CustomerName).HasMaxLength(100);
			this.Property(p => p.BranchName).HasMaxLength(100);
			this.Property(p => p.InventorName).HasMaxLength(100);
			this.Property(p => p.SubFolder).HasMaxLength(50);
			this.Property(p => p.InventorDBPath).HasMaxLength(200);
			this.Property(p => p.DomainObject).HasMaxLength(50);
			this.Property(p => p.AuditCode).HasMaxLength(100);
			this.Property(p => p.CurrentPath).HasMaxLength(500);
			this.Property(p => p.Error).HasMaxLength(500);
			this.Property(p => p.Message).HasMaxLength(500);
	
			//this.Property(p => p.ProfileXml).HasMaxLength(100000);
			//this.Property(p => p.ProfileJosn).HasMaxLength(100000);

		}
	}
}

