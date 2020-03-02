using System;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Handlers
{
    public static class TimeHandler
    {
        static float _timeStep;
        public static float TimeStep
        {
            get
            {
                return _timeStep;
            }
            set
            {
                _timeStep = value;
                Time.fixedDeltaTime = Time.timeScale * value;
            }
        }
        public static float TimeScale
        {
            get
            {
                return Time.timeScale;
            }
            set
            {
                Time.timeScale = value;
                Time.fixedDeltaTime = value * TimeStep;

                OnTimeScaleChanged?.Invoke();
            }
        }

        static Action OnTimeScaleChanged;

        public static void TimeScaleSubscribe(Action act)
        {
            OnTimeScaleChanged += act;
        }
        public static void TimeScaleUnsubscribe(Action act)
        {
            OnTimeScaleChanged -= act;
        }
    }
}
