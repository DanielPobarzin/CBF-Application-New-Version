using System.Windows;
using System.Windows.Controls;

namespace Application.Utilities
{
	/// <summary>
	/// Класс Btn, наследующий от RadioButton.
	/// Предназначен для создания пользовательского элемента управления с заданным стилем.
	/// </summary>
	public class Btn : RadioButton
    {
        static Btn() => 
	        DefaultStyleKeyProperty
		        .OverrideMetadata(typeof(Btn), 
			        new FrameworkPropertyMetadata(typeof(Btn)));
    }
}
