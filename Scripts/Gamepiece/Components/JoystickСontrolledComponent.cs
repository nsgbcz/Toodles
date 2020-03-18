using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Gamepiece.Input.Joystick
{
    using Ecs;
    public class JoystickСontrolledPreview : BaseComponent<JoystickСontrolledComponent>
    {
        public IGet<int> joystickIndex = new Value<int>();
        protected override void SetValue(JoystickСontrolledComponent component)
        {
            component.joystickIndex = joystickIndex.Value;
        }
    }

    public class JoystickСontrolledComponent : BaseComponent<JoystickСontrolledComponent>
    {
        public int joystickIndex;
        protected override void SetValue(JoystickСontrolledComponent component)
        {
            component.joystickIndex = joystickIndex;
        }
    }
}
