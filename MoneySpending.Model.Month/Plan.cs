using System.Collections;
using System.Collections.Generic;

namespace MoneySpending.Model.OneMonth
{
	public class Plan : IEnumerable<PlanExpense>
	{
		public double Total { get; }

		public int Length => _expenses.Length;

		private PlanExpense[] _expenses;

		public PlanExpense this [int indexer]
		{
			get { return _expenses[indexer]; }
		}

		public Plan() { }

		public Plan(params PlanExpense[] expenses)
		{
			_expenses = expenses;

			foreach (PlanExpense planExpense in _expenses)
				Total += planExpense.Money;
		}

		public IEnumerator<PlanExpense> GetEnumerator()
		{
			return ((IEnumerable<PlanExpense>)_expenses).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<PlanExpense>)_expenses).GetEnumerator();
		}
	}
}
