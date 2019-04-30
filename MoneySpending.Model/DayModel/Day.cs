using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace MoneySpending.Model.DayModel
{
	public class Day : INotifyPropertyChanged, IEnumerable<Expense>
	{
		private Expense[] _expences;

		private double _sum;
		public double Sum
		{
			get
			{
				_sum = 0;
				foreach (Expense exp in _expences)
					_sum += exp.Sum;
				return _sum;
			}
		}

		public DateTime Today { get; private set; }

		public event PropertyChangedEventHandler PropertyChanged;

		public Day() { }

		public Day(DateTime day, int numberOfExpenses)
		{
			Today = day;
			_expences = new Expense[numberOfExpenses];

			for (int i = 0; i < numberOfExpenses; i++)
			{
				_expences[i] = new Expense();
				_expences[i].PropertyChanged += (s, e) => OnPropertyChanged("Sum");
			}
		}

		private void OnPropertyChanged(string property)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}

		public IEnumerator<Expense> GetEnumerator()
		{
			return ((IEnumerable<Expense>)_expences).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Expense>)_expences).GetEnumerator();
		}
	}
}
