using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Ecs
{
    public class NewEcsWorld : IVar<EcsWorld>
    {
        public EcsWorld Value
        {
            get => new EcsWorld();
            set
            {

            }
        }
    } 
}
