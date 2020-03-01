using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Reflection;
using System.Collections.Generic;
using Toodles.Collections;

namespace Toodles
{
    public class ApplicationHandler : MonoBehaviour
    {
        private static ApplicationHandler _get = null;
        private static ApplicationHandler Get
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
                _get = GameObject.FindObjectOfType<ApplicationHandler>();

                if (!Quit && _get == null)
                {
                    _get = new GameObject("ApplicationHandler").AddComponent<ApplicationHandler>();
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

        public enum EventType { Quit, Pause, Resume, Unloaded, Loaded }

        InputSortedList<OrderableValue<Func<bool>, int>>[] listeners = InputSortedList<OrderableValue<Func<bool>, int>>.GetArray(5, OrderableValue<Func<bool>, int>.GetComparer);

        public static void Subscribe(Func<bool> fun, params EventType[] types)
        {
            Subscribe(fun, 0, types);
        }
        public static void Subscribe(Func<bool> fun, int order, params EventType[] types)
        {
            var handler = Get;
            if (handler == null) return;

            var value = new OrderableValue<Func<bool>, int>(fun, order);

            for (int i = 0; i < types.Length; i++)
            {
                handler.listeners[(int)types[i]].MergedAdd(value, (a, b)=> { a.value += fun; });
            }
        }
        public static void Unsubscribe(Func<bool> fun, params EventType[] types)
        {
            Unsubscribe(fun, 0, types);
        }
        public static void Unsubscribe(Func<bool> fun, int order, params EventType[] types)
        {
            var handler = Get;
            if (handler == null) return;

            var value = new OrderableValue<Func<bool>, int>(fun, order);

            for (int i = 0; i < types.Length; i++)
            {
                handler.listeners[(int)types[i]].Remove(value);
            }
        }

        void OnApplicationPause(bool pause)
        {
            if (pause)
                listeners[1].Execute();// 1 - Pause
            else
                listeners[2].Execute();// 2 - Resume
        }

        void Unloaded(Scene scene)
        {
            SceneClosed = true;
            listeners[3].Execute();// 3 - Unloaded
        }

        void Loaded(Scene scene, LoadSceneMode mode)
        {
            SceneClosed = false;

            listeners[4].Execute();// 4 - Loaded
        }

        void OnApplicationQuit()
        {
            SceneClosed = true;
            Quit = true;

            listeners[0].Execute();// 0 - Quit
        }

        void OnDestroy()
        {
            SceneManager.sceneUnloaded -= Unloaded;
            SceneManager.sceneLoaded -= Loaded;
        }
    }
}
