using System;
using System.ComponentModel;
using MoneySpending.Model.DayModel;

namespace MoneySpending.Model.MonthModel
{
	public class Week : INotifyPropertyChanged
	{
		private Day[] _days;

		private double _sum;
		public double Sum
		{
			get
			{
				_sum = 0;
				foreach (Day day in _days)
					_sum += day.Sum;
				return _sum;
			}
		}

		private double[] _expenses;
		public double[] Expenses
		{
			get
			{
				int i;

				foreach(Day day in _days)
				{
					i = 0;

					foreach(Expense dayExpense in day)
					{
						_expenses[i++] += dayExpense.Sum;
					}
				}

				return _expenses;
			}
			private set
			{
				_expenses = value;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public Week(DateTime firstDay, byte numberOfExpenses)
		{
			_expenses = new double[numberOfExpenses];

			_days = new Day[7];

			for(int i = 0; i < _days.Length; i++)
			{
				_days[i] = new Day(firstDay + TimeSpan.FromDays(i), numberOfExpenses);
				_days[i].PropertyChanged += (s, e) =>
				{
					OnPropertyChanged("Sum");
					OnPropertyChanged("Expenses");
				};
			}
		}

		private void OnPropertyChanged(string property)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}
	}
}
