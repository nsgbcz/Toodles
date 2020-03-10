using Unity.Physics;
using Unity.Physics.Extensions;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Jobs;
using Unity.Transforms;
using Unity.Collections;
using Unity.Burst;

[BurstCompile]

public class VelocityApplySystem : JobComponentSystem
{
    [BurstCompile]
    public struct VelocityApplyJob : IJobForEach<PhysicsVelocity, UnscaledLinearVelocityData>
    {
        public float DeltaTime;

        public void Execute(ref PhysicsVelocity    bodyVelocity,
                  [ReadOnly]ref UnscaledLinearVelocityData velocityData)
        {
            bodyVelocity.Linear = velocityData.value * DeltaTime;
        }
    }
    protected override JobHandle OnUpdate(JobHandle inputDeps)
    {
        var job = new VelocityApplyJob { DeltaTime = UnityEngine.Time.fixedDeltaTime };
        return job.Schedule(this, inputDeps);
    }
}
