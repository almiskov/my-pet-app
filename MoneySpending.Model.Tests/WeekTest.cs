using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneySpending.Model.DayModel;
using MoneySpending.Model.MonthModel;
using System;

namespace MoneySpending.Model.Tests
{
	[TestClass]
	public class WeekTest
	{
		[TestMethod]
		public void PropertyChanged_Raises()
		{
			// arrange
			Week w = new Week(DateTime.Now, 4);

			bool isRaised = false;

			w.PropertyChanged += (s, e) => isRaised = true;

			// act
			w[0][0].Add(new Outgoing(200));

			// assert
			Assert.IsTrue(isRaised);
		}

		[TestMethod]
		public void Sum_Is_Correct()
		{
			// arrange
			Week w = new Week(DateTime.Now, 4);
			double expected = 700;

			// act
			w[1][0].Add(new Outgoing(200));
			w[5][3].Add(new Outgoing(300));
			w[3][2].Add(new Outgoing(200));

			double actual = w.Sum;
			// assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Week_Expenses_Is_Correct()
		{
			// arrange
			Week w = new Week(DateTime.Now, 4);

			double expected0 = 500;
			double expected1 = 1500;
			double expected2 = 0;
			double expected3 = 9000;

			// act
			w[0][0].Add(new Outgoing(100));
			w[1][0].Add(new Outgoing(300));
			w[2][0].Add(new Outgoing(100));

			w[0][1].Add(new Outgoing(500));
			w[5][1].Add(new Outgoing(900));
			w[3][1].Add(new Outgoing(100));

			w[4][3].Add(new Outgoing(1000));
			w[4][3].Add(new Outgoing(3500));
			w[1][3].Add(new Outgoing(1500));
			w[6][3].Add(new Outgoing(3000));

			double actual0 = w.Expenses[0];
			double actual1 = w.Expenses[1];
			double actual2 = w.Expenses[2];
			double actual3 = w.Expenses[3];

			// assert
			Assert.AreEqual(expected0, actual0);
			Assert.AreEqual(expected1, actual1);
			Assert.AreEqual(expected2, actual2);
			Assert.AreEqual(expected3, actual3);
		}

		[TestMethod]
		public void Day_Counts_Correctly()
		{
			// arrange
			Week w = new Week(DateTime.Now, 4);
			DateTime expected = DateTime.Now.AddDays(2).Date;

			// act
			DateTime actual = w[2].Today.Date;

			// assert
			Assert.AreEqual(expected, actual);
		}


	}
}
