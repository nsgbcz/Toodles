using UnityEngine;
using Toodles.Mono;
using Sirenix.OdinInspector;

namespace Toodles
{
    public struct IterateOnTime : IIteratable
    {
        [SerializeField, Required]
        IIteratable iterate;
        [SerializeField, Required]
        IGet<float> time;
        [SerializeField, Required]
        IGet<bool> scaled;

        bool executed;
        public bool Iterate()
        {
            if (!executed)
            {
                if (scaled.Value) ScaledTimeEventHandler.ExecuteOnTime(Action, time.Value);
                else UnscaledTimeEventHandler.ExecuteOnTime(Action, time.Value);
            }
            return executed;
        }

        void Action()
        {
            if (!executed) executed = iterate.Iterate();
        }
    }
}
