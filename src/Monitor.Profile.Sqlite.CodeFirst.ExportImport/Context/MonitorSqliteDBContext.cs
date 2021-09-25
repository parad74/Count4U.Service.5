using Microsoft.EntityFrameworkCore;

namespace Monitor.Sqlite.CodeFirst
{
 	public class MonitorSqliteDBContext : DbContext
	{
	    public MonitorSqliteDBContext(DbContextOptions<MonitorSqliteDBContext> options) : base(options)
        {
        }
	
	
	   //protected override void OnConfiguring(DbContextOptionsBuilder builder)
    //    {
    //        builder.UseSqlite(@"Data Source=Data Source=command.db");
    //    }
  		
		public DbSet<CommandResult> CommandResultDatas { get; set; }
		public DbSet<ProfileFile> ProfileFileDatas { get; set; }
		

		protected override void OnModelCreating(
						ModelBuilder modelBuilder)
		{
		   base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<CommandResult>().ToTable("CommandResult");
			modelBuilder.Entity<ProfileFile>().ToTable("ProfileFile");
		}

	}
}

//Add-Migration SeedRoles
//Update-Database

//Add-Migration UserEmail  -Context MonitorSqliteDBContext
//Update-Database  -Context MonitorSqliteDBContext