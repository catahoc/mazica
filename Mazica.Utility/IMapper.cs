using System;
namespace Mazica.Utility
{
	public interface IMapper
	{
		object Map(object source, Type from, Type to);
	}
}