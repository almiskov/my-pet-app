using System;
using MoneySpending.Model.OneMonth;
using Newtonsoft.Json;
using System.IO;

namespace MoneySpending.Services
{
	public class MonthManipulation
	{
		internal static readonly string _basePathToSave = @"data\";

		public static Month CreateNewMonth(DateTime firstDay, Plan plan)
		{
			return new Month(firstDay, plan);
		}

		public static void SaveToDisk(Month month)
		{
			if (!Directory.Exists(_basePathToSave))
				Directory.CreateDirectory(_basePathToSave);

			string fullPath = CreateFullJsonPathFromDateTime(month.FirstDay);

			string serializedData = JsonConvert.SerializeObject(month);

			using (var writer = new StreamWriter(fullPath, false))
			{
				writer.Write(serializedData);
			}
		}

		public static Month LoadFromDisk(DateTime firstDay)
		{
			/// TODO: implement this method

			string fullPath = CreateFullJsonPathFromDateTime(firstDay);

			using (var reader = new StreamReader(fullPath))
			{
				string deserializedData = reader.ReadToEnd();

				var settings = new JsonSerializerSettings();

				var month = JsonConvert.DeserializeObject<Month>(deserializedData, settings);

				return month;
			}
		}

		private static string CreateFullJsonPathFromDateTime(DateTime date)
		{
			string fileName =
				date.Year.ToString() +
				date.Month.ToString() +
				date.Day.ToString() +
				".json";

			return _basePathToSave + fileName;
		}
	}
}
