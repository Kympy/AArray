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
			AddTitle("Add 0~19 int value");
			for(int i = 0; i < 12; i++)
			{
				testIntArray.Add(i);
				Console.WriteLine($"Index{(i)} / Value{(testIntArray[i])} / Size{(testIntArray.InternalSize)}");
			}
			AddTitle("Counting Int Array");
			Console.WriteLine($"Element Count : {testIntArray.Count}");
			AddTitle("Contains Function Test");
			string containResult = testIntArray.Contains(5) ? "Yes" : "No";
			Console.WriteLine($"Is Contain '5' ? => {containResult}");
		}
		private static void AddTitle(string title)
		{
			Console.WriteLine("");
			Console.WriteLine("___________________________________");
			Console.WriteLine($" {title}");
			Console.WriteLine("===================================");
			Console.WriteLine("");
		}
	}
}
