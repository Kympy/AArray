using AmazingArray;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AArray
{
	internal class MainFunction
	{
		public static void Main()
		{
			AddTitle("Create Int Array");
			AArray<int> testIntArray = new AArray<int>();
			PrintArray(testIntArray);
			Console.WriteLine($"Count : {testIntArray.Count}, Max Index : {testIntArray.MaxIndex}");

			AddTitle("Add 0~19 int value...");
			for(int i = 0; i < 12; i++)
			{
				testIntArray.Add(i);
			}
			PrintArray(testIntArray);

			AddTitle("Counting Int Array");
			Console.WriteLine($"Element Count : {testIntArray.Count}");

			AddTitle("Contains Function Test");
			string containResult = testIntArray.Contains(5) ? "Yes" : "No";
			Console.WriteLine($"Is Contain '5' ? => {containResult}");

			AddTitle("Insert 77 At Index 4 And Print Result");
			testIntArray.InsertAtIndex(77, 4);
			PrintArray(testIntArray);

			AddTitle("Insert List<int>(50, 51, 52) At Index 6");
			testIntArray.AddRange(new List<int>() { 50, 51, 52 }, 6);
			PrintArray(testIntArray);

			
		}
		private static void AddTitle(string title)
		{
			Console.WriteLine("");
			Console.WriteLine("___________________________________");
			Console.WriteLine($" {title}");
			Console.WriteLine("===================================");
			Console.WriteLine("");
		}
		private static void PrintArray<T>(AArray<T> target)
		{
			foreach (var element in target)
			{
				Console.Write($"{element},");
			}
			Console.WriteLine();
		}
	}
}
