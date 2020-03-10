using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Toodles.Handlers
{
    public class TimeScaleEventHandler : IntOrderedHandler
    {
        private static IntOrderedHandler _get = null;
        private static IntOrderedHandler Get
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
                _get = GameObject.FindObjectOfType<TimeScaleEventHandler>();

                if (!ApplicationHandler.Quitting && _get == null)
                {
                    _get = new GameObject("EventHandler").AddComponent<TimeScaleEventHandler>();
                    DontDestroyOnLoad(_get);
                }
            }
        }

        private void Awake()
        {
            TimeHandler.TimeScaleSubscribe(Action);
        }

        public static void Subscribe(Action act, int order)
        {
            var handler = Get;
            if (handler == null) return;

            handler.AddListener(act, order);
        }
        public static void Unsubscribe(Action act, int order)
        {
            var handler = Get;
            if (handler == null) return;

            handler.RemoveListener(act, order);
        }
        public static void Unsubscribe(Action act)
        {
            var handler = Get;
            if (handler == null) return;

            handler.RemoveListener(act);
        }
    }
}
