
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct InputDirectionData : IComponentData
{
    [HideInInspector]
    public float2 value;

    public static implicit operator InputDirectionData(float2 vector)
    {
        return new InputDirectionData() { value = vector };
    }
}

