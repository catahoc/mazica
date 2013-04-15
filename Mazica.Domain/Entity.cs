using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mazica.Domain
{
	public class Entity
	{
		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public long Id { get; set; } 
	}
}