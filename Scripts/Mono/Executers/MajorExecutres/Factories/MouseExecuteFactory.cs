#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toodles;
using System;
using UnityEditor;

namespace Toodles.Executers
{
    public class MouseExecuteFactory : ExecuteFactory
    {
        public enum EventType
        {
            Nothing, Up, Down, Drag, Over, Enter, Exit, UpAsButton
        }

        EventType eventType;
        public MouseExecuteFactory(MouseExecute mustReplaced) : base(mustReplaced)
        {
            eventType = mustReplaced.eventType;
        }

        MouseExecute mouseExecute;
        protected override void AddExecute()
        {
            if (type != ExecuteType.Mouse)
            {
                base.AddExecute();
                return;
            }
            switch (eventType)
            {
                case EventType.Nothing:
                    mouseExecute = gameObject.AddComponent<MouseExecute>();
                    break;
                case EventType.Up:
                    mouseExecute = gameObject.AddComponent<MouseUpExecute>();
                    break;
                case EventType.Down:
                    mouseExecute = gameObject.AddComponent<MouseDownExecute>();
                    break;
                case EventType.Drag:
                    mouseExecute = gameObject.AddComponent<MouseDragExecute>();
                    break;
                case EventType.Over:
                    mouseExecute = gameObject.AddComponent<MouseOverExecute>();
                    break;
                case EventType.Enter:
                    mouseExecute = gameObject.AddComponent<MouseEnterExecute>();
                    break;
                case EventType.Exit:
                    mouseExecute = gameObject.AddComponent<MouseExitExecute>();
                    break;
                case EventType.UpAsButton:
                    mouseExecute = gameObject.AddComponent<MouseUpAsButtonExecute>();
                    break;
            }
            execute = mouseExecute;
        }
        protected override void SetValues()
        {
            base.SetValues();
            if (mouseExecute != null)
            {
                mouseExecute.eventType = eventType;
                mouseExecute._eventType = eventType;
            }
        }
    }
}
#endif
