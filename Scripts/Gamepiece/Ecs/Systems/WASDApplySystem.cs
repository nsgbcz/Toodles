using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Gamepiece.Input
{
    using Ecs;

    public class WASDApplySystem : IEcsRunSystem
    {
        EcsFilter<WASDСontrolledComponent, IWASDReciever> _filter;
        public void Run()
        {
            Vector3 value = Vector3.zero;
            if (UnityEngine.Input.GetKey(KeyCode.W)) value.z += 1;
            if (UnityEngine.Input.GetKey(KeyCode.S)) value.z -= 1;
            if (UnityEngine.Input.GetKey(KeyCode.D)) value.x += 1;
            if (UnityEngine.Input.GetKey(KeyCode.A)) value.x -= 1;
            value.Normalize();

            if (value == Vector3.zero) return;
            foreach (var i in _filter)
            {
                var reciever = _filter.Get2[i];

                reciever.Apply(value);
            }
        }
    }
}
