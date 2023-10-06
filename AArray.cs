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
				if (internalArray.Length  - 1 < 0) return 0;
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
			if (originArray == null)
			{
				throw new ArgumentNullException();
			}
			internalArray = new T[originArray.Length];
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
			IncreaseSize();
			internalArray[MaxIndex] = item;
		}
		protected virtual void IncreaseSize(int amount = 1)
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
			IncreaseSize();
			internalArray[MaxIndex] = item;
        }
		public bool Contains(T item)
		{
			if (internalArray == null)
			{
				throw new NullReferenceException();
			}
            if (item == null)
            {
				throw new ArgumentNullException();
            }
			return Array.IndexOf<T>(internalArray, item) != -1;
        }
		public virtual void InsertAtIndex(T item, int targetIndex)
		{
			if (internalArray == null) throw new NullReferenceException();
			if (item == null) throw new NullReferenceException();
			if (targetIndex > MaxIndex || targetIndex < 0) throw new IndexOutOfRangeException();

			IncreaseSize();
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

		}
		public virtual void RemoveAtIndex(int targetIndex)
		{

		}
		public virtual void RemoveFirst()
		{

		}
		public virtual void RemoveEnd()
		{

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

