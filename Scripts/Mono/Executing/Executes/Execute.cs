﻿using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Toodles.Mono
{
    public class Execute : ConcreteExecute<IIteratable>, IAction, IIteratable
    {
#if UNITY_EDITOR
        bool ShowActionButton { get => execute != null; }
#endif

        [Button, ShowIf("ShowActionButton"), PropertyOrder(3)]
        public virtual void Action()
        {
            if (this != null && Iterate()) Destroy(this);
        }

        public bool Iterate()
        {
            return execute.Iterate();
        }
    }
}