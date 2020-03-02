using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Toodles.Collections;

namespace Toodles.Handlers
{
    public class TimeEventHandler : MonoBehaviour
    {
        static TimeEventHandler _get;
        static TimeEventHandler Get
        {
            get
            {
                Init();
                return _get;
            }
        }
        static void Init()
        {
            if (_get == null)
            {
                _get = GameObject.FindObjectOfType<TimeEventHandler>();

                if (!ApplicationHandler.Quit && _get == null)
                {
                    _get = new GameObject("TimeEventHandler").AddComponent<TimeEventHandler>();
                    DontDestroyOnLoad(_get);
                }
            }
        }

        SortedQueue<OrderableValue<Action, float>> unscaled = new SortedQueue<OrderableValue<Action, float>>(OrderableValue<Action, float>.GetComparer);
        SortedQueue<OrderableValue<Action, float>> scaled   = new SortedQueue<OrderableValue<Action, float>>(OrderableValue<Action, float>.GetComparer);

        public static void ExecuteOnTime(Action act, float time, bool scaled)
        {
            var handler = Get;
            if (handler == null) return;

            var timeAction = new OrderableValue<Action, float>(act, time);
            if (scaled)
                handler.scaled.Enqueue(timeAction);
            else
                handler.unscaled.Enqueue(timeAction);
        }
        public static void ExecuteThroughTime(Action act, float delay, bool scaled)
        {
            var time = (scaled ? Time.time : Time.unscaledTime) + delay;
            ExecuteOnTime(act, time, scaled);
        }
        public static void RemoveEvent(Action act, bool scaled)
        {
            var handler = Get;
            if (handler == null) return;

            var list = scaled ? handler.scaled : handler.unscaled;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Equals(act))
                {
                    list.RemoveAt(i);
                    return;
                }
            }
        }
        public static void RemoveEvent(Action act)
        {
            var handler = Get;
            if (handler == null) return;

            for (int i = 0; i < handler.scaled.Count; i++)
            {
                if (handler.scaled[i].Equals(act))
                {
                    handler.scaled.RemoveAt(i);
                    return;
                }
            }
            for (int i = 0; i < handler.unscaled.Count; i++)
            {
                if (handler.unscaled[i].Equals(act))
                {
                    handler.unscaled.RemoveAt(i);
                    return;
                }
            }
        }

        void LateUpdate()
        {
            while (scaled.Count > 0 && scaled.Peek().order <= Time.time)
            {
                scaled.Dequeue().value?.Invoke();
            }
            while (unscaled.Count > 0 && unscaled.Peek().order <= Time.unscaledTime)
            {
                unscaled.Dequeue().value?.Invoke();
            }
        }

        public void Reboot()
        {
            scaled.Clear();
            unscaled.Clear();
        }

        
    }
}
