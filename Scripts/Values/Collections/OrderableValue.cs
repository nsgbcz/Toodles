using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Toodles.Collections
{
    public struct OrderCluster<T> where T: Delegate
    {
        public readonly int Order;
        private T del;

        public OrderCluster(int order)
        {
            Order = order;
            del = null;
        }
}
