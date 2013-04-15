using System.Data.Entity;

namespace Mazica.Domain
{
	public class MazicaContext: DbContext
	{
		public DbSet<Maze> Mazes { get; set; }
		public DbSet<Path> Paths { get; set; }
	}
}