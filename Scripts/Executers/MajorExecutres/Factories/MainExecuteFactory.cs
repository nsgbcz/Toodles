#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toodles;
using System;
using UnityEditor;

namespace Toodles.Executers
{
    public class MainExecuteFactory : ExecuteFactory
    {
        public enum EventType
        {
            Nothing, Awake, Start, Enable, Disable, Update, FixedUpdate, LateUpdate, Destroy
        }

        EventType eventType;
        public MainExecuteFactory(MainExecute mustReplaced) : base(mustReplaced)
        {
            eventType = mustReplaced.eventType;
        }

        MainExecute mainExecute;
        protected override void AddExecute()
        {
            if(type != ExecuteType.Main)
            {
                base.AddExecute();
                return;
            }
            switch (eventType)
            {
                case EventType.Nothing:
                    mainExecute = gameObject.AddComponent<MainExecute>();
                    break;
                case EventType.Awake:
                    mainExecute = gameObject.AddComponent<AwakeExecute>();
                    break;
                case EventType.Start:
                    mainExecute = gameObject.AddComponent<StartExecute>();
                    break;
                case EventType.Enable:
                    mainExecute = gameObject.AddComponent<EnableExecute>();
                    break;
                case EventType.Disable:
                    mainExecute = gameObject.AddComponent<DisableExecute>();
                    break;
                case EventType.Update:
                    mainExecute = gameObject.AddComponent<UpdateExecute>();
                    break;
                case EventType.FixedUpdate:
                    mainExecute = gameObject.AddComponent<FixedUpdateExecute>();
                    break;
                case EventType.LateUpdate:
                    mainExecute = gameObject.AddComponent<LateUpdateExecute>();
                    break;
                case EventType.Destroy:
                    mainExecute = gameObject.AddComponent<DestroyExecute>();
                    break;
            }
            execute = mainExecute;
        }
        protected override void SetValues()
        {
            base.SetValues();
            if (mainExecute != null)
            {
                mainExecute.eventType = eventType;
                mainExecute._eventType = eventType;
            }
        }
    }
}
#endif
