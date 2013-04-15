using System.ComponentModel.DataAnnotations;

namespace Mazica.Domain
{
	public class NamedEntity: Entity
	{
		[Required, MaxLength]
		public string Name { get; set; }
	}
}