using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Gamepiece.Input.Joystick
{
    public interface IJoystickReciever 
    {
        void Apply(Vector2 vector);
    }
}
