using UnityEngine;

namespace Toodles
{
    public struct DeltaTime : IGet<float>
    {
        public float Value { get => Time.deltaTime; }
    }
}
