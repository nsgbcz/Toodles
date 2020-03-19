using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.ECS
{
    public class ComponentECS : IECSComponent, IVar<IECSComponent>
    {
        [SerializeField]
        IECSComponent[] Components = new IECSComponent[0];

        public IECSComponent Value { get => this; set => throw new System.NotImplementedException(); }
        public void DressEntity(EcsEntity entity)
        {
            for (int i = 0; i < Components.Length; i++)
            {
                Components[i].DressEntity(entity);
            }
        }
    }
}
