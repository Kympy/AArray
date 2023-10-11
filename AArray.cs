using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AmazingArray
{
	public class AArray<T> : IEnumerable<T>
	{
		private T[]? internalArray;
		public int Count
		{
			get 
			{
				if (internalArray == null) throw new NullReferenceException();
				return internalArray.Length; 
			}
		}
		public int MaxIndex
		{
			get 
			{
				if (internalArray == null) throw new NullReferenceException();
				if (internalArray.Length - 1 < 0) return 0;
				return internalArray.Length - 1; 
			}
		}
		public AArray()
		{
			// Default size is 0.
			internalArray = Array.Empty<T>();
		}
		/// <summary>
		/// Make new AArray that copied value from original array.
		/// </summary>
		/// <param name="originArray">Original array you want to copy</param>
		public AArray(T[] originArray)
		{
			CopyFullArray(originArray);
		}
		// Make [] property.
		public T this[int index]
		{
			get
			{
				if (internalArray == null || index > MaxIndex)
				{
					throw new IndexOutOfRangeException();
				}
				return internalArray[index];
			}
			set
			{
				if (internalArray == null || index > MaxIndex)
				{
					throw new IndexOutOfRangeException();
				}
				internalArray[index] = value;
			}
		}
		public virtual void CopyFullArray(T[] originArray)
		{
			if (originArray == null || internalArray == null) throw new NullReferenceException();

			if (originArray.Length != internalArray.Length)
			{
				internalArray = new T[originArray.Length];
			}
			int index = 0;
			foreach (var element in originArray)
			{
				internalArray[index] = element;
				index++;
			}
		}
		public static void CopyFullArray(T[] from, T[] to)
		{
			if (from == null || to == null)
			{
				throw new NullReferenceException();
			}
			for(int i = 0; i < from.Length; i++)
			{
				if (i >= to.Length)
				{
					break;
				}
				to[i] = from[i];
			}
		}
		public virtual void Add(T item)
		{
			if (internalArray == null)
			{
				throw new NullReferenceException();
			}
			IncreaseSize(1);
			internalArray[MaxIndex] = item;
		}
		protected virtual void IncreaseSize(int amount)
		{
			if (internalArray == null)
			{
				throw new NullReferenceException();
			}
			//if (internalArray.Length == 1) return;
			// Increase size 1.
			T[] tempArray = new T[Count + amount];
			CopyFullArray(internalArray, tempArray);
			internalArray = tempArray;
		}
		/// <summary>
		/// Add item to AArray where item is not contained in internal array.
		/// </summary>
		/// <param name="item"></param>
		public virtual void AddUnique(T item)
		{
			if (internalArray == null)
			{
				throw new NullReferenceException();
			}
			if (Contains(item) == true)
			{
				return;
			}
			IncreaseSize(1);
			internalArray[MaxIndex] = item;
        }
		public bool Contains(T item)
		{
			if (internalArray == null) throw new NullReferenceException();
            if (item == null) throw new ArgumentNullException();

			return Array.IndexOf<T>(internalArray, item) != -1;
        }
		public int FindIndex(T item)
		{
			if (internalArray == null) throw new NullReferenceException();
			if (item == null) throw new ArgumentNullException();

			return Array.IndexOf<T>(internalArray, item);
		}
		public T FindFirst(Func<T, bool> predicate)
		{
			if (internalArray == null) throw new NullReferenceException();

			return internalArray.FirstOrDefault(predicate);
		}
		public T[] FindAll(Func<T, bool> predicate)
		{
			if (internalArray == null) throw new NullReferenceException();

			var result = from item in internalArray
						 where predicate(item)
						 select item;

			return result.ToArray();
		}
		public virtual void InsertAtIndex(T item, int targetIndex)
		{
			if (internalArray == null) throw new NullReferenceException();
			if (item == null) throw new NullReferenceException();
			if (targetIndex > MaxIndex || targetIndex < 0) throw new IndexOutOfRangeException();

			IncreaseSize(1);
			for (int i = MaxIndex - 1; i >= targetIndex; i--)
			{
				internalArray[i + 1] = internalArray[i]; 
			}
			internalArray[targetIndex] = item;
		}
		public virtual void AddRange(T[] itemArray, int startIndex = -1)
		{
			if (itemArray == null || internalArray == null) throw new NullReferenceException();
			// Add range last.
			if (startIndex == -1)
			{
				foreach(var item in itemArray)
				{
					Add(item);
				}
				return;
			}
			for(int i = 0; i < itemArray.Length; i++)
			{
				InsertAtIndex(itemArray[i], startIndex + i);
			}
		}
		public virtual void AddRange(List<T> itemList, int startIndex = -1)
		{
			AddRange(itemList.ToArray<T>(), startIndex);
		}
		public virtual void AddFirst(T item)
		{
			InsertAtIndex(item, 0);
		}
		public virtual void RemoveElement(T targetElement)
		{
			if (targetElement == null) throw new ArgumentNullException();
			if (internalArray == null) throw new NullReferenceException();

			int elementIndex = FindIndex(targetElement);
			if (elementIndex == -1) return;

			T[] tempArray = new T[Count - 1];
			int originArrayIndex = 0;
			for(int tempArrayIndex = 0; tempArrayIndex < tempArray.Length; tempArrayIndex++)
			{
				if (tempArrayIndex == elementIndex)
				{
					originArrayIndex++;
				}
				tempArray[tempArrayIndex] = internalArray[originArrayIndex];
				originArrayIndex++;
			}
			CopyFullArray(tempArray);
		}
		public virtual void RemoveAtIndex(int targetIndex)
		{
			if (targetIndex < 0 || targetIndex > MaxIndex) throw new IndexOutOfRangeException();
			if (internalArray == null) throw new NullReferenceException();

			T[] tempArray = new T[Count - 1];
			int originArrayIndex = 0;
			for (int tempArrayIndex = 0; tempArrayIndex < tempArray.Length; tempArrayIndex++)
			{
				if (tempArrayIndex == targetIndex)
				{
					originArrayIndex++;
				}
				tempArray[tempArrayIndex] = internalArray[originArrayIndex];
				originArrayIndex++;
			}
			CopyFullArray(tempArray);
		}
		public virtual void RemoveFirst()
		{
			RemoveAtIndex(0);
		}
		public virtual void RemoveEnd()
		{
			RemoveAtIndex(MaxIndex);
		}
		public enum SortType
		{
			ASC,	
			DESC,	// 
		}
		/// <summary>
		/// Sort ASC AArray by custom predicate Func > 0, 1, 2 ...
		/// </summary>
		/// <param name="keyselector">lamda ex : (x) => x.someValue > 1</param>
		/// <exception cref="NullReferenceException"></exception>
		public virtual void SortASC<PredicateReturnType>(Func<T, PredicateReturnType> predicate)
		{
			if (internalArray == null) throw new NullReferenceException();
			internalArray = internalArray.OrderBy(predicate).ToArray();
		}
		/// <summary>
		/// Sort DESC AArray by custom predicate Func > 9, 8, 7 ...
		/// </summary>
		/// <typeparam name="KeyType"></typeparam>
		/// <param name="predicate"></param>
		/// <exception cref="NullReferenceException"></exception>
		public virtual void SortDESC<PredicateReturnType>(Func<T, PredicateReturnType> predicate)
		{
			if (internalArray == null) throw new NullReferenceException();
			internalArray = internalArray.OrderByDescending(predicate).ToArray();
		}
		public virtual void Reverse()
		{
			if (internalArray == null) throw new NullReferenceException();
			internalArray = internalArray.Reverse().ToArray();
		}
		protected const int DEFAULT_SHUFFLE_COUNT = 30;
		public virtual void Shuffle(int setShuffleCount = -1)
		{
			if (internalArray == null) throw new NullReferenceException();

			Random random = new Random();

			int maxShuffleCount = setShuffleCount == -1 ? DEFAULT_SHUFFLE_COUNT : setShuffleCount;
			for(int i = 0; i < maxShuffleCount; i++)
			{
				int first = random.Next(0, internalArray.Length);
				int second = random.Next(0, internalArray.Length);

				T temp = internalArray[first];
				internalArray[first] = internalArray[second];
				internalArray[second] = temp;
			}
		}
		public virtual void Clear()
		{
			internalArray = null;
			internalArray = Array.Empty<T>();
		}
		public virtual T PickRandom()
		{
			if (internalArray == null) throw new NullReferenceException();

			Random random = new Random();
			int randomIndex = random.Next(0, Count);
			return internalArray[randomIndex];
		}
		public virtual void ChangeElement(T element, int targetIndex)
		{
			if (internalArray == null) throw new NullReferenceException();
			internalArray[targetIndex] = element;
		}
		public virtual void PushRight()
		{
			if (internalArray == null) throw new NullReferenceException();
			
			T lastElement = internalArray[MaxIndex];
			for (int i = MaxIndex; i >= 1; i--)
			{
				internalArray[i] = internalArray[i - 1];
			}
			internalArray[0] = lastElement;
		}
		public virtual void PushLeft()
		{
			if (internalArray == null) throw new NullReferenceException();

			T firstElement = internalArray[0];

			for (int i = 0; i <= MaxIndex - 1; i++)
			{
				internalArray[i] = internalArray[i + 1];
			}
			internalArray[MaxIndex] = firstElement;
		}
		public IEnumerator<T> GetEnumerator()
		{
			if (internalArray == null) throw new NullReferenceException();
			return internalArray.OfType<T>().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			if (internalArray == null) throw new NullReferenceException();
			return internalArray.GetEnumerator();
		}
	}
}

