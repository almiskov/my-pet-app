using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using MoneySpending.Model.DayModel;

namespace MoneySpending.Model.MonthModel
{
	public class Week : INotifyPropertyChanged, IEnumerable<Day>
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

		// расходы по каждой статье за неделю 
		private double[] _expenses;
		public double[] Expenses
		{
			get
			{
				for (int i = 0; i < _expenses.Length; i++)
				{
					_expenses[i] = 0;
				}

				for (int i = 0; i < _days.Length; i++)
				{
					for (int j = 0; j < _expenses.Length; j++)
					{
						_expenses[j] += _days[i][j].Sum;
					}
				}

				return _expenses;
			}
			private set
			{
				_expenses = value;
			}
		}

		/// <summary>
		/// Number of the day in week. Indexer must be from 0 to 6
		/// </summary>
		/// <param name="indexer"></param>
		/// <returns></returns>
		public Day this [int indexer]
		{
			get
			{
				if (indexer > 6)
					indexer = 6;
				return _days[indexer];
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public Week(DateTime firstDay, int numberOfExpenses)
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

		public IEnumerator<Day> GetEnumerator()
		{
			return ((IEnumerable<Day>)_days).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Day>)_days).GetEnumerator();
		}
	}
}
