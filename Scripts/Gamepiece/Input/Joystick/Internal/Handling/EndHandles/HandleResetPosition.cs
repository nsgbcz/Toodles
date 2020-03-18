using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Gamepiece.Input.Joystick
{
    public struct HandleResetPosition : IHandleEnd
    {
        public void Handle(Visual visual, InternalSettings settings)
        {
            visual.Handle.anchoredPosition = Vector2.zero;
        }
    }
}