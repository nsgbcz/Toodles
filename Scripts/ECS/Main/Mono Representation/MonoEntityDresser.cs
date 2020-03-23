using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Leopotam.Ecs;

namespace Toodles.Ecs
{
    public class MonoEntityDresser : SerializedMonoBehaviour, IInit
    {
        [AssetSelector, SerializeField]
        IGet<EcsEntity> Entity;
        [SerializeField]
        IComponentEcs[] Components = new IComponentEcs[0];

        public void Init()
        {
            DressEntity(Entity.Value);
        }

        public void DressComponent(IComponentEcs component)
        {
            component.DressEntity(Entity.Value);
        }

        void DressEntity(EcsEntity entity)
        {
            for (int i = 0; i < Components.Length; i++)
            {
                Components[i].DressEntity(entity);
            }
        }
    }
}
