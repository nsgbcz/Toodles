using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles
{
    public struct Filters<T> : IFilter<T>
    {
        public IFilter<T>[] filters;
        public bool Filter(T subject)
        {
            for (int i = 0; i < filters.Length; i++)
            {
                if (!filters[i].Filter(subject)) return false;
            }
            return true;
        }
    }
}
