using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace MoneySpending.Model.DayModel
{
	/// <summary>
	/// Статья расхода как сумма едиичных расходов Outgoing
	/// </summary>
	public class Expense : INotifyPropertyChanged, IEnumerable<Outgoing>
	{
		private double _sum;

		private List<Outgoing> _items;

		public event PropertyChangedEventHandler PropertyChanged;

		public double Sum
		{
			get
			{
				_sum = 0;
				foreach (Outgoing otg in _items)
					_sum += otg.Price;
				return _sum;
			}
		}

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
			OnPropertyChanged("Sum");
		}

		public void Remove(Outgoing outgoing)
		{
			_items.Remove(outgoing);
			OnPropertyChanged("Sum");
		}

		public void Update(Outgoing outgoing, double price, string name = null)
		{
			outgoing.Price = price;

			if (name != null)
				outgoing.Name = name;

			OnPropertyChanged("Sum");
		}

		private void OnPropertyChanged(string property)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
		}

		public IEnumerator<Outgoing> GetEnumerator()
		{
			return ((IEnumerable<Outgoing>)_items).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<Outgoing>)_items).GetEnumerator();
		}
	}
}
