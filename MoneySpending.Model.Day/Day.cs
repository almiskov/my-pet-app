﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace MoneySpending.Model.OneDay
{
	public class Day : ICollection<Expense>
	{
		private Expense[] _expences;
		
		/// <summary>
		/// Number of expences at this day
		/// </summary>
		public int Length => _expences.Length;

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

		/// <summary>
		/// Indexer must be less than count of expenses
		/// </summary>
		/// <param name="indexer"></param>
		/// <returns></returns>
		public Expense this [int indexer]
		{
			get { return _expences[indexer]; }
			set { _expences[indexer] = value; }
		}

		public DateTime Today { get; private set; }

		public int Count => ((ICollection<Expense>)_expences).Count;

		public bool IsReadOnly => ((ICollection<Expense>)_expences).IsReadOnly;

		public event EventHandler SumChanged;

		public Day() { }

		public Day(DateTime day, int numberOfExpenses)
		{
			Today = day;
			_expences = new Expense[numberOfExpenses];

			for (int i = 0; i < numberOfExpenses; i++)
			{
				_expences[i] = new Expense();
				_expences[i].SumChanged += (s, e) => OnSumChanged();
			}
		}

		private void OnSumChanged()
		{
			SumChanged?.Invoke(this, new EventArgs());
		}

		public IEnumerator<Expense> GetEnumerator()
		{
			return ((IEnumerable<Expense>)_expences).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Expense>)_expences).GetEnumerator();
		}

		public void Add(Expense item)
		{
			((ICollection<Expense>)_expences).Add(item);
		}

		public void Clear()
		{
			((ICollection<Expense>)_expences).Clear();
		}

		public bool Contains(Expense item)
		{
			return ((ICollection<Expense>)_expences).Contains(item);
		}

		public void CopyTo(Expense[] array, int arrayIndex)
		{
			((ICollection<Expense>)_expences).CopyTo(array, arrayIndex);
		}

		public bool Remove(Expense item)
		{
			return ((ICollection<Expense>)_expences).Remove(item);
		}
	}
}
