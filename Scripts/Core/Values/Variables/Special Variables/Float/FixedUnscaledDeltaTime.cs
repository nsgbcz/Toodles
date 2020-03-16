using UnityEngine;

namespace Toodles
{
    public struct FixedUnscaledDeltaTime : IGet<float>
    {
        public float Value { get => Time.fixedUnscaledDeltaTime; }
    }
}
