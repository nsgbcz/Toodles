using UnityEngine;

namespace Toodles
{
    public struct FixedDeltaTime : IGet<float>
    {
        public float Value { get => Time.fixedDeltaTime; }
    }
}
