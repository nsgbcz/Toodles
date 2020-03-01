using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles
{
    public interface IFilter<T>
    {
        bool Filter(T subject);
    }

    public struct Stamb<T> : IFilter<T>
    {
        public bool Filter(T subject) => true;
    }
    public struct InverceFilter<T> : IFilter<T>
    {
        public IFilter<T> filter;
        public bool Filter(T subject)
        {
            return !filter.Filter(subject);
        }
    }
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
