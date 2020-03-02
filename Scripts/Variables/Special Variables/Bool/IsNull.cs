using UnityEngine;
using Sirenix.OdinInspector;
using Toodles.Iterables;

namespace Toodles.Variables
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
