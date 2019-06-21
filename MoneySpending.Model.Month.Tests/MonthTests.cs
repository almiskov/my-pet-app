using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneySpending.Model.OneDay;
using System;

namespace MoneySpending.Model.OneMonth.Tests
{
	[TestClass]
	public class MonthTests
	{
		[TestMethod]
		public void Rests_Initializes_Correctly()
		{
			// arrange
			Plan plan = new Plan(
				new PlanExpense(10000, "Food"),
				new PlanExpense(40000, "Travelling"),
				new PlanExpense(30000, "Renting"));

			Month m = new Month(DateTime.Now, plan);

			// act

			// assert
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < m.Plan.Length; j++)
				{
					Assert.AreEqual(plan[j].Money, m.Rests[i][j]);
				}
			}
		}

		[TestMethod]
		public void Rests_Counted_Correctly()
		{
			// arrange
			Plan plan = new Plan(
				new PlanExpense(10000, "Food"),
				new PlanExpense(20000, "Travelling"),
				new PlanExpense(30000, "Renting"));

			Month m = new Month(DateTime.Now, plan);

			// fill first week
			m[0][5][0].Add(new Outgoing(500));
			m[0][3][0].Add(new Outgoing(500));
			m[0][1][1].Add(new Outgoing(200));
			m[0][4][2].Add(new Outgoing(200));

			double expected00 = 9000;
			double expected01 = 19800;
			double expected02 = 29800;

			// fill second week
			m[1][3][0].Add(new Outgoing(500));
			m[1][1][1].Add(new Outgoing(500));
			m[1][2][1].Add(new Outgoing(200));
			m[1][4][1].Add(new Outgoing(200));

			double expected10 = 8500;
			double expected11 = 18900;
			double expected12 = 29800;

			m[2][0][1].Add(new Outgoing(500));
			m[2][1][1].Add(new Outgoing(500));
			m[2][6][2].Add(new Outgoing(200));
			m[2][3][2].Add(new Outgoing(200));

			double expected20 = 8500;
			double expected21 = 17900;
			double expected22 = 29400;

			m[3][1][0].Add(new Outgoing(500));
			m[3][3][1].Add(new Outgoing(500));
			m[3][4][1].Add(new Outgoing(200));
			m[3][3][2].Add(new Outgoing(200));

			double expected30 = 8000;
			double expected31 = 17200;
			double expected32 = 29200;

			// act
			double actual00 = m.Rests[0][0];
			double actual01 = m.Rests[0][1];
			double actual02 = m.Rests[0][2];

			double actual10 = m.Rests[1][0];
			double actual11 = m.Rests[1][1];
			double actual12 = m.Rests[1][2];

			double actual20 = m.Rests[2][0];
			double actual21 = m.Rests[2][1];
			double actual22 = m.Rests[2][2];

			double actual30 = m.Rests[3][0];
			double actual31 = m.Rests[3][1];
			double actual32 = m.Rests[3][2];

			// assert
			Assert.AreEqual(expected00, actual00);
			Assert.AreEqual(expected01, actual01);
			Assert.AreEqual(expected02, actual02);

			Assert.AreEqual(expected10, actual10);
			Assert.AreEqual(expected11, actual11);
			Assert.AreEqual(expected12, actual12);

			Assert.AreEqual(expected20, actual20);
			Assert.AreEqual(expected21, actual21);
			Assert.AreEqual(expected22, actual22);

			Assert.AreEqual(expected30, actual30);
			Assert.AreEqual(expected31, actual31);
			Assert.AreEqual(expected32, actual32);
		}

		[TestMethod]
		public void PropertyChanged_Raises()
		{
			// arrange
			Plan plan = new Plan(
				new PlanExpense(10000, "Food"),
				new PlanExpense(40000, "Travelling"),
				new PlanExpense(30000, "Renting"));

			Month m = new Month(DateTime.Now, plan);

			bool isRaised = false;

			m.RestsChanged += (s, e) => isRaised = true;

			// act
			m[0][3][1].Add(new Outgoing(300));

			// assert
			Assert.IsTrue(isRaised);
		}
	}
}
