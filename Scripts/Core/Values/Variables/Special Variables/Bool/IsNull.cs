using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles
{
    public struct IsNull : IGet<bool>, IIteratable
    {
        [SerializeField, Required, HideLabel]
        object value;
        public bool Value => value == null;

        public bool Iterate()
        {
            return Value;
        }
    }
}
