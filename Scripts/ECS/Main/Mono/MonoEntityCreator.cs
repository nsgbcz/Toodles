using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Leopotam.Ecs;

namespace Toodles.Ecs.Creators
{
    public class MonoEntityCreator : SerializedMonoBehaviour, IAction
    {
        [AssetSelector, SerializeField]
        IGet<EcsEntity> Entity;
        [SerializeField]
        IEcsComponent[] Components = new IEcsComponent[0];

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
