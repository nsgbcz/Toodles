using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Toodles.Collections
{
    public class InputSortedList<T> : ICollection<T>
    {
        List<T> list = new List<T>();
        IComparer<T> comparer;

        public static InputSortedList<T>[] GetArray(int length, IComparer<T> comparer)
        {
            InputSortedList<T>[] result = new InputSortedList<T>[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = new InputSortedList<T>(comparer);
            }
            return result;
        }

        public InputSortedList(IComparer<T> comparer)
        {
            ICollection<T> t = new List<T>();
            this.comparer = comparer;
        }

        public T this[int i]
        {
            get => list[i]; 
            set => list[i] = value;
        }

        public int Count => list.Count;

        public bool IsReadOnly => (list as ICollection<T>).IsReadOnly;

        public void Add(T value)
        {
            if (list.Count != 0)
            {
                int bot = 0;
                int top = list.Count - 1;
                int mid = 0;

                while (bot <= top)
                {
                    mid = (top + bot) / 2;
                    int compare = comparer.Compare(value, list[mid]);
                    if (compare < 0) top = mid - 1;
                    else if (compare > 0) bot = mid + 1;
                    else
                    {
                        list.Insert(mid, value);
                        return;
                    }
                }
                list.Insert(mid, value);
            }
            list.Add(value);
        }
        public void MergedAdd(T value, Action<T, T> mergeOnEqual)
        {
            if (list.Count != 0)
            {
                int bot = 0;
                int top = list.Count - 1;
                int mid = 0;
                while (bot <= top)
                {
                    mid = (top + bot) / 2;
                    int compare = comparer.Compare(value, list[mid]);
                    if (compare < 0) top = mid - 1;
                    else if (compare > 0) bot = mid + 1;
                    else
                    {
                        mergeOnEqual.Invoke(list[mid], value);
                        return;
                    }
                }
                list.Insert(mid, value);
            }
            list.Add(value);
        }

        public void Clear()
        {
            list.Clear();
        }

        public bool Contains(T item)
        {
            return list.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            list.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public bool Remove(T item)
        {
            var index = FindIndex(item);

            if(index < 0) return false;
            RemoveAt(index);
            return true;
        }
        public void RemoveAt(int index)
        {
            list.RemoveAt(index);
        }

        public int FindIndex(T item)
        {
            if (list.Count == 0) return -1;
            int bot = 0;
            int top = list.Count - 1;

            while (bot <= top)
            {
                int mid = (top + bot) / 2;
                int compare = comparer.Compare(item, list[mid]);
                if (compare < 0) top = mid - 1;
                else if (compare > 0) bot = mid + 1;
                else
                {
                    if (list[mid].Equals(item)) return mid;

                    for (int i = mid + 1; i <= top; i++)
                    {
                        compare = comparer.Compare(item, list[i]);
                        if (compare != 0) break;
                        if (list[i].Equals(item)) return mid;
                    }
                    for (int i = mid - 1; i >= bot; i--)
                    {
                        compare = comparer.Compare(item, list[i]);
                        if (compare != 0) break;
                        if (list[i].Equals(item)) return mid;
                    }
                }
            }
            return -1;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}