using System.Globalization;

namespace Application.Exceptions
{
	/// <summary>
	/// Представляет исключение, связанное с ошибками данных.
	/// </summary>
	public class DataException : Exception
	{
		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="DataException"/>.
		/// </summary>
		public DataException() { }

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="DataException"/> с указанным сообщением.
		/// </summary>
		/// <param name="message">Сообщение, описывающее ошибку.</param>
		public DataException(string message) : base(message) { }

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="DataException"/> с указанным сообщением и аргументами форматирования.
		/// </summary>
		/// <param name="message">Сообщение, описывающее ошибку.</param>
		/// <param name="args">Аргументы форматирования сообщения.</param>
		public DataException(string message, params object[] args)
			: base(string.Format(CultureInfo.CurrentCulture, message, args))
		{ }

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="DataException"/> с указанным сообщением и внутренним исключением.
		/// </summary>
		/// <param name="message">Сообщение, описывающее ошибку.</param>
		/// <param name="innerException">Исключение, которое вызвало текущее исключение.</param>
		public DataException(string message, Exception innerException) : base(message, innerException)
		{ }
	}
}