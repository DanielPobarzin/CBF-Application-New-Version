using System.Collections.ObjectModel;

namespace Application.Extensions
{
	public static class ObservableCollectionExtensions
	{
		public static int IndexOf<T>(this ObservableCollection<T> collection, T item)
		{
			for (int i = 0; i < collection.Count; i++)
			{
				if (EqualityComparer<T>.Default.Equals(collection[i], item))
				{
					return i;
				}
			}
			return -1;
		}
	}
}
