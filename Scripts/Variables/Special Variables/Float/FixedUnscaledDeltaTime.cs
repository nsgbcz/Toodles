using UnityEngine;

namespace Toodles.Variables
{
    public struct FixedUnscaledDeltaTime : IGet<float>
    {
        public float Value { get => Time.fixedUnscaledDeltaTime; }
    }
}
