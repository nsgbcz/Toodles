using UnityEngine;

namespace Toodles.Gamepiece.Input.Joystick
{
    public interface IHandleOutput
    {
        Vector2 Handle(ref Vector2 output);
    }
}
