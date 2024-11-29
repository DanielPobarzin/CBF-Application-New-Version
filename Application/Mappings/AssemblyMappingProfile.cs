using Application.Interfaces.Mappings;
using AutoMapper;
using System.Reflection;

namespace Application.Mappings
{
	/// <summary>
	/// Профиль сопоставления для автоматического маппинга объектов.
	/// </summary>
	public class AssemblyMappingProfile : Profile
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="AssemblyMappingProfile"/>.
		/// </summary>
		/// <param name="assembly">Сборка, из которой будут извлечены типы для маппинга.</param>
		public AssemblyMappingProfile(Assembly assembly) =>
			ApplyMappingsFromAssembly(assembly);

		/// <summary>
		/// Применяет маппинги из заданной сборки.
		/// </summary>
		/// <param name="assembly">Сборка, содержащая типы, реализующие интерфейс <see cref="IMapWith{T}"/>.</param>
		private void ApplyMappingsFromAssembly(Assembly assembly)
		{
			var types = assembly.GetExportedTypes()
				.Where(type => type.GetInterfaces()
				.Any(i => i.IsGenericType &&
				i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
				.ToList();
			foreach (var type in types)
			{
				var instance = Activator.CreateInstance(type);
				var methodInfo = type.GetMethod("Mapping");
				methodInfo?.Invoke(instance, new object[] { this });
			}
		}
	}
}