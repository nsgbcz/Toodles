using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System;
using UnityEngine.Jobs;

namespace Toodles.Handlers
{
    public class AsyncEventHandler : MonoBehaviour
    {
        private static AsyncEventHandler _get = null;
        private static AsyncEventHandler Get
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
                _get = GameObject.FindObjectOfType<AsyncEventHandler>();

                if (!ApplicationQuitHandler.Quitting && _get == null)
                {
                    _get = new GameObject("EventHandler").AddComponent<AsyncEventHandler>();
                    DontDestroyOnLoad(_get);
                }
            }
        }

        Queue<Action> Callbacks = new Queue<Action>();
        public void LateUpdate()
        {
            if (Callbacks.Count > 0)
            {
                lock (Callbacks)
                {
                    do
                    {
                        Callbacks.Dequeue().Invoke();
                    }
                    while (Callbacks.Count > 0);
                }
            }
        }

        public static void Action(Action async, Action callback)
        {
            Get?.Begin(async, callback);
        }
        public static void Action(Action async)
        {
            Get?.Begin(async);
        }

        void Begin(Action act, Action callback)
        {
            ThreadPool.QueueUserWorkItem(Execute);

            void Execute(object obj)
            {
                act?.Invoke();
                lock (Callbacks) 
                {
                    Callbacks.Enqueue(callback); 
                }
            }
        }
        void Begin(Action act)
        {
            ThreadPool.QueueUserWorkItem(Execute);

            void Execute(object obj)
            {
                act?.Invoke();
            }
        }
    }
}
