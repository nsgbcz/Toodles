using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Gamepiece.Input.Joystick
{
    public ref struct InputMeta
    {
        public Vector2 vector;
        public float magnitude;
        public Vector2 normalized;

        public InputMeta(Vector2 vector)
        {
            this.vector = vector;
            magnitude = vector.magnitude;
            normalized = vector.normalized;
        }
    }
}
