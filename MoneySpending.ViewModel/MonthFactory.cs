using System;
using MoneySpending.Model.DayModel;
using MoneySpending.Model.MonthModel;

namespace MoneySpending.ViewModel
{
	public class MonthFactory
	{
		public Month CreateNewMonth(DateTime firstDay, Plan plan)
		{
			return new Month(firstDay, plan);
		}

		public Month GetExistingMonth(DateTime firstDay)
		{

		}
	}
}
