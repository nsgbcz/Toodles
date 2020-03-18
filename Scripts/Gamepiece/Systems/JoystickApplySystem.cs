using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;

namespace Toodles.Gamepiece.Input.Joystick
{
    using Ecs;

    public class JoystickApplySystem : IEcsRunSystem
    {
        EcsFilter<TranslationComponent, JoystickСontrolledComponent> _filter;
        public void Run()
        {
            foreach (var i in _filter)
            {
                var translation = _filter.Get1[i];
                var index = _filter.Get2[i].joystickIndex;

                var value = Joystick.GetData(index);
                translation.Data += new Vector3(value.x, 0, value.y);
            }
        }
    }
}
