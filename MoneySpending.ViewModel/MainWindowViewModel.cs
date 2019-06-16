using System;
using MoneySpending.Model.DayModel;
using MoneySpending.Model.MonthModel;

namespace MoneySpending.ViewModel
{
	public class MainWindowViewModel
	{
		public Plan plan;
		public Month month;
		
		public MainWindowViewModel()
		{
			plan = new Plan(
				new PlanExpense(10000, "Е+Тр"),
				new PlanExpense(10000, "Ск"),
				new PlanExpense(10000, "Мк"),
				new PlanExpense(10000, "Пр"));

			month = new Month(DateTime.Now, plan);
		}
	}
}
