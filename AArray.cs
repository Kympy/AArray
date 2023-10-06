using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AmazingArray
{
	public class AArray<T>
	{
		private T[]? internalArray;
		private int arraySize;
		public int InternalSize
		{
			get { return arraySize; }
		}
		public int InternalMaxIndex
		{
			get 
			{
				if (arraySize == 0) return 0;
				return arraySize - 1; 
			}
		}
		private int arrayIndexPointer = 0;
		public AArray()
		{
			// Default size is 10.
			arraySize = 10;
			internalArray = new T[arraySize];
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
				if (internalArray == null || index > InternalMaxIndex)
				{
					throw new IndexOutOfRangeException();
				}
				return internalArray[index];
			}
			set
			{
				if (internalArray == null || index > InternalMaxIndex)
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
			arraySize = originArray.Length;
			internalArray = new T[arraySize];
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
		protected int elementCount = 0;
		public int Count
		{
			get { return elementCount; }
		}
		public virtual void Add(T item)
		{
			if (internalArray == null)
			{
				throw new NullReferenceException();
			}
			if (IsNeedToResize == true)
			{
				Resize();
			}
			internalArray[arrayIndexPointer++] = item;
			elementCount++;
		}
		protected bool IsNeedToResize
		{
			get
			{
				if (internalArray == null)
				{
					throw new NullReferenceException();
				}
				if (arrayIndexPointer > InternalMaxIndex)
				{
					return true;
				}
				return false;
			}
		}
		protected virtual void Resize()
		{
			if (internalArray == null)
			{
				throw new NullReferenceException();
			}
			T[] tempArray = new T[arraySize + arraySize];
			CopyFullArray(internalArray, tempArray);
			arraySize = tempArray.Length;
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
            if (IsNeedToResize == true)
            {
				Resize();
            }
			internalArray[arrayIndexPointer++] = item;
			elementCount++;
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

		}
		public virtual void AddFirst(T item)
		{

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
	}
}

