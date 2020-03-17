using UnityEngine;
using Toodles.Mono;
using Sirenix.OdinInspector;

namespace Toodles.Mono
{
    public struct IterateThroughTime : IIteratable
    {
        [SerializeField, Required]
        IIteratable iterate;
        [SerializeField, Required]
        IGet<float> delay;
        [SerializeField, Required]
        IGet<bool> scaled;

        bool executed;
        public bool Iterate()
        {
            if (!executed)
            {
                if (scaled.Value) ScaledTimeEventHandler.ExecuteThroughTime(Action, delay.Value);
                else UnscaledTimeEventHandler.ExecuteThroughTime(Action, delay.Value);
            }
            return executed;
        }

        void Action()
        {
            if (!executed) executed = iterate.Iterate();
        }
    }
}
