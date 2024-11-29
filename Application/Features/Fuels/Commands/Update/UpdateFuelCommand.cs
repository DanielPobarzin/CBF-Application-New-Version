using Application.Interfaces.Mappings;
using Application.Wrappers;
using AutoMapper;
using MediatR;
using Models.Entities.HeatPowerPlant.Resources;

namespace Application.Features.Fuels.Commands.Update
{
	public class UpdateFuelCommand : IRequest<Response<Fuel>>, IMapWith<Fuel>
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
			profile.CreateMap<Fuel, UpdateFuelCommand>()
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

			profile.CreateMap<UpdateFuelCommand, Fuel>()
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

		}
	}
}
