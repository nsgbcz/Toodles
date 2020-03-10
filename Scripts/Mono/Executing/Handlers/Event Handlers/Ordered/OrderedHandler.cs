using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Toodles.Handlers
{
    using Delegates;
    public abstract class OrderedHandler<T> : MonoBehaviour, IAction
    {
        List<(T, Action)> Listeners = new List<(T, Action)>();

        public void Action()
        {
            for (int i = 0; i < Listeners.Count; i++)
            {
                Listeners[i].Item2?.Invoke();
            }
        }

        public void AddListener(Action listener, T order)
        {
            var index = GetIndex(order);
            Listeners[index] = (order, Listeners[index].Item2 + listener);
        }

        public void RemoveListener(Action listener, T order)
        {
            var index = GetIndex(order);
            Listeners[index] = (order, Listeners[index].Item2 - listener);
        }
        /// <summary>
        /// Prefer ordered overload.
        /// </summary>
        public void RemoveListener(Action listener)
        {
            for (int i = 0; i < Listeners.Count; i++)
            {
                Listeners[i] = (Listeners[i].Item1, Listeners[i].Item2 - listener);
            }
        }

        public void Clear()
        {
            Listeners.Clear();
        }

        protected int Count()
        {
            return Listeners.Count;
        }

        protected (T, Action) Peek()
        {
            return Listeners[0];
        }
        protected (T, Action) Dequeue()
        {
            var result = Listeners[0];
            Listeners.RemoveAt(0);
            return result;
        }

        int GetIndex(T order)
        {
            var top = Listeners.Count - 1;
            var bot = 0;
            var mid = 0;

            while (bot <= top)
            {
                mid = (top + bot) / 2;
                switch (Compare(Listeners[mid].Item1, order))
                {
                    case 0:
                        return mid;
                    case -1:
                        bot = mid + 1;
                        break;
                    case 1:
                        top = mid - 1;
                        break;
                }
            }
            Listeners.Insert(bot, (order, null));
            return mid;
        }

        protected abstract int Compare(T x, T y);
    }
}
