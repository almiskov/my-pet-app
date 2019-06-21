using MoneySpending.Model.OneDay;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace MoneySpending.Model.OneMonth
{
	public class Week : IEnumerable<Day>
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

		public event EventHandler SumChanged;
		public event EventHandler ExpensesChanged;

		public Week() { }

		public Week(DateTime firstDay, int numberOfExpenses)
		{
			_expenses = new double[numberOfExpenses];
			_days = new Day[7];

			for (int i = 0; i < _days.Length; i++)
			{
				_days[i] = new Day(firstDay + TimeSpan.FromDays(i), numberOfExpenses);
				_days[i].SumChanged += (s, e) =>
				{
					OnSumChanged();
					OnExpensesChanged();
				};
			}
		}

		private void OnSumChanged()
		{
			SumChanged?.Invoke(this, new EventArgs());
		}

		private void OnExpensesChanged()
		{
			ExpensesChanged?.Invoke(this, new EventArgs());
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
