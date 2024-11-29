using Application.Interfaces.Mappings;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Models.Entities.HeatPowerPlant.EGM_Filters;

namespace Application.Features.EGM_Filters.Commands.Create
{
	/// <summary>
	/// Объект команды для создания нового фильтра
	/// </summary>
	public class CreateFilterCommand : IRequest<Response<Filter>>, IMapWith<Filter>
	{
		public int Id { get; set; }
		public string? BrandFilter { get; set; }
		public double Weight { get; set; }
		public double Length { get; set; }
		public double Height { get; set; }
		public double Width { get; set; }
		public double AreaActiveSection { get; set; }
		public double ActiveFieldLength { get; set; }
		public double TotalDepositionArea { get; set; }
		public double ElectrodeHeight { get; set; }
		public double CoefficientShakingMode { get; set; }
		public int NumberFields { get; set; }
		public double DistanceCpDevices { get; set; }

		public void Mapping(Profile profile)
		{

			profile.CreateMap<Filter, CreateFilterCommand>()
				.ForMember(filterDto => filterDto.Id, opt => opt.MapFrom(filter => filter.Id))
				.ForMember(filterDto => filterDto.BrandFilter, opt => opt.MapFrom(filter => filter.BrandFilter))
				.ForMember(filterDto => filterDto.Weight, opt => opt.MapFrom(filter => filter.Weight))
				.ForMember(filterDto => filterDto.Length, opt => opt.MapFrom(filter => filter.Length))
				.ForMember(filterDto => filterDto.Height, opt => opt.MapFrom(filter => filter.Height))
				.ForMember(filterDto => filterDto.Width, opt => opt.MapFrom(filter => filter.Width))
				.ForMember(filterDto => filterDto.AreaActiveSection, opt => opt.MapFrom(filter => filter.AreaActiveSection))
				.ForMember(filterDto => filterDto.ActiveFieldLength, opt => opt.MapFrom(filter => filter.ActiveFieldLength))
				.ForMember(filterDto => filterDto.TotalDepositionArea, opt => opt.MapFrom(filter => filter.TotalDepositionArea))
				.ForMember(filterDto => filterDto.ElectrodeHeight, opt => opt.MapFrom(filter => filter.ElectrodeHeight))
				.ForMember(filterDto => filterDto.CoefficientShakingMode, opt => opt.MapFrom(filter => filter.CoefficientShakingMode))
				.ForMember(filterDto => filterDto.NumberFields, opt => opt.MapFrom(filter => filter.NumberFields))
				.ForMember(filterDto => filterDto.DistanceCpDevices, opt => opt.MapFrom(filter => filter.DistanceCpDevices));

			profile.CreateMap<CreateFilterCommand, Filter>()
			.ForMember(filter => filter.Id, opt => opt.MapFrom(filterDto => filterDto.Id))
				.ForMember(filter => filter.BrandFilter, opt => opt.MapFrom(filterDto => filterDto.BrandFilter))
				.ForMember(filter => filter.Weight, opt => opt.MapFrom(filterDto => filterDto.Weight))
				.ForMember(filter => filter.Length, opt => opt.MapFrom(filterDto => filterDto.Length))
				.ForMember(filter => filter.Height, opt => opt.MapFrom(filterDto => filterDto.Height))
				.ForMember(filter => filter.Width, opt => opt.MapFrom(filterDto => filterDto.Width))
				.ForMember(filter => filter.AreaActiveSection, opt => opt.MapFrom(filterDto => filterDto.AreaActiveSection))
				.ForMember(filter => filter.ActiveFieldLength, opt => opt.MapFrom(filterDto => filterDto.ActiveFieldLength))
				.ForMember(filter => filter.TotalDepositionArea, opt => opt.MapFrom(filterDto => filterDto.TotalDepositionArea))
				.ForMember(filter => filter.ElectrodeHeight, opt => opt.MapFrom(filterDto => filterDto.ElectrodeHeight))
				.ForMember(filter => filter.CoefficientShakingMode, opt => opt.MapFrom(filterDto => filterDto.CoefficientShakingMode))
				.ForMember(filter => filter.NumberFields, opt => opt.MapFrom(filterDto => filterDto.NumberFields))
				.ForMember(filter => filter.DistanceCpDevices, opt => opt.MapFrom(filterDto => filterDto.DistanceCpDevices));
		}
	}
}
