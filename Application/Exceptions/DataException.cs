using System.Globalization;

namespace Application.Exceptions
{
	public class DataException : Exception
	{
		public DataException() : base() { }

		public DataException(string message) : base(message) { }

		public DataException(string message, params object[] args)
			: base(String.Format(CultureInfo.CurrentCulture, message, args))
		{ }

		public DataException(string message, Exception innerException) : base(message, innerException)
		{ }
	}
}