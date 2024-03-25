using System;
namespace Directorywatcher
{
	public class DirectoryDao
	{

        private readonly TrackingDetailsContext dbContext;

        public DirectoryDao(TrackingDetailsContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public WatcherDetail GetEntity(string file)
		{
			var fileRecord = dbContext.WatcherDetails.FirstOrDefault(x => x.FileName == file);
			return fileRecord;
		}

		public void AddEntity(WatcherDetail watcherDetail)
		{
			dbContext.WatcherDetails.Add(watcherDetail);
			dbContext.SaveChanges();
			return;
        }

		public void UpdateEntity(WatcherDetail watcherDetail)
		{
			dbContext.WatcherDetails.Update(watcherDetail);
			dbContext.SaveChanges();
			return;
		}
    }
}

