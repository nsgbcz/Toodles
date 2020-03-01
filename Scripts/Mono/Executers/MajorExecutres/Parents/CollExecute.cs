using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executers 
{
    public class CollExecute : Execute
    {
#if UNITY_EDITOR
        [SerializeField]
        internal CollExecuteFactory.CollType   collType = CollExecuteFactory.CollType.Nothing;
        [SerializeField]
        internal CollExecuteFactory.EventType eventType = CollExecuteFactory.EventType.Nothing;

        [SerializeField, HideInInspector]
        internal CollExecuteFactory.CollType   _collType = CollExecuteFactory.CollType.Nothing;
        [SerializeField, HideInInspector]
        internal CollExecuteFactory.EventType _eventType = CollExecuteFactory.EventType.Nothing;
        new protected void OnValidate()
        {
            if (_collType == collType && _eventType == eventType)
            {
                base.OnValidate();
                return;
            }
            new CollExecuteFactory(this).Produce();
        }
#endif
    }
}