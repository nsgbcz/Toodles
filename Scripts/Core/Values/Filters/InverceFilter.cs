using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Toodles
{
    public struct InverceFilter<T> : IFilter<T>
    {
        public IFilter<T> filter;
        public bool Filter(T subject)
        {
            return !filter.Filter(subject);
        }
    }
}
