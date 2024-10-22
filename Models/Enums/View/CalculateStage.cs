using System.ComponentModel;

namespace Models.Enums.View
{
	public enum CalculateStage
    {
		[Description("")]
        None,
		[Description("Загрузка")]
		Loading,
		[Description("Обработка")]
		Processing,
		[Description("Расчет")]
		Calculating,
		[Description("✔")]
		Done

    }
}