using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System.Threading.Tasks;
using System;
using UnityEngine.Jobs;

namespace Toodles.Handlers
{
    public class AsyncHandler : MonoBehaviour
    {
        private static AsyncHandler _get = null;
        private static AsyncHandler Get
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
                _get = GameObject.FindObjectOfType<AsyncHandler>();

                if (!ApplicationHandler.Quit && _get == null)
                {
                    _get = new GameObject("AsyncHandler").AddComponent<AsyncHandler>();
                    DontDestroyOnLoad(_get);
                }
            }
        }

        Queue<Action> calls = new Queue<Action>();
        public void LateUpdate()
        {
            while(calls.Count > 0) calls.Dequeue().Invoke();
        }

        public static void Action(Action async, Action callback)
        {
            Get?.BeginJob(async, callback);
        }

        void BeginJob(Action act, Action callback)
        {
            new Task(Execute).Start();

            void Execute()
            {
                act?.Invoke();
                calls.Enqueue(callback);
            }
        }
    }
}
