using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Toodles.Handlers
{
    public class UnscaledTimeEventHandler : FloatOrderedHandler
    {
        private static FloatOrderedHandler _get = null;
        private static FloatOrderedHandler Get
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
                _get = GameObject.FindObjectOfType<UnscaledTimeEventHandler>();

                if (!ApplicationHandler.Quitting && _get == null)
                {
                    _get = new GameObject("EventHandler").AddComponent<UnscaledTimeEventHandler>();
                    DontDestroyOnLoad(_get);
                }
            }
        }
        public static void ExecuteOnTime(Action act, float time)
        {
            var handler = Get;
            if (handler == null) return;

            handler.AddListener(act, time);
        }
        /// <returns>The time on that the act will be executed</returns>
        public static float ExecuteThroughTime(Action act, float delay)
        {
            var time = Time.unscaledTime + delay;
            ExecuteOnTime(act, time);
            return time;
        }
        public static void Unsubscribe(Action act, float time)
        {
            var handler = Get;
            if (handler == null) return;

            handler.RemoveListener(act, time);
        }
        public static void Unsubscribe(Action act)
        {
            var handler = Get;
            if (handler == null) return;

            handler.RemoveListener(act);
        }

        void LateUpdate()
        {
            while (Count() > 0 && Peek().Item1 <= Time.unscaledTime)
            {
                Dequeue().Item2?.Invoke();
            }
        }
    }
}
