using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles
{
    public struct MultiplyFloat : IGet<float>
    {
        [SerializeField, Required]
        IGet<float> First, Second;
        public float Value => First.Value * Second.Value;
    }
}
