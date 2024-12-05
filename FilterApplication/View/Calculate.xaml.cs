using Application.Extensions;
using Application.Interfaces.ViewModels;
using Application.Interfaces.Views;
using Models.Enums.View;
using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace FilterApplication.View
{
	/// <summary>
	/// Страница "Расчеты". Описывается основная логика взаимодействия
	/// </summary>
	public partial class Calculate : ICalculateView
	{
		private ICalculateViewModel _viewModel;
		private DispatcherTimer _timer;
		private CalculateStage _stage = CalculateStage.None;
		private int counter;
		public Representation View => Representation.Calculate;
		public Calculate()
		{
			InitializeComponent();
		}
		public void SetViewModel(ICalculateViewModel viewModel)
		{
			_viewModel = viewModel;
			DataContext = _viewModel;
			_timer = new();
			LoadText.Text = _stage.GetDescription();
		}
		private void Handle(object sender, RoutedEventArgs e)
		{
			if (StartButtonCalculate.IsChecked == false)
			{
				TimerStop();
				return;
			}
			TimerStart();
		}
		private void TimerStart()
		{
			if (counter > 0)
			{
				ResetCounter();
			}
			TimerLabel.Foreground = new SolidColorBrush(Colors.Yellow);
			GridLoad.Visibility = Visibility.Visible;
			HeaderCalculate.Visibility = Visibility.Collapsed;

			_timer.Interval = TimeSpan.FromMilliseconds(25);
			_timer.Tick += ManageCalc;
			_timer.Start();
		}
		private void TimerStop()
		{
			_timer.Stop();
			GridLoad.Visibility = Visibility.Collapsed;
			HeaderCalculate.Visibility = Visibility.Visible;
		}
		private void ManageCalc(object sender, EventArgs e)
		{
			counter++;
			TimerLabel.Text = (counter != 0) ? counter.ToString() : "";

			switch (counter)
			{
				case (1):
					UpdateStage(CalculateStage.Loading);
					break;
				case (30):
					UpdateStage(CalculateStage.Processing);
					break;
				case (80):
					if (!_viewModel.IsValidInputData)
					{
						TimerLabel.Text = "Err";
						TimerLabel.Foreground = new SolidColorBrush(Colors.LightCoral);
						UpdateStage(CalculateStage.None);
						_timer.Stop();
						StartButtonCalculate.IsChecked = false;
						return;
					}
					UpdateStage(CalculateStage.Calculating);
					_viewModel.CalculateCommand.Execute(this);
					break;

				case (99):
					UpdateStage(CalculateStage.None);
					TimerLabel.Text = CalculateStage.Done.GetDescription();
					StartButtonCalculate.IsChecked = false;
					TimerLabel.Foreground = new SolidColorBrush(Colors.GreenYellow);
					LoadText.Text = String.Empty;
					_timer.Stop();
					break;
			}
		}
		private void UpdateStage(CalculateStage stage)
		{
			_stage = stage;
			LoadText.Text = _stage.GetDescription();
		}
		private void ResetCounter()
		{
			_timer.Tick -= ManageCalc;
			counter = 0;
		}
	}
}