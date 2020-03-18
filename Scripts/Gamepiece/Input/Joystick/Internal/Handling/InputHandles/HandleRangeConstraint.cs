using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Gamepiece.Input.Joystick
{
    public struct HandleRangeConstraint : IHandleInput
    {
        public void Handle(Visual visual, InternalSettings internalSettings, ref InputMeta meta)
        {
            if (meta.magnitude > internalSettings.handleRange)
                meta.vector = meta.normalized * internalSettings.handleRange;
        }
    }
}