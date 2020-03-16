using UnityEngine;

namespace Toodles
{
    public struct UnscaledDeltaTime : IGet<float>
    {
        public float Value { get => Time.unscaledDeltaTime; }
    }
}
