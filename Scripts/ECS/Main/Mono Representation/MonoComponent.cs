﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Leopotam.Ecs;

namespace Toodles.Ecs
{
    public class MonoComponent : SerializedMonoBehaviour, IComponentEcs
    {
        [SerializeField]
        IComponentEcs[] Components = new IComponentEcs[0];

        public IComponentEcs Value { get => this; set => throw new System.NotImplementedException(); }
        public void DressEntity(EcsEntity entity)
        {
            for (int i = 0; i < Components.Length; i++)
            {
                Components[i].DressEntity(entity);
            }
        }
    }
}
