using System;
using UnityEngine;
using System.Collections.Generic;

namespace Toodles.Handlers
{
    public static class GlobalUpdateHandler
    {
        private static UpdateHandler _get;
        private static UpdateHandler Get
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
                var handlers = GameObject.FindObjectsOfType<UpdateHandler>();
                for (int i = 0; i < handlers.Length; i++)
                {
                    if (handlers[i].name == "GlobalUpdateHandler") _get = handlers[i];
                }

                if (!ApplicationHandler.SceneClosed && _get == null)
                {
                    _get = new GameObject("GlobalUpdateHandler").AddComponent<UpdateHandler>();
                    GameObject.DontDestroyOnLoad(_get);
                }
            }
        }

        public static void Subscribe(Func<bool> act, UpdateHandler.UpdateType type)
        {
            var handler = Get;
            if (handler == null) return;

            handler.Subscribe(act, type);
        }

        public static void Unsubscribe(Func<bool> act, UpdateHandler.UpdateType type)
        {
            var handler = Get;
            if (handler == null) return;

            handler.Unsubscribe(act, type);
        }
        public static void Unsubscribe(Func<bool> act)
        {
            var handler = Get;
            if (handler == null) return;

            handler.Unsubscribe(act);
        }
    }
}
