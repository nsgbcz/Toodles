using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Gamepiece.Input.Joystick
{
    public struct BackgroundStartPosition : IHandleEnd
    {
        public void Handle(Visual visual, InternalSettings settings)
        {
            visual.Background.anchoredPosition = settings.startPosition;
        }
    }
}