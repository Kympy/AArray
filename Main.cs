using AmazingArray;
using System.Diagnostics;

namespace AArray
{
	internal class MainFunction
	{
		public class TestClass
		{
			public string? name;
			public int age;

			public TestClass()
			{
				Random rand = new Random();

				this.name = $"{(char)rand.Next(65, 91)}";
				this.age = rand.Next(1, 100);
			}
			public TestClass(string? name, int age)
			{
				this.name = name;
				this.age = age;
			}
		}
		public static void Main()
		{
			TestStructType();
			AddTitle("");
			TestClassType();
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
				if (typeof(T) == typeof(TestClass))
				{
					Console.WriteLine($"{ (element as TestClass).name} / {(element as TestClass).age} ");
					continue;
				}
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
		private static void TestStructType()
		{
			Action currentAction = null;
			// Struct Array
			AArray<int> testArray = new AArray<int>();
			AddTitle("Create Int Array");
			PrintArray(testArray);

			Console.WriteLine($"Count : {testArray.Count}, Max Index : {testArray.MaxIndex}");

			// Struct
			AddTitle("Add one value 500");
			currentAction = () => { testArray.Add(500); };
			
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Add 0~19 int value...");
			currentAction = () =>
			{
				for (int i = 0; i< 12; i++)
				{
					testArray.Add(i);
				}
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Counting Int Array");
			Console.WriteLine($"Element Count : {testArray.Count}");

			AddTitle("Contains Function Test");
			currentAction = () =>
			{
				testArray.Contains(5);
			};
			RunAndCheckCollapsedTime(currentAction);
			string result = testArray.Contains(5) ? "Yes" : "No";
			Console.WriteLine($"Is Contain '5' ? => {result}");

			AddTitle("Insert 77 At Index 4 And Print Result");
			currentAction = () =>
			{
				testArray.InsertAtIndex(77, 4);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Insert List<int>(50, 51, 52) At Index 6");
			currentAction = () =>
			{
				testArray.AddRange(new List<int>() { 50, 51, 52 }, 6);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Find Element(50)'s Index");
			currentAction = () =>
			{
				testArray.FindIndex(50);
			};
			RunAndCheckCollapsedTime(currentAction);
			Console.Write($"Element 50's index is {testArray.FindIndex(50)}");

			AddTitle("Remove Element 50");
			currentAction = () =>
			{
				testArray.RemoveElement(50);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Remove Element Index 0");
			currentAction = () =>
			{
				testArray.RemoveAtIndex(0);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Add Unique Value 1 and 100. If value already exists, returned.");
			currentAction = () =>
			{
				testArray.AddUnique(1);
				testArray.AddUnique(100);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Shuffle Array");
			currentAction = () =>
			{
				testArray.Shuffle();
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Sort ASC");
			currentAction = () =>
			{
				testArray.SortASC((x) => x);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Shuffle Array");
			currentAction = () =>
			{
				testArray.Shuffle();
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Sort DESC");
			currentAction = () =>
			{
				testArray.SortDESC((x) => x);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Reverse");
			currentAction = () =>
			{
				testArray.Reverse();
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Push Right");
			currentAction = () =>
			{
				testArray.PushRight();
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Push Left");
			currentAction = () =>
			{
				testArray.PushLeft();
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Clear All");
			currentAction = () =>
			{
				testArray.Clear();
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Finished");
		}
		private static void TestClassType()
		{
			Action currentAction = null;

			// Class Array
			AArray<TestClass> testArray = new AArray<TestClass>();
			AddTitle("Create TestClass Array");
			PrintArray(testArray);

			Console.WriteLine($"Count : {testArray.Count}, Max Index : {testArray.MaxIndex}");

			// Class
			AddTitle("Add one value class 'FirstClass'");
			TestClass firstClass = new TestClass("First", 99);
			currentAction = () => { testArray.Add(firstClass); };
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Add 0~19 random classes...");
			currentAction = () =>
			{
				// class
				for (int i = 0; i < 12; i++)
				{
					testArray.Add(new TestClass());
				}
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Counting Array");
			Console.WriteLine($"Element Count : {testArray.Count}");

			AddTitle("Contains Function Test");
			currentAction = () =>
			{
				//testArray.Contains(5);
				testArray.Contains(firstClass);
			};
			RunAndCheckCollapsedTime(currentAction);
			//string result = testArray.Contains(5) ? "Yes" : "No";
			string result = testArray.Contains(firstClass) ? "Yes" : "No";
			Console.WriteLine($"Is Contain 'firstClass' ? => {result}");

			AddTitle("Insert 'insertedClass' At Index 4 And Print Result");
			currentAction = () =>
			{
				TestClass inserted = new TestClass("Inserted", 88);
				testArray.InsertAtIndex(inserted, 4);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Insert List<TestClass>(list1, list2, list3) At Index 6");
			TestClass listClass1 = new TestClass("List1", 77);
			currentAction = () =>
			{
				TestClass listClass2 = new TestClass("List2", 77);
				TestClass listClass3 = new TestClass("List3", 77);
				testArray.AddRange(new List<TestClass>() { listClass1, listClass2, listClass3 }, 6);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Find Element(List1)'s Index");
			currentAction = () =>
			{
				testArray.FindIndex(listClass1);
			};
			RunAndCheckCollapsedTime(currentAction);
			Console.Write($"Element 50's index is {testArray.FindIndex(listClass1)}");

			AddTitle("Find First Class by predicate. age > 50");
			TestClass resultClass = null;
			currentAction = () =>
			{
				resultClass = testArray.FindFirst((x) => x.age > 50);
			};
			RunAndCheckCollapsedTime(currentAction);
			Console.WriteLine($"Result : {resultClass?.name}");

			AddTitle("Find All Classes by predicate. age > 50");
			TestClass[] resultClasses = null;
			currentAction = () =>
			{
				resultClasses = testArray.FindAll((x) => x.age > 50);
			};
			RunAndCheckCollapsedTime(currentAction);
			foreach(var item in resultClasses)
			{
				Console.WriteLine($" {item.name} / {item.age}");
			}

			AddTitle("Remove Element list1");
			currentAction = () =>
			{
				testArray.RemoveElement(listClass1);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Remove Element Index 1");
			currentAction = () =>
			{
				testArray.RemoveAtIndex(1);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Add Unique Value 'FirstClass'. If value already exists, returned.");
			currentAction = () =>
			{
				testArray.AddUnique(firstClass);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Shuffle Array");
			currentAction = () =>
			{
				testArray.Shuffle();
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Sort ASC by age");
			currentAction = () =>
			{
				testArray.SortASC((x) => x.age);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Shuffle Array");
			currentAction = () =>
			{
				testArray.Shuffle();
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Sort DESC by age");
			currentAction = () =>
			{
				testArray.SortDESC((x) => x.age);
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Reverse");
			currentAction = () =>
			{
				testArray.Reverse();
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Clear All");
			currentAction = () =>
			{
				testArray.Clear();
			};
			RunAndCheckCollapsedTime(currentAction);
			PrintArray(testArray);

			AddTitle("Finished");
		}
	}
}
