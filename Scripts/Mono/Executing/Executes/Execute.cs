using Toodles.Controllers;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using Toodles.Iterates;

namespace Toodles.Executes
{
    public class Execute : ConcreteExecute<IIteratable>, IExecute
    {
#if UNITY_EDITOR
        bool ShowActionButton { get => execute != null; }
        bool ShowBuildButton { get => execute is IBuilder; }
        [Button, ShowIf("ShowBuildButton"), PropertyOrder(2)]
        public virtual void Build()
        {
            var builder = execute as IBuilder;
            execute = builder?.GetAct();
        }
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