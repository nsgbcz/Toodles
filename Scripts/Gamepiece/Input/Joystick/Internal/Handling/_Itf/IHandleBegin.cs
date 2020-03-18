using UnityEngine;
using Sirenix.Serialization;
using System;

namespace Toodles.Gamepiece.Input.Joystick
{
    public interface IHandleBegin
    {
        void Handle(Visual visual, InternalSettings settings, Vector2 position);
    }
}
