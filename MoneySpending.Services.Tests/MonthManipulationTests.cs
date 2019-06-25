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
		private Month _month;

		[TestInitialize]
		public void InitializeTest()
		{
			_month = new MonthManipulationTestsInit()
				.InitializeMonth();
		}

		[TestCleanup]
		public void CleanupTest()
		{
			var fileNames = Directory.GetFiles(MonthManipulation._folderPath);

			foreach (var filename in fileNames)
				File.Delete(filename);

			Directory.Delete(MonthManipulation._folderPath);
		}

		[TestMethod]
		public void SaveToDisk_Creates_A_Month_File()
		{
			MonthManipulation.SaveToDisk(_month);

			var fileNames = Directory.GetFiles(MonthManipulation._folderPath);

			Assert.IsTrue(fileNames.Length > 0);
		}

		[TestMethod]
		public void LoadFromDisk_Gets_Correct_Month()
		{
			MonthManipulation.SaveToDisk(_month);

			var expected0 = _month[0][5][0];
			var expected1 = _month[2][0][1];
			var expected2 = _month[3][3][2];
			var expected3 = _month[0][0][0];
			var expected4 = _month[0].Sum;

			var deserializedMonth = MonthManipulation.LoadFromDisk(_month.FirstDay);

			var actual0 = _month[0][5][0];
			var actual1 = _month[2][0][1];
			var actual2 = _month[3][3][2];
			var actual3 = _month[0][0][0];
			var actual4 = _month[0].Sum;

			Assert.AreEqual(expected0, actual0);
			Assert.AreEqual(expected1, actual1);
			Assert.AreEqual(expected2, actual2);
			Assert.AreEqual(expected3, actual3);
			Assert.AreEqual(expected4, actual4);

		}
	}
}
