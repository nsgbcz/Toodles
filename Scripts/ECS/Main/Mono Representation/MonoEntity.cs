using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Leopotam.Ecs;

namespace Toodles.ECS
{
    public class MonoEntity : SerializedMonoBehaviour, IInit
    {
        [AssetSelector, SerializeField]
        IGet<EcsEntity> Entity;
        [SerializeField]
        IECSComponent[] Components = new IECSComponent[0];

        public void Init()
        {
            DressEntity(Entity.Value);
        }

        public void DressComponent(IECSComponent component)
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
