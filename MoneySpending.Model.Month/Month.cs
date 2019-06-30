using System;

namespace MoneySpending.Model.OneMonth
{
	public class Month
	{
		public DateTime FirstDay { get; private set; }

		public Plan Plan { get; private set; }

		public Week[] Weeks;

		private double[][] _rests;
		public double[][] Rests
		{
			get
			{
				for(int i = 0; i < Weeks.Length; i++)
				{
					for(int j = 0; j < Plan.Length; j++)
					{
						if (i == 0)
							_rests[i][j] = Plan[j].Money - Weeks[i].Expenses[j];
						else
							_rests[i][j] = _rests[i - 1][j] - Weeks[i].Expenses[j];
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
				return Weeks[indexer];
			}
		}

		public event EventHandler RestsChanged;

		public Month(DateTime firstDay, Plan plan)
		{
			FirstDay = firstDay.Date;
			Plan = plan;

			Weeks = new Week[4];
			_rests = new double[Weeks.Length][];

			for (int i = 0; i < _rests.Length; i++)
			{
				for (int j = 0; j < Plan.Length; j++)
				{
					_rests[i] = new double[Plan.Length];
					_rests[i][j] = Plan[j].Money;
				}
			}

			for (int i = 0; i < Weeks.Length; i++)
			{
				Weeks[i] = new Week(firstDay + TimeSpan.FromDays(i * 7), plan.Length);
				Weeks[i].SumChanged += (s, e) => OnRestsChanged();
			}
		}

		private void OnRestsChanged()
		{
			RestsChanged?.Invoke(this, new EventArgs());
		}
	}
}
