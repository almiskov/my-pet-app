using System;
using System.ComponentModel;

namespace MoneySpending.Model.MonthModel
{
	public class Month : INotifyPropertyChanged
	{
		public Plan Plan { get; private set; }

		private Week[] _weeks;

		private double[][] _rests;
		public double[][] Rests
		{
			get
			{
				/// TODO: implement this strange thing
				/// it won't work like this

				int i;

				foreach (PlanExpense planExpense in Plan)
				{
					i = 0;

					for(int j = 0; j < Plan.Length; j++)
					{
						_rests[i][j] = planExpense.Money - _weeks[i].Expenses[j];
					}
					i++;
				}

				return _rests;
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;

		public Month(DateTime firstDay, Plan plan)
		{
			Plan = plan;

			_weeks = new Week[4];
			_rests = new double[_weeks.Length][];

			for (int i = 0; i < _weeks.Length; i++)
			{
				_weeks[i] = new Week(firstDay + TimeSpan.FromDays(i * 7), plan.Length);
				_weeks[i].PropertyChanged += (s, e) =>
				{
					if (e.PropertyName == "Sum")
					{
						OnPropertyChanged("");
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
