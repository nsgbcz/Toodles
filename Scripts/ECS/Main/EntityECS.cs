using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.ECS
{
    public class EntityECS : IInit, IVar<EntityECS>
    {
        [AssetSelector, SerializeField]
        IGet<EcsEntity> Entity;
        [SerializeField, HideLabel]
        IECSComponent[] Components = new IECSComponent[0];

        public EntityECS Value { get => this; set => throw new System.NotImplementedException(); }

        public void Init()
        {
            var entity = Entity.Value;
            DressEntity(entity);
        }

        public void DressEntity(EcsEntity entity)
        {
            for (int i = 0; i < Components.Length; i++)
            {
                Components[i].DressEntity(entity);
            }
        }
    }
}
