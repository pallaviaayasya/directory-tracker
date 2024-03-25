using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Directorywatcher
{
	public class TrackingDetailsContext:DbContext
	{
        public DbSet<WatcherDetail> WatcherDetails { get; set; }
		public string DbPath { get; set; }

        public TrackingDetailsContext()
		{
			DbPath = "dir_watcher.db";

        }

		//Configure EF to use Sqlite database file in project folder
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
			options.UseSqlite($"Data source={DbPath}");
        }
    }

	public class WatcherDetail
	{
		public string FileName { get; set; }
		public int MagicWordCount { get; set; }
		public DateTime LastModified { get; set; }
	}
}

