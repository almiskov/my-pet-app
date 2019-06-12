using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneySpending.Model.DayModel;

namespace MoneySpending.Model.Tests
{
	[TestClass]
	public class ExpenseTest
	{
		[TestMethod]
		public void Add_Raises_Property_Changed()
		{
			// arrange
			Expense ex = new Expense();
			bool isRaised = false;
			ex.PropertyChanged += (s, e) => isRaised = true;

			// act
			ex.Add(new Outgoing(200));

			// assert
			Assert.IsTrue(isRaised);
		}

		[TestMethod]
		public void Remove_Raises_Property_Changed()
		{
			// arrange
			Expense ex = new Expense();
			bool isRaised = false;
			Outgoing og = new Outgoing(200);
			ex.Add(og);
			ex.PropertyChanged += (s, e) => isRaised = true;

			// act
			ex.Remove(og);

			// assert
			Assert.IsTrue(isRaised);
		}

		[TestMethod]
		public void Update_Raises_Property_Changed()
		{
			// arrange
			Expense ex = new Expense();
			bool isRaised = false;
			Outgoing og = new Outgoing(200);
			ex.Add(og);
			ex.PropertyChanged += (s, e) => isRaised = true;

			// act
			ex.Update(og, 300);

			// assert
			Assert.IsTrue(isRaised);
		}

		[TestMethod]
		public void Sum_Is_Correct()
		{
			// arrange
			Expense ex = new Expense();
			Outgoing og1 = new Outgoing(200);
			Outgoing og2 = new Outgoing(300);

			double expected = 500;

			// act
			ex.Add(og1);
			ex.Add(og2);

			double actual = ex.Sum;

			// assert
			Assert.AreEqual(expected, actual);
		}

		[TestMethod]
		public void Update_Updates_Properties()
		{
			// arrange
			Expense ex = new Expense();
			Outgoing og = new Outgoing(200, "testText");

			double expectedPrice = 500;
			string expectedText = "newText";

			ex.Add(og);

			// act
			ex.Update(og, expectedPrice, expectedText);

			double actualPrice = og.Price;
			string actualText = og.Name;

			// assert
			Assert.AreEqual(expectedPrice, actualPrice);
			Assert.AreEqual(expectedText, actualText);
		}
	}
}
