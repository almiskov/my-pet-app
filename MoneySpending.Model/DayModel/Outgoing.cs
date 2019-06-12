namespace MoneySpending.Model.DayModel
{
	/// <summary>
	/// Одна-единственная маленькая трата
	/// </summary>
	public class Outgoing
	{
		public double Price { get; set; }
		public string Name { get; set; }

		public Outgoing(double price, string name = null)
		{
			Price = price;
			Name = name;
		}
	}
}
