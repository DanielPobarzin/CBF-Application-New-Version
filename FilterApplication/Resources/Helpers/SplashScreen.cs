using System;
using System.Threading;
using System.Threading.Tasks;

namespace FilterApplication.Resources.Helpers
{
	/// <summary>
	/// Загрузочное окно
	/// </summary>
	public sealed class SplashScreen : IDisposable
	{
		private volatile View.SplashScreen splashWindow;
		private readonly TaskCompletionSource<bool> tcs = new();

		public SplashScreen(string title = "SplashWindow") => Show(title);

		private async void Show(string title = "SplashWindow")
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

		private void Close()
		{
			if (splashWindow == null) return;
			Thread.Sleep(4000);
			splashWindow.Dispatcher.BeginInvoke(() =>
			{
				splashWindow.Close();
				splashWindow = null;
			});
		}

		public void Dispose()
		{
			Close();
			GC.Collect();
			GC.WaitForPendingFinalizers();
		}

		public void SetSplashInitialized()
		{
			tcs.TrySetResult(true);
		}
	}
}
