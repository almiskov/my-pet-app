using System.Collections;
using System.Collections.Generic;

namespace MoneySpending.Model.OneMonth
{
	public class Plan : ICollection<PlanExpense>
	{
		public double Total { get; }

		public int Length => _expenses.Length;

		public int Count => ((ICollection<PlanExpense>)_expenses).Count;

		public bool IsReadOnly => ((ICollection<PlanExpense>)_expenses).IsReadOnly;

		private PlanExpense[] _expenses = new PlanExpense[0];

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

		public void Add(PlanExpense item)
		{
			((ICollection<PlanExpense>)_expenses).Add(item);
		}

		public void Clear()
		{
			((ICollection<PlanExpense>)_expenses).Clear();
		}

		public bool Contains(PlanExpense item)
		{
			return ((ICollection<PlanExpense>)_expenses).Contains(item);
		}

		public void CopyTo(PlanExpense[] array, int arrayIndex)
		{
			((ICollection<PlanExpense>)_expenses).CopyTo(array, arrayIndex);
		}

		public bool Remove(PlanExpense item)
		{
			return ((ICollection<PlanExpense>)_expenses).Remove(item);
		}
	}
}
