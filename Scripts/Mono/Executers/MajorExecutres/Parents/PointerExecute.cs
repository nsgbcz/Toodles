using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.EventSystems;

namespace Toodles.Executers
{
    public class PointerExecute : Execute, Variables.IGet<PointerEventData>
    {
        PointerEventData data;
        public PointerEventData Value => data;
#if UNITY_EDITOR
        [SerializeField, DelayedProperty]
        internal PointerExecuteFactory.EventType  eventType = PointerExecuteFactory.EventType.Nothing;

        [SerializeField, HideInInspector]
        internal PointerExecuteFactory.EventType _eventType = PointerExecuteFactory.EventType.Nothing;
        new protected void OnValidate()
        {
            if (eventType == _eventType)
            {
                base.OnValidate();
                return;
            }
            new PointerExecuteFactory(this).Produce();
        }
#endif
        public void Action(PointerEventData data)
        {
            this.data = data;
            base.Action();
        }
    }
}