using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;

[GenerateAuthoringComponent]
public struct UnscaledLinearVelocityData : IComponentData
{
    [HideInInspector]
    public float3 value;
}
