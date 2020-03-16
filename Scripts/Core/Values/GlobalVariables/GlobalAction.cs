using Sirenix.OdinInspector;
using UnityEngine;

namespace Toodles
{
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
