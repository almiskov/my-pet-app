using System;
using System.ComponentModel;

namespace MoneySpending.Model.MonthModel
{
	public class Month : INotifyPropertyChanged
	{
		public DateTime FirstDay { get; private set; }

		public Plan Plan { get; private set; }

		private Week[] _weeks;

		private double[][] _rests;
		public double[][] Rests
		{
			get
			{
				for(int i = 0; i < _weeks.Length; i++)
				{
					for(int j = 0; j < Plan.Length; j++)
					{
						if (i == 0)
							_rests[i][j] = Plan[j].Money - _weeks[i].Expenses[j];
						else
							_rests[i][j] = _rests[i - 1][j] - _weeks[i].Expenses[j];
					}
				}

				return _rests;
			}
		}

		/// <summary>
		/// Number of the week in month. Indexer must be from 0 to 3
		/// </summary>
		/// <param name="indexer"></param>
		/// <returns>The week</returns>
		public Week this [int indexer]
		{
			get
			{
				if (indexer > 3)
					indexer = 3;
				return _weeks[indexer];
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public Month(DateTime firstDay, Plan plan)
		{
			FirstDay = firstDay.Date;
			Plan = plan;

			_weeks = new Week[4];
			_rests = new double[_weeks.Length][];

			for (int i = 0; i < _rests.Length; i++)
			{
				for (int j = 0; j < Plan.Length; j++)
				{
					_rests[i] = new double[Plan.Length];
					_rests[i][j] = Plan[j].Money;
				}
			}

			for (int i = 0; i < _weeks.Length; i++)
			{
				_weeks[i] = new Week(firstDay + TimeSpan.FromDays(i * 7), plan.Length);
				_weeks[i].PropertyChanged += (s, e) =>
				{
					if (e.PropertyName == "Sum")
					{
						OnPropertyChanged("Rests");
					}
				};
			}
		}

		private void OnPropertyChanged(string property)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}
	}
}
