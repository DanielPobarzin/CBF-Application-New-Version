using System;
using System.Threading;
using System.Threading.Tasks;

namespace FilterApplication.Resources.Helpers
{
	/// <summary>
	/// Загрузочное окно
	/// </summary>
	public partial class SplashScreen : IDisposable
	{
		private volatile View.SplashScreen splashWindow;
		private readonly TaskCompletionSource<bool> tcs = new();

		public SplashScreen(string title = "SplashWindow")
		{
			Show(title);
		}

		protected virtual async void Show(string title = "SplashWindow")
		{
			var thread = new Thread(() =>
			{
				splashWindow = new View.SplashScreen
				{
					Title = title
				};
				splashWindow.Show();
				System.Windows.Threading.Dispatcher.Run();
			});

			thread.SetApartmentState(ApartmentState.STA);
			thread.IsBackground = true;
			thread.Start();
			await tcs.Task;
		}

		protected virtual void Close()
		{
			if (splashWindow != null)
			{
				Thread.Sleep(4000);
				splashWindow.Dispatcher.BeginInvoke(() =>
				{
					splashWindow.Close();
					splashWindow = null;
				});
			}
		}

		public void Dispose()
		{
			Close();
			GC.Collect();
			GC.WaitForPendingFinalizers();
			GC.SuppressFinalize(this);
		}

		public void SetSplashInitialized()
		{
			tcs.TrySetResult(true);
		}
	}
}
