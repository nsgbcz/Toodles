using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using Toodles.Actions;

namespace Toodles.Executes
{
    public abstract class ConcreteExecute<T> : BaseExecute, IDrawGizmosSelected
    {
        [PropertyOrder(-10), Required]
        public T execute;

#if UNITY_EDITOR
        private void OnValidate()
        {
            if (ExecuteType.Equals(_executeType)) return;

            ExecuteFactory.Replace(ExecuteType, this);
        }
#endif
        public void OnDrawGizmosSelected()
        {
            if (execute is IDrawGizmosSelected)
            {
                (execute as IDrawGizmosSelected).OnDrawGizmosSelected();
            }
        }
    }
}