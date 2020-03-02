using Toodles.Delegates;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using Sirenix.OdinInspector.Editor;

namespace Toodles.Executers
{
    public class MainExecute : Execute
    {
#if UNITY_EDITOR
        [SerializeField]
        internal MainExecuteFactory.EventType  eventType = MainExecuteFactory.EventType.Nothing;

        [SerializeField, HideInInspector]
        internal MainExecuteFactory.EventType _eventType = MainExecuteFactory.EventType.Nothing;
        new protected void OnValidate()
        {
            if (eventType == _eventType)
            {
                base.OnValidate();
                return;
            }
            new MainExecuteFactory(this).Produce();
        }
#endif
    }
}