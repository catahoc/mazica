using AutoMapper;
using System;

namespace Mazica.Utility
{
	public class CommonMapper : IMapper
	{
		public CommonMapper()
		{
			Mapper.CreateMap<int, int>();
		}

		public object Map(object source, Type from, Type to)
		{
			return Mapper.Map(source, from, to);
		}
	}
}