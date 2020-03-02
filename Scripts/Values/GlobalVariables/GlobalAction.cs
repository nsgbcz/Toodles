﻿using Sirenix.OdinInspector;
using UnityEngine;

namespace Toodles.Variables
{
    using Controllers;
    using Delegates;
    using Executers;

    [CreateAssetMenu(menuName = "MyAssets/Actions/GlobalAction")]
    public class GlobalAction : SerializedScriptableObject, IAction
    {
        public IAction action;

        public void Action()
        {
            action?.Action();
        }
    }
}