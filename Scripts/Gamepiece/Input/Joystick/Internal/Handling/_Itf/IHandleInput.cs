using UnityEngine;

namespace Toodles.Gamepiece.Input.Joystick
{
    public interface IHandleInput
    {
        void Handle(Visual visual, InternalSettings internalSettings, ref InputMeta meta);
    }
}
