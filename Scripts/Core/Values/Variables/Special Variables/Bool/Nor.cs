using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles
{
    public struct Nor : IGet<bool>, IIteratable
    {
        [SerializeField, Required, HideLabel]
        IGet<bool> value;
        public bool Value => !value.Value;

        public bool Iterate()
        {
            return Value;
        }
    }
}
