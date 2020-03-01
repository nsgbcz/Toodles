using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace Toodles.Collections
{
    public class SortedQueue<T> : IEnumerable<T>
    {
        List<T> list = new List<T>();
        int lowestIndex;
        T lowest;
        IComparer<T> comparer;
        public T this[int i]
        {
            get => list[i];
            set => list[i] = value;
        }

        public static SortedQueue<T>[] GetQueueArray(int length, IComparer<T> comparer)
        {
            SortedQueue<T>[] result = new SortedQueue<T>[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = new SortedQueue<T>(comparer);
            }
            return result;
        }

        public SortedQueue(IComparer<T> comparer)
        {
            ICollection<T> t = new List<T>();
            this.comparer = comparer;
        }

        public int Count => list.Count;

        public bool IsReadOnly => (list as ICollection<T>).IsReadOnly;

        public void Enqueue(T value)
        {
            if (list.Count == 0 || comparer.Compare(value, lowest) < 0)
            {
                lowest = value;
                lowestIndex = list.Count;
            }
            list.Add(value);
        }

        public T Peek()
        {
            return lowest;
        }
        public T Dequeue()
        {
            var result = lowest;
            list.RemoveAt(lowestIndex);

            if (list.Count != 0)
            {
                lowest = list[0];
                for (int i = 0; i < list.Count; i++)
                {
                    if (comparer.Compare(list[i], lowest) < 0)
                    {
                        lowest = list[i];
                        lowestIndex = i;
                    }
                }
            }

            return result;
        }

        public void Clear()
        {
            list.Clear();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        public bool Remove(T item)
        {
            if (item.Equals(lowest))
            {
                Dequeue();
                return true;
            }

            var index = list.IndexOf(item);
            if (index < 0) return false;

            RemoveAt(index);
            return true;
        }
        public void RemoveAt(int index)
        {
            if (index < lowestIndex) lowestIndex--;
            list.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}
