using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Mazica.Domain
{
	public class Maze: Entity
	{
		public Maze()
		{
			Paths = new HashSet<Path>();
		}

		[Required, MaxLength]
		public byte[] Data { get; set; }

		public long Width { get; set; }
		public long Height { get; set; }
		public long Depth { get; set; }

		public virtual ICollection<Path> Paths { get; set; }
	}
}