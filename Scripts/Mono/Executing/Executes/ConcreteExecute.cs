using Toodles.Controllers;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using Toodles.Iterates;

namespace Toodles.Executes
{
    public abstract class ConcreteExecute<T> : BaseExecute
    {
        [PropertyOrder(-10), Required]
        public T execute;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (ExecuteType.Equals(_executeType)) return;

            ExecuteFactory.Replace(ExecuteType, this);
        }

        bool IsBuilder
        {
            get
            {
                return execute is IBuilder && execute is IIteratable;
            }
        }
        [Button, ShowIf("IsBuilder")]
        void Build()
        {
            execute = (T)(execute as IBuilder).GetAct();
        }
#endif
    }
}