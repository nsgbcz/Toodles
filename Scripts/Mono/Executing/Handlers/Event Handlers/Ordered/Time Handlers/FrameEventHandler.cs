using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace Toodles.Handlers
{
    public class FrameEventHandler : IntOrderedHandler
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
                _get = GameObject.FindObjectOfType<FrameEventHandler>();

                if (!ApplicationHandler.Quitting && _get == null)
                {
                    _get = new GameObject("EventHandler").AddComponent<FrameEventHandler>();
                    DontDestroyOnLoad(_get);
                }
            }
        }
        public static void ExecuteOnFrame(Action act, int frame)
        {
            var handler = Get;
            if (handler == null) return;

            handler.AddListener(act, frame);
        }
        /// <returns>The frame on that the act will be executed</returns>
        public static int ExecuteThroughFrames(Action act, int frames)
        {
            var frame = Time.frameCount + frames;
            ExecuteOnFrame(act, frame);
            return frame;
        }
        public static void Unsubscribe(Action act, int frame)
        {
            var handler = Get;
            if (handler == null) return;

            handler.RemoveListener(act, frame);
        }
        public static void Unsubscribe(Action act)
        {
            var handler = Get;
            if (handler == null) return;

            handler.RemoveListener(act);
        }

        void Update()
        {
            while (Count() > 0 && Peek().Item1 <= Time.frameCount)
            {
                Dequeue().Item2?.Invoke();
            }
        }
    }
}
