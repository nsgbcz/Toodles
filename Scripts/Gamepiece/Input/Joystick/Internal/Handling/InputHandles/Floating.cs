using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Gamepiece.Input.Joystick
{
    public struct Floating : IHandleInput
    {
        public void Handle(Visual visual, InternalSettings internalSettings, ref InputMeta meta)
        {
            if (meta.magnitude > internalSettings.handleRange)
            {
                Vector2 difference = meta.normalized * (meta.magnitude - internalSettings.handleRange) * internalSettings.radius;
                visual.Background.anchoredPosition += difference;
            }
        }
    }
}