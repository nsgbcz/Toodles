using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Toodles.Collections;

namespace Toodles.Handlers
{
    public class FrameEventHandler : MonoBehaviour
    {
        static FrameEventHandler _get;
        static FrameEventHandler Get
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
                _get = GameObject.FindObjectOfType<FrameEventHandler>();

                if (!ApplicationHandler.Quit && _get == null)
                {
                    _get = new GameObject("FrameEventHandler").AddComponent<FrameEventHandler>();
                    DontDestroyOnLoad(_get);
                }
            }
        }

        SortedQueue<OrderableValue<Action, int>> acts = new SortedQueue<OrderableValue<Action, int>>(OrderableValue<Action, int>.GetComparer);

        public static void ExecuteThroughFrames(Action act, int count)
        {
            var handler = Get;
            if (handler == null) return;

            var frameAct = new OrderableValue<Action, int>(act, Time.frameCount + count);
            handler.acts.Enqueue(frameAct);
        }

        public static void RemoveEvent(Action act)
        {
            var handler = Get;
            if (handler == null) return;

            for (int i = 0; i < handler.acts.Count; i++)
            {
                if (handler.acts[i].Equals(act))
                {
                    handler.acts.RemoveAt(i);
                    return;
                }
            }
        }

        void Update()
        {
            while (acts.Count > 0 && acts.Peek().order <= Time.frameCount)
            {
                acts.Dequeue().value?.Invoke();
            }
        }

        public void Reboot()
        {
            acts.Clear();
        }
    }
}
