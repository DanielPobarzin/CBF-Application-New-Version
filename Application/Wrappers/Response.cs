namespace Application.Wrappers
{
	/// <summary>
	/// Представляет ответ с данными, сообщением и статусом успешности.
	/// </summary>
	/// <typeparam name="T">Тип данных, содержащихся в ответе.</typeparam>
	public class Response<T>
	{
		/// <summary>
		/// Указывает, был ли запрос успешным.
		/// </summary>
		public bool Succeeded { get; set; }

		/// <summary>
		/// Сообщение, связанное с ответом.
		/// </summary>
		public string Message { get; set; } = null!;

		/// <summary>
		/// Количество элементов в ответе (если применимо).
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// Данные, возвращаемые в ответе.
		/// </summary>
		public T Data { get; set; } = default!;

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="Response{T}"/>.
		/// </summary>
		public Response()
		{
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="Response{T}"/> с указанными данными и статусом успешности.
		/// </summary>
		/// <param name="data">Данные, которые нужно вернуть в ответе.</param>
		/// <param name="succeeded">Указывает, был ли запрос успешным.</param>
		public Response(T data, bool succeeded)
		{
			Succeeded = succeeded;
			Data = data;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="Response{T}"/> с указанными данными, статусом успешности и количеством элементов.
		/// </summary>
		/// <param name="data">Данные, которые нужно вернуть в ответе.</param>
		/// <param name="succeeded">Указывает, был ли запрос успешным.</param>
		/// <param name="count">Количество элементов в ответе.</param>
		public Response(T data, bool succeeded, int count)
		{
			Succeeded = succeeded;
			Data = data;
			Count = count;
		}

		/// <summary>
		/// Инициализирует новый экземпляр класса <see cref="Response{T}"/> с сообщением об ошибке.
		/// </summary>
		/// <param name="message">Сообщение об ошибке.</param>
		public Response(string message)
		{
			Succeeded = false;
			Message = message;
		}
	}
}