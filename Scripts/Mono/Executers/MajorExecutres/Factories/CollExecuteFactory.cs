#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Toodles;
using System;
using UnityEditor;

namespace Toodles.Executers
{
    public class CollExecuteFactory : ExecuteFactory
    {
        public enum CollType
        {
            Nothing, Trigger2D, Collision2D, Trigger, Collision
        }
        public enum EventType
        {
            Nothing, Enter, Exit, Stay
        }

        CollType collType;
        EventType eventType;

        public CollExecuteFactory(CollExecute mustReplaced) : base(mustReplaced)
        {
            collType = mustReplaced.collType;
            eventType = mustReplaced.eventType;
        }

        CollExecute collExecute;
        protected override void AddExecute()
        {
            if (type != ExecuteType.Coll)
            {
                base.AddExecute();
                return;
            }
            switch (collType)
            {
                case CollType.Nothing:
                    collExecute = gameObject.AddComponent<CollExecute>();
                    break;
                case CollType.Trigger2D:
                    switch (eventType)
                    {
                        case EventType.Enter:
                            collExecute = gameObject.AddComponent<TriggerEnter2DExecute>();
                            break;
                        case EventType.Exit:
                            collExecute = gameObject.AddComponent<TriggerExit2DExecute>();
                            break;
                        case EventType.Stay:
                            collExecute = gameObject.AddComponent<TriggerStay2DExecute>();
                            break;
                        case EventType.Nothing:
                            collExecute = gameObject.AddComponent<Trigger2DExecute>();
                            break;
                    }
                    break;
                case CollType.Collision2D:

                    switch (eventType)
                    {
                        case EventType.Enter:
                            collExecute = gameObject.AddComponent<CollisionEnter2DExecute>();
                            break;
                        case EventType.Exit:
                            collExecute = gameObject.AddComponent<CollisionExit2DExecute>();
                            break;
                        case EventType.Stay:
                            collExecute = gameObject.AddComponent<CollisionStay2DExecute>();
                            break;
                        case EventType.Nothing:
                            collExecute = gameObject.AddComponent<Collision2DExecute>();
                            break;
                    }
                    break;
                case CollType.Trigger:
                    switch (eventType)
                    {
                        case EventType.Enter:
                            collExecute = gameObject.AddComponent<TriggerEnterExecute>();
                            break;
                        case EventType.Exit:
                            collExecute = gameObject.AddComponent<TriggerExitExecute>();
                            break;
                        case EventType.Stay:
                            collExecute = gameObject.AddComponent<TriggerStayExecute>();
                            break;
                        case EventType.Nothing:
                            collExecute = gameObject.AddComponent<TriggerExecute>();
                            break;
                    }
                    break;
                case CollType.Collision:

                    switch (eventType)
                    {
                        case EventType.Enter:
                            collExecute = gameObject.AddComponent<CollisionEnterExecute>();
                            break;
                        case EventType.Exit:
                            collExecute = gameObject.AddComponent<CollisionExitExecute>();
                            break;
                        case EventType.Stay:
                            collExecute = gameObject.AddComponent<CollisionStayExecute>();
                            break;
                        case EventType.Nothing:
                            collExecute = gameObject.AddComponent<CollisionExecute>();
                            break;
                    }
                    break;
            }
            execute = collExecute;
        }
        protected override void SetValues()
        {
            base.SetValues();
            if (collExecute != null)
            {
                collExecute.collType = collType;
                collExecute.eventType = eventType;
                collExecute._collType = collType;
                collExecute._eventType = eventType;
            }
        }
    }
}
#endif
