using UnityEngine;

namespace Toodles.Gamepiece.Input.Joystick
{
    public interface IHandleEnd
    {
        void Handle(Visual visual, InternalSettings settings);
    }
}
