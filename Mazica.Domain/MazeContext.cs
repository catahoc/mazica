using System.Data.Entity;

namespace Mazica.Domain
{
	public class MazeContext
	{
		public DbSet<MazeBegin> MazeBegins { get; set; }
		public DbSet<MazeFinish> MazeFinishes { get; set; }
		public DbSet<MazeData> MazeDatas { get; set; }
		public DbSet<Account> Accounts { get; set; }
	}
}