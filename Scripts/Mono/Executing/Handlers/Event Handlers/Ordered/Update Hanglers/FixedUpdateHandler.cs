﻿using System;
using UnityEngine;
using System.Collections.Generic;

namespace Toodles.Handlers
{
    public class FixedUpdateHandler : IntOrderedHandler
    {
        private static IntOrderedHandler _get;
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
                var handlers = GameObject.FindObjectOfType<FixedUpdateHandler>();

                if (!ApplicationHandler.Quitting && _get == null)
                {
                    _get = new GameObject("EventHandler").AddComponent<FixedUpdateHandler>();
                    GameObject.DontDestroyOnLoad(_get);
                }
            }
        }

        public static void Subscribe(Action act, int order = 0)
        {
            var handler = Get;
            if (handler == null) return;

            handler.AddListener(act, order);
        }

        public static void Unsubscribe(Action act, int order = 0)
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

        private void FixedUpdate()
        {
            Action();
        }
    }
}
