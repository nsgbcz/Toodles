using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.ECS
{
    public class NewEcsWorld : IVar<EcsWorld>
    {
        public EcsWorld Value
        {
            get => new EcsWorld();
            set { }
        }
    } 
}
