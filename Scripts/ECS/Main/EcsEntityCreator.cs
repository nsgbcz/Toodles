using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Ecs.Creators
{
    public class EcsEntityCreator : IAction, IVar<EcsEntityCreator>
    {
        [AssetSelector, SerializeField]
        IGet<EcsEntity> Entity;
        [SerializeField, HideLabel]
        IEcsComponent[] Components = new IEcsComponent[0];

        public EcsEntityCreator Value { get => this; set => throw new System.NotImplementedException(); }

        public void Action()
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
