using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles
{
    [CreateAssetMenu(menuName = "Toodles/Variables/Container")]
    public class GlobalContainer : SerializedScriptableObject, IVar<IContainer> 
    {
        [SerializeField, HideLabel, Required]
        IContainer Container;
        public IContainer Value { get => Container; set => Container = value; }
    }
}