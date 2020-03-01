using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Toodles.Collections
{
    public struct OrderableValue<T, T1> : IComparable<OrderableValue<T, T1>>, IEquatable<OrderableValue<T, T1>> where T1: IComparable<T1>
    {
        public T  value;
        public T1 order;

        public OrderableValue(T value, T1 order)
        {
            this.value = value;
            this.order = order;
        }

        public int CompareTo(OrderableValue<T, T1> other)
        {
            return order.CompareTo(other.order);
        }
        public bool Equals(OrderableValue<T, T1> other)
        {
            return value.Equals(other.value);
        }

        public static IComparer<OrderableValue<T, T1>> GetComparer
        {
            get
            {
                return new Comparer();
            }
        }
        struct Comparer : IComparer<OrderableValue<T, T1>>
        {
            public int Compare(OrderableValue<T, T1> x, OrderableValue<T, T1> y)
            {
                return x.CompareTo(y);
            }
        }
    }
}
