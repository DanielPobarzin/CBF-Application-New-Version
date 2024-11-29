using AutoMapper;

namespace Application.Interfaces.Mappings
{
	public interface IMapWith<T>
	{
		void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
	}
}
