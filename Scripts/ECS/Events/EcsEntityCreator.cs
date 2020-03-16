using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Ecs
{
    public class EcsEntityCreator : IAction
    {
        public IGet<EcsEntity> Entity;
        public IEcsComponent[] Components;

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
