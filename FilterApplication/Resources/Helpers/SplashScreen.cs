using System;
using System.Threading;
using System.Threading.Tasks;

namespace FilterApplication.Resources.Helpers
{
	public partial class SplashScreen : IDisposable
	{
		private volatile View.SplashScreen splashWindow;
		private TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();

		public SplashScreen(string title = "SplashWindow")
		{
			Show(title);
		}

		protected virtual async void Show(string title = "SplashWindow")
		{
			var thread = new Thread(() =>
			{
				splashWindow = new View.SplashScreen();
				splashWindow.Title = title;
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
			GC.SuppressFinalize(this);
			GC.WaitForPendingFinalizers();
		}

		public void SetSplashInitialized()
		{
			tcs.TrySetResult(true);
		}
	}
}
