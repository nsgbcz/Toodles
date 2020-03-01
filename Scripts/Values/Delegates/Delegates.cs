using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toodles.Variables;
using Toodles.Handlers;
using Sirenix.OdinInspector;

namespace Toodles.Delegates
{
    public struct OneInvocation : IIterate
    {
        [Required]
        public IAction act;

        public bool Iterate()
        {
            act.Action();
            return true;
        }
    }
    public struct ManyInvocation : IIterate
    {
        [Required]
        public IAction act;

        public bool Iterate()
        {
            act.Action();
            return false;
        }
    }
    public struct FrameDelayExecute : IIterate
    {
        [SerializeField, Required]
        IIterate iterate;
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
    public struct DelayExecute : IIterate
    {
        [SerializeField, Required]
        IIterate iterate;
        [SerializeField, Required]
        IGet<float> delay;
        [SerializeField, Required]
        IGet<bool> scaled;

        bool executed;
        public bool Iterate()
        {
            if (!executed)
            {
                TimeEventHandler.ExecuteThroughTime(Action, delay.Value, scaled.Value);
            }
            return executed; 
        }

        void Action()
        {
            if(!executed) executed = iterate.Iterate();
        }
    }
    public struct TimeExecute : IIterate
    {
        [SerializeField, Required]
        IIterate iterate;
        [SerializeField, Required]
        IGet<float>  time;
        [SerializeField, Required]
        IGet<bool> scaled;

        bool executed;
        public bool Iterate()
        {
            if (!executed)
            {
                TimeEventHandler.ExecuteOnTime(Action, time.Value, scaled.Value);
            }
            return executed;
        }

        void Action()
        {
            if (!executed) executed = iterate.Iterate();
        }
    }
}
