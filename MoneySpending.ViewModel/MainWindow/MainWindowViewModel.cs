using System;
using System.ComponentModel;
using MoneySpending.Model.OneMonth;

namespace MoneySpending.ViewModel.MainWindow
{
	public class MainWindowViewModel : INotifyPropertyChanged
	{
		public Plan Plan { get; set; }
		public Month Month { get; set; }

		public MainWindowViewModel()
		{
			Plan = new Plan(
				new PlanExpense(30000, "Е+Тр"),
				new PlanExpense(20000, "Ск"),
				new PlanExpense(10000, "Мк"),
				new PlanExpense(10000, "Пр"));

			Month = new Month(DateTime.Now, Plan);

			Month[0][0][0].Add(new Model.OneDay.Outgoing(200));
			Month[0][0][2].Add(new Model.OneDay.Outgoing(200));
			Month[0][1][2].Add(new Model.OneDay.Outgoing(200));
			Month[0][1][2].Add(new Model.OneDay.Outgoing(300));
			Month[0][4][1].Add(new Model.OneDay.Outgoing(200));
		}

		public event PropertyChangedEventHandler PropertyChanged;

		private void OnPropertyChanged(string property)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}
	}
}
