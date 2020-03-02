#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toodles;
using System;
using UnityEditor;

namespace Toodles.Executers
{
    public class PointerExecuteFactory : ExecuteFactory
    {
        public enum EventType
        {
            Nothing, Up, Down, Drag, Enter, Exit, Click
        }

        EventType eventType;
        public PointerExecuteFactory(PointerExecute mustReplaced) : base(mustReplaced)
        {
            eventType = mustReplaced.eventType;
        }

        PointerExecute pointerExecute;
        protected override void AddExecute()
        {
            if (type != ExecuteType.Pointer)
            {
                base.AddExecute();
                return;
            }
            switch (eventType)
            {
                case EventType.Nothing:
                    pointerExecute = gameObject.AddComponent<PointerExecute>();
                    break;
                case EventType.Up:
                    pointerExecute = gameObject.AddComponent<PointerUpExecute>();
                    break;
                case EventType.Down:
                    pointerExecute = gameObject.AddComponent<PointerDownExecute>();
                    break;
                case EventType.Drag:
                    pointerExecute = gameObject.AddComponent<PointerDragExecute>();
                    break;
                case EventType.Enter:
                    pointerExecute = gameObject.AddComponent<PointerEnterExecute>();
                    break;
                case EventType.Exit:
                    pointerExecute = gameObject.AddComponent<PointerExitExecute>();
                    break;
                case EventType.Click:
                    pointerExecute = gameObject.AddComponent<PointerClickExecute>();
                    break;
            }
            execute = pointerExecute;
        }
        protected override void SetValues()
        {
            base.SetValues();
            if (pointerExecute != null)
            {
                pointerExecute.eventType = eventType;
                pointerExecute._eventType = eventType;
            }
        }
    }
}
#endif
