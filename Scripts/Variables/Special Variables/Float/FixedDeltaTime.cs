using UnityEngine;

namespace Toodles.Variables
{
    public struct FixedDeltaTime : IGet<float>
    {
        public float Value { get => Time.fixedDeltaTime; }
    }
}
