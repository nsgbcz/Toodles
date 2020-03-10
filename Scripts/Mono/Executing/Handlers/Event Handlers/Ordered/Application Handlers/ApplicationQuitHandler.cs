using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;
using System.Collections.Generic;

namespace Toodles.Handlers
{
    public class QuitHandler : IntOrderedHandler
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
                _get = GameObject.FindObjectOfType<QuitHandler>();

                if (!Quit && _get == null)
                {
                    _get = new GameObject("EventHandler").AddComponent<QuitHandler>();
                    DontDestroyOnLoad(_get);
                }
            }
        }
        void Awake()
        {
            SceneManager.sceneUnloaded += Unloaded;
            SceneManager.sceneLoaded += Loaded;
        }

        public static bool Quit { get; private set; } = false;
        public static bool SceneClosed { get; private set; } = false;

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
            SceneClosed = true;
        }

        void Loaded(Scene scene, LoadSceneMode mode)
        {
            SceneClosed = false;
        }

        void OnApplicationQuit()
        {
            SceneClosed = true;
            Quit = true;

            Action();
        }

        void OnDestroy()
        {
            SceneManager.sceneUnloaded -= Unloaded;
            SceneManager.sceneLoaded -= Loaded;
        }
    }
}
