using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executers
{
    public class MouseExecute : Execute
    {
#if UNITY_EDITOR
        [SerializeField]
        internal MouseExecuteFactory.EventType  eventType = MouseExecuteFactory.EventType.Nothing;

        [SerializeField, HideInInspector]
        internal MouseExecuteFactory.EventType _eventType = MouseExecuteFactory.EventType.Nothing;

        new protected void OnValidate()
        {
            if (eventType == _eventType)
            {
                base.OnValidate();
                return;
            }
            new MouseExecuteFactory(this).Produce();
        }
#endif
    }
}