using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct UnscaledLinearVelocityData : IComponentData
{
    [HideInInspector]
    public float3 value;

    public static implicit operator UnscaledLinearVelocityData(float3 vector)
    {
        return new UnscaledLinearVelocityData() { value = vector };
    }
}
