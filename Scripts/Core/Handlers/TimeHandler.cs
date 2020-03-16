using System;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles
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

                TimeScaleChanged?.Invoke();
            }
        }

        static Action TimeScaleChanged;

        public static void TimeScaleSubscribe(Action act)
        {
            TimeScaleChanged += act;
        }
        public static void TimeScaleUnsubscribe(Action act)
        {
            TimeScaleChanged -= act;
        }
    }
}
