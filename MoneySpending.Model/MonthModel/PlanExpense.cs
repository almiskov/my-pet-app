namespace MoneySpending.Model.MonthModel
{
	public class PlanExpense
	{
		public double Money { get; set; }
		public string Name { get; set; }

		public PlanExpense(double money, string name)
		{
			Money = money;
			Name = name;
		}
	}
}
