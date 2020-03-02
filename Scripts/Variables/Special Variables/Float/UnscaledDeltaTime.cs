using UnityEngine;

namespace Toodles.Variables
{
    public struct UnscaledDeltaTime : IGet<float>
    {
        public float Value { get => Time.unscaledDeltaTime; }
    }
}
