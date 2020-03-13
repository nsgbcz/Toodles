using Sirenix.OdinInspector;
using UnityEngine;

namespace Toodles.GlobalVariables
{
    using IterableControllers;
    using Actions;
    using Variables;

    [CreateAssetMenu(menuName = "Toodles/Actions/GlobalAction")]
    public class GlobalAction : SerializedScriptableObject, IAction
    {
        public IAction action;

        public void Action()
        {
            action?.Action();
        }
    }
}
