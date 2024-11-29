using Application.Interfaces.Mappings;
using AutoMapper;
using Models.Entities.HeatPowerPlant.Resources;

namespace Application.Features.Fuels.Queries.GetAll
{
	/// <summary>
	/// Объект передачи данных для поиска топлива.
	/// </summary>
	public class FuelLookupDto : IMapWith<Fuel>
	{
		public int Id { get; set; }
        public string? BrandFuel { get; set; }
		public string? Type { get; set; }
		public double LowerHeatCombustion { get; set; }
		public double SulfurContent { get; set; }
		public double AshContent { get; set; }
		public double Humidity { get; set; }
		public double NContent { get; set; }
		public double TheoreticalAirVolume { get; set; }
		public double TheoreticalVolumeGas { get; set; }
		public double TheoreticalVolumeWaterVapor { get; set; }
		public double MedianDiameterAsh { get; set; }
        public double ElectricFieldStrength { get; set; }
        public double CoefficientReverseCrown { get; set; }
		public double ElectricalResistanceAsh { get; set; }

		public void Mapping(Profile profile)
        {

			profile.CreateMap<Fuel, FuelLookupDto>()
				.ForMember(fuelDto => fuelDto.Id,
					 opt => opt.MapFrom(fuel => fuel.Id))
				.ForMember(fuelDto => fuelDto.BrandFuel,
					 opt => opt.MapFrom(fuel => fuel.BrandFuel))
				.ForMember(fuelDto => fuelDto.Type,
					 opt => opt.MapFrom(fuel => fuel.Type))
				.ForMember(fuelDto => fuelDto.LowerHeatCombustion,
					 opt => opt.MapFrom(fuel => fuel.LowerHeatCombustion))
				.ForMember(fuelDto => fuelDto.SulfurContent,
					 opt => opt.MapFrom(fuel => fuel.SulfurContent))
				.ForMember(fuelDto => fuelDto.AshContent,
					 opt => opt.MapFrom(fuel => fuel.AshContent))
				.ForMember(fuelDto => fuelDto.Humidity,
					 opt => opt.MapFrom(fuel => fuel.Humidity))
				.ForMember(fuelDto => fuelDto.NContent,
					 opt => opt.MapFrom(fuel => fuel.NContent))
				.ForMember(fuelDto => fuelDto.TheoreticalAirVolume,
					 opt => opt.MapFrom(fuel => fuel.TheoreticalAirVolume))
				.ForMember(fuelDto => fuelDto.TheoreticalVolumeGas,
					 opt => opt.MapFrom(fuel => fuel.TheoreticalVolumeGas))
				.ForMember(fuelDto => fuelDto.TheoreticalVolumeWaterVapor,
					 opt => opt.MapFrom(fuel => fuel.TheoreticalVolumeWaterVapor))
				.ForMember(fuelDto => fuelDto.MedianDiameterAsh,
					 opt => opt.MapFrom(fuel => fuel.MedianDiameterAsh))
				.ForMember(fuelDto => fuelDto.CoefficientReverseCrown,
					 opt => opt.MapFrom(fuel => fuel.CoefficientReverseCrown))
				.ForMember(fuelDto => fuelDto.ElectricalResistanceAsh,
					 opt => opt.MapFrom(fuel => fuel.ElectricalResistanceAsh));

			profile.CreateMap<FuelLookupDto, Fuel>()
			.ForMember(fuel => fuel.Id, opt => opt.MapFrom(fuelDto => fuelDto.Id))
			.ForMember(fuel => fuel.BrandFuel, opt => opt.MapFrom(fuelDto => fuelDto.BrandFuel))
			.ForMember(fuel => fuel.Type, opt => opt.MapFrom(fuelDto => fuelDto.Type))
			.ForMember(fuel => fuel.LowerHeatCombustion, opt => opt.MapFrom(fuelDto => fuelDto.LowerHeatCombustion))
			.ForMember(fuel => fuel.SulfurContent, opt => opt.MapFrom(fuelDto => fuelDto.SulfurContent))
			.ForMember(fuel => fuel.AshContent, opt => opt.MapFrom(fuelDto => fuelDto.AshContent))
			.ForMember(fuel => fuel.Humidity, opt => opt.MapFrom(fuelDto => fuelDto.Humidity))
			.ForMember(fuel => fuel.NContent, opt => opt.MapFrom(fuelDto => fuelDto.NContent))
			.ForMember(fuel => fuel.TheoreticalAirVolume, opt => opt.MapFrom(fuelDto => fuelDto.TheoreticalAirVolume))
			.ForMember(fuel => fuel.TheoreticalVolumeGas, opt => opt.MapFrom(fuelDto => fuelDto.TheoreticalVolumeGas))
			.ForMember(fuel => fuel.TheoreticalVolumeWaterVapor, opt => opt.MapFrom(fuelDto => fuelDto.TheoreticalVolumeWaterVapor))
			.ForMember(fuel => fuel.MedianDiameterAsh, opt => opt.MapFrom(fuelDto => fuelDto.MedianDiameterAsh))
			.ForMember(fuel => fuel.CoefficientReverseCrown, opt => opt.MapFrom(fuelDto => fuelDto.CoefficientReverseCrown))
			.ForMember(fuel => fuel.ElectricalResistanceAsh, opt => opt.MapFrom(fuelDto => fuelDto.ElectricalResistanceAsh));
		}
    }
}
