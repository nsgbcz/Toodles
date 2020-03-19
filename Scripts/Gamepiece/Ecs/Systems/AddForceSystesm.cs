using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Gamepiece
{
    using Leopotam.Ecs;
    using ECS;

    public class AddForceSystesm : IEcsRunSystem
    {
        EcsFilter<RigidbodyComponent, AddForceComponent> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                var rigidbody = _filter.Get1[i].Rigidbody;
                var forceData = _filter.Get2[i];

                rigidbody.AddForce(forceData.Force, forceData.Mode);
            }
        }
    }
}
