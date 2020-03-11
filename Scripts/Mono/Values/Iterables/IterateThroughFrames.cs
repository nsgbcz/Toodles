using UnityEngine;
using Toodles.Variables;
using Toodles.Handlers;
using Sirenix.OdinInspector;

namespace Toodles.Iterates
{
    public struct IterateThroughFrames : IIteratable
    {
        [SerializeField, Required]
        IIteratable iterate;
        [SerializeField, Required]
        IGet<int> delay;

        bool executed;
        public bool Iterate()
        {
            if (!executed)
            {
                FrameEventHandler.ExecuteThroughFrames(Action, delay.Value);
            }
            return executed;
        }

        void Action()
        {
            if (!executed) executed = iterate.Iterate();
        }
    }
}
