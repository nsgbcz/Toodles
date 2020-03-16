using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Toodles.Mono
{
    public class ScaledTimeEventHandler : FloatOrderedHandler
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
            if (_get == null && !ApplicationQuitHandler.Quitting)
            {
                _get = GameObject.FindObjectOfType<ScaledTimeEventHandler>();

                if (_get == null)
                {
                    var obj = GameObject.Find("EventHandler");
                    if (obj == null) obj = new GameObject("EventHandler");

                    _get = obj.AddComponent<ScaledTimeEventHandler>();
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
            var time = Time.time + delay;
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
            while (Count() > 0 && Peek().Item1 <= Time.time)
            {
                Dequeue().Item2?.Invoke();
            }
        }
    }
}
