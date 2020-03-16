using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using Sirenix.OdinInspector;

namespace Toodles.Ecs
{
    public class NewEcsEntity : IVar<EcsEntity>
    {
        [SerializeField, Required]
        IGet<EcsWorld> World;

        EcsWorld _world;
        public EcsEntity Value
        {
            set
            {

            }
            get
            {
                Init();
                return _world.NewEntity();
            }
        }

        void Init()
        {
            if (_world == null)
                _world = World.Value;
        }
    } 
}
