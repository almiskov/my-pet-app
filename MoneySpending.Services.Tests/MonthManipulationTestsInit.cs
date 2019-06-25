using System;
using MoneySpending.Model.OneDay;
using MoneySpending.Model.OneMonth;

namespace MoneySpending.Services.Tests
{
	public class MonthManipulationTestsInit
	{
		public Month InitializeMonth()
		{
			var plan = new Plan(
				new PlanExpense(20000, "TestName1"),
				new PlanExpense(20000, "TestName2"),
				new PlanExpense(20000, "TestName3"));

			var month = new Month(DateTime.Now, plan);

			month[0][5][0].Add(new Outgoing(500));
			month[0][3][0].Add(new Outgoing(500));
			month[0][1][1].Add(new Outgoing(200));
			month[0][1][1].Add(new Outgoing(300, "Some thing"));
			month[0][4][2].Add(new Outgoing(200));

			month[1][3][0].Add(new Outgoing(500));
			month[1][1][1].Add(new Outgoing(500));
			month[1][2][1].Add(new Outgoing(200));
			month[1][4][1].Add(new Outgoing(200));

			month[2][0][1].Add(new Outgoing(500));
			month[2][1][1].Add(new Outgoing(500));
			month[2][6][2].Add(new Outgoing(200));
			month[2][3][2].Add(new Outgoing(200));

			month[3][1][0].Add(new Outgoing(500));
			month[3][3][1].Add(new Outgoing(500));
			month[3][4][1].Add(new Outgoing(200));
			month[3][3][2].Add(new Outgoing(200));

			return month;
		}
	}
}
