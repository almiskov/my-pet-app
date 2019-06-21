using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneySpending.Model.OneDay;
using MoneySpending.Model.OneMonth;
using System;
using System.IO;

namespace MoneySpending.Services.Tests
{
	[TestClass]
	public class MonthManipulationTests
	{
		public Month GetInitializedMonth()
		{
			var plan = new Plan(
				new PlanExpense(20000, "TestName1"),
				new PlanExpense(20000, "TestName2"),
				new PlanExpense(20000, "TestName3"));

			var m = new Month(DateTime.Now, plan);

			m[0][5][0].Add(new Outgoing(500));
			m[0][3][0].Add(new Outgoing(500));
			m[0][1][1].Add(new Outgoing(200));
			m[0][1][1].Add(new Outgoing(300, "Some thing"));
			m[0][4][2].Add(new Outgoing(200));

			m[1][3][0].Add(new Outgoing(500));
			m[1][1][1].Add(new Outgoing(500));
			m[1][2][1].Add(new Outgoing(200));
			m[1][4][1].Add(new Outgoing(200));

			m[2][0][1].Add(new Outgoing(500));
			m[2][1][1].Add(new Outgoing(500));
			m[2][6][2].Add(new Outgoing(200));
			m[2][3][2].Add(new Outgoing(200));

			m[3][1][0].Add(new Outgoing(500));
			m[3][3][1].Add(new Outgoing(500));
			m[3][4][1].Add(new Outgoing(200));
			m[3][3][2].Add(new Outgoing(200));

			return m;
		} 

		[TestMethod]
		public void SaveToDisk_Creates_A_Month_File()
		{
			var month = GetInitializedMonth();
			MonthManipulation.SaveToDisk(month);

			var fileNames = Directory.GetFiles(MonthManipulation._basePathToSave);

			Assert.IsTrue(fileNames.Length > 0);

			DeleteDirectoryAndFiles();
		}

		[TestMethod]
		public void LoadFromDisk_Gets_Correct_Month()
		{
			var month = GetInitializedMonth();
			MonthManipulation.SaveToDisk(month);

			var expected0 = month[0][5][0];
			var expected1 = month[2][0][1];
			var expected2 = month[3][3][2];
			var expected3 = month[0][0][0];
			var expected4 = month[0].Sum;

			var deserializedMonth = MonthManipulation.LoadFromDisk(month.FirstDay);

			var actual0 = month[0][5][0];
			var actual1 = month[2][0][1];
			var actual2 = month[3][3][2];
			var actual3 = month[0][0][0];
			var actual4 = month[0].Sum;

			Assert.AreEqual(expected0, actual0);
			Assert.AreEqual(expected1, actual1);
			Assert.AreEqual(expected2, actual2);
			Assert.AreEqual(expected3, actual3);
			Assert.AreEqual(expected4, actual4);

			DeleteDirectoryAndFiles();
		}

		private void DeleteDirectoryAndFiles()
		{
			var fileNames = Directory.GetFiles(MonthManipulation._basePathToSave);

			foreach (var filename in fileNames)
				File.Delete(filename);

			Directory.Delete(MonthManipulation._basePathToSave);
		}
	}
}
