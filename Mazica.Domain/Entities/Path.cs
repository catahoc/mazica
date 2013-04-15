using System.ComponentModel.DataAnnotations;
namespace Mazica.Domain
{
	public class Path: Entity
	{
		[Required]
		public Maze Maze { get; set; }

		[Required, MaxLength]
		public byte[] Data { get; set; }
	}
}