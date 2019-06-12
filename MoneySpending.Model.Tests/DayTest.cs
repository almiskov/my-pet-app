using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneySpending.Model.DayModel;
using System;

namespace MoneySpending.Model.Tests
{
	[TestClass]
	public class DayTest
	{
		[TestMethod]
		public void Sum_Is_Correct()
		{
			// arrange
			Day d = new Day(DateTime.Now, 3);

			d[0].Add(new Outgoing(200));
			d[1].Add(new Outgoing(200));
			d[2].Add(new Outgoing(300));
			d[1].Add(new Outgoing(300));

			double expected = 1000;
			// act
			double actual = d.Sum;

			// assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void PropertyChanged_Raises_When_Outgoing_Added()
		{
			// arrange
			Day d = new Day(DateTime.Now, 3);

			bool isRaised = false;
			d.PropertyChanged += (s, e) => isRaised = true;

			// act
			d[0].Add(new Outgoing(200));

			// assert
			Assert.IsTrue(isRaised);
		}

		[TestMethod]
		public void Length_Is_Correct()
		{
			// arrange
			Day d = new Day(DateTime.Now, 5);

			int expected = 5;

			// act
			int actual = d.Length;

			// assert
			Assert.AreEqual(expected, actual);
		}
	}
}
