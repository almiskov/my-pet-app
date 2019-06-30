﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace MoneySpending.Model.OneDay
{
	public class Expense : ICollection<Outgoing>
	{
		private List<Outgoing> _items;

		public event EventHandler SumChanged;

		private double _sum;
		public double Sum
		{
			get
			{
				_sum = 0;
				foreach (Outgoing otg in _items)
					_sum += otg.Price;
				return _sum;
			}
			set
			{
				_sum = value;
				OnSumChanged();
			}
		}

		public int Count => ((ICollection<Outgoing>)_items).Count;

		public bool IsReadOnly => ((ICollection<Outgoing>)_items).IsReadOnly;

		public Outgoing this[int index]
		{
			get { return _items[index]; }
			set { _items[index] = value; }
		}

		public Expense()
		{
			_items = new List<Outgoing>();
		}

		public void Add(Outgoing outgoing)
		{
			_items.Add(outgoing);
			OnSumChanged();
		}

		public void Remove(Outgoing outgoing)
		{
			_items.Remove(outgoing);
			OnSumChanged();
		}

		public void Update(Outgoing outgoing, double price, string name = null)
		{
			outgoing.Price = price;

			if (name != null)
				outgoing.Name = name;

			OnSumChanged();
		}

		protected virtual void OnSumChanged()
		{
			SumChanged?.Invoke(this, new EventArgs());
		}

		public IEnumerator<Outgoing> GetEnumerator()
		{
			return ((IEnumerable<Outgoing>)_items).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Outgoing>)_items).GetEnumerator();
		}

		public void Clear()
		{
			((ICollection<Outgoing>)_items).Clear();
		}

		public bool Contains(Outgoing item)
		{
			return ((ICollection<Outgoing>)_items).Contains(item);
		}

		public void CopyTo(Outgoing[] array, int arrayIndex)
		{
			((ICollection<Outgoing>)_items).CopyTo(array, arrayIndex);
		}

		bool ICollection<Outgoing>.Remove(Outgoing item)
		{
			return ((ICollection<Outgoing>)_items).Remove(item);
		}
	}
}
