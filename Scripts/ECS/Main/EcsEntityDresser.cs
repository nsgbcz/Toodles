using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Ecs
{
    public class EcsEntityDresser : IInit, IVar<EcsEntityDresser>
    {
        [AssetSelector, SerializeField]
        IGet<EcsEntity> Entity;
        [SerializeField, HideLabel]
        IComponentEcs[] Components = new IComponentEcs[0];

        public EcsEntityDresser Value { get => this; set => throw new System.NotImplementedException(); }

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
