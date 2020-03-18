using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Gamepiece.Input.Joystick
{
    using Ecs;

    public class JoystickApplySystem : IEcsRunSystem
    {
        EcsFilter<JoystickСontrolledComponent, Val<IJoystickReciever>> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                Debug.Log(i);
                var index = _filter.Get1[i].joystickIndex;
                var reciever = _filter.Get2[i].Value;

                var value = Joystick.GetData(index);
                reciever.Apply(value);
            }
        }
    }
}
