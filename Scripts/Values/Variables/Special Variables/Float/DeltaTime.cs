using UnityEngine;

namespace Toodles.Variables
{
    public struct DeltaTime : IGet<float>
    {
        public float Value { get => Time.deltaTime; }
    }
}
