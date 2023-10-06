using AmazingArray;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AArray
{
	internal class MainFunction
	{
		public static void Main()
		{
			Action currentAction = null;
			AArray<int> testIntArray = new AArray<int>();
			AddTitle("Create Int Array");
			PrintArray(testIntArray);
			Console.WriteLine($"Count : {testIntArray.Count}, Max Index : {testIntArray.MaxIndex}");

			AddTitle("Add one value 500");
			currentAction = () => { testIntArray.Add(500); };
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testIntArray);

			AddTitle("Add 0~19 int value...");
			currentAction = () =>
			{
				for (int i = 0; i < 12; i++)
				{
					testIntArray.Add(i);
				}
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testIntArray);

			AddTitle("Counting Int Array");
			Console.WriteLine($"Element Count : {testIntArray.Count}");

			AddTitle("Contains Function Test");
			currentAction = () =>
			{
				testIntArray.Contains(5);
			};
			RunAndCheckCollapsedTime(currentAction);
			string result = testIntArray.Contains(5) ? "Yes" : "No";
			Console.WriteLine($"Is Contain '5' ? => {result}");

			AddTitle("Insert 77 At Index 4 And Print Result");
			currentAction = () =>
			{
				testIntArray.InsertAtIndex(77, 4);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testIntArray);

			AddTitle("Insert List<int>(50, 51, 52) At Index 6");
			currentAction = () =>
			{
				testIntArray.AddRange(new List<int>() { 50, 51, 52 }, 6);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testIntArray);

			AddTitle("Find Element(50)'s Index");
			currentAction = () =>
			{
				testIntArray.IndexOf(50);
			};
			RunAndCheckCollapsedTime(currentAction);
			Console.Write($"Element 50's index is {testIntArray.IndexOf(50)}");

			AddTitle("Remove Element 50");
			currentAction = () =>
			{
				testIntArray.RemoveElement(50);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testIntArray);

			AddTitle("Remove Element Index 0");
			currentAction = () =>
			{
				testIntArray.RemoveAtIndex(0);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testIntArray);

			AddTitle("Add Unique Value 1 and 100. If value already exists, returned.");
			currentAction = () =>
			{
				testIntArray.AddUnique(1);
				testIntArray.AddUnique(100);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testIntArray);

			AddTitle("Shuffle Array");
			currentAction = () =>
			{
				testIntArray.Shuffle();
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testIntArray);

			AddTitle("Sort ASC");
			currentAction = () =>
			{
				testIntArray.SortASC((x) => x);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testIntArray);

			AddTitle("Shuffle Array");
			currentAction = () =>
			{
				testIntArray.Shuffle();
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testIntArray);

			AddTitle("Sort DESC");
			currentAction = () =>
			{
				testIntArray.SortDESC((x) => x);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testIntArray);

			AddTitle("Reverse");
			currentAction = () =>
			{
				testIntArray.Reverse();
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testIntArray);

			AddTitle("Finished");
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
		private static Stopwatch stopWatch = new Stopwatch();
		private static void RunAndCheckCollapsedTime(Action action)
		{
			stopWatch.Reset();
			stopWatch.Start();
			action?.Invoke();
			stopWatch.Stop();
			Console.WriteLine($"** Time : {stopWatch.ElapsedMilliseconds} (ms)");
			Console.WriteLine();
		}
	}
}
