using UnityEngine;
using Toodles.Variables;
using Toodles.Handlers;
using Sirenix.OdinInspector;

namespace Toodles.Iterates
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
