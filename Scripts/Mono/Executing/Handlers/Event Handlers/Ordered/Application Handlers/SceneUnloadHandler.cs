using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;
using System.Collections.Generic;

namespace Toodles.Handlers
{
    public class SceneUnloadHandler : IntOrderedHandler
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
        [RuntimeInitializeOnLoadMethod]
        static void Init()
        {
            if (_get == null)
            {
                _get = GameObject.FindObjectOfType<SceneUnloadHandler>();

                if (!ApplicationQuitHandler.Quitting && _get == null)
                {
                    _get = new GameObject("EventHandler").AddComponent<SceneUnloadHandler>();
                    DontDestroyOnLoad(_get);
                }
            }
        }
        void Awake()
        {
            SceneManager.sceneUnloaded += Unloaded;
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

        void Unloaded(Scene scene)
        {
            Action();
        }

        void OnDestroy()
        {
            SceneManager.sceneUnloaded -= Unloaded;
        }
    }
}
