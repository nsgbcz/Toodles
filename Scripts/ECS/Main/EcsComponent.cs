﻿using Leopotam.Ecs;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Ecs.Creators
{
    public class EcsComponent : IEcsComponent, IVar<IEcsComponent>
    {
        [SerializeField]
        IEcsComponent[] Components = new IEcsComponent[0];

        public IEcsComponent Value { get => this; set => throw new System.NotImplementedException(); }
        public void DressEntity(EcsEntity entity)
        {
            for (int i = 0; i < Components.Length; i++)
            {
                Components[i].DressEntity(entity);
            }
        }
    }
}
