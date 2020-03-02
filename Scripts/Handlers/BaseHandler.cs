using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Toodles.Handlers
{
    public class BaseHandler : MonoBehaviour
    {
        List<ListenerCluster> listeners = new List<ListenerCluster>();




        public void AddListener(Func<bool> listener)
        {
            listeners += listener;
        }
        public void RemoveListener(Func<bool> listener)
        {
            listeners -= listener;
        }
        struct ListenerCluster
        {
            public readonly int Order;
            private Func<bool> listeners;

            public ListenerCluster(int order)
            {
                Order = order;
                listeners = null;
            }

            public void AddListener(Func<bool> listener)
            {
                listeners += listener;
            }
            public void RemoveListener(Func<bool> listener)
            {
                listeners -= listener;
            }
        }
    }
}
