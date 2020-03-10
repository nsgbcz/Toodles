﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toodles.Variables;
using Toodles.Handlers;
using Sirenix.OdinInspector;

namespace Toodles.Delegates
{
    public struct OneInvocation : IIteratable
    {
        [Required]
        public IAction act;

        public bool Iterate()
        {
            act.Action();
            return true;
        }
    }
    public struct ManyInvocation : IIteratable
    {
        [Required]
        public IAction act;

        public bool Iterate()
        {
            act.Action();
            return false;
        }
    }
    public struct FrameDelayExecute : IIteratable
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
    public struct DelayExecute : IIteratable
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
                if(scaled.Value) ScaledTimeEventHandler.ExecuteThroughTime(Action, delay.Value);
                else UnscaledTimeEventHandler.ExecuteThroughTime(Action, delay.Value);
            }
            return executed; 
        }

        void Action()
        {
            if(!executed) executed = iterate.Iterate();
        }
    }
    public struct TimeExecute : IIteratable
    {
        [SerializeField, Required]
        IIteratable iterate;
        [SerializeField, Required]
        IGet<float>  time;
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
