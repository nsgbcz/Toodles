﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;
using System.Collections.Generic;

namespace Toodles.Handlers
{
    public class SceneLoadHandler : IntOrderedHandler
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
                _get = GameObject.FindObjectOfType<SceneLoadHandler>();

                if (!ApplicationQuitHandler.Quitting && _get == null)
                {
                    _get = new GameObject("EventHandler").AddComponent<SceneLoadHandler>();
                    DontDestroyOnLoad(_get);
                }
            }
        }
        void Awake()
        {
            SceneManager.sceneLoaded += Loaded;
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

        void Loaded(Scene scene, LoadSceneMode mode)
        {
            Action();
        }

        void OnDestroy()
        {
            SceneManager.sceneLoaded -= Loaded;
        }
    }
}
