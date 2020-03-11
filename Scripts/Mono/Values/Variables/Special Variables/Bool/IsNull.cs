using UnityEngine;
using Sirenix.OdinInspector;
using Toodles.Iterates;

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
