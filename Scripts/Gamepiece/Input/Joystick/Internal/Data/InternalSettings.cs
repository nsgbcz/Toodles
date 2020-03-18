using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Gamepiece.Input.Joystick
{
    [HideInInspector]
    public struct InternalSettings
    {
        public int index;
        public float handleRange;
        public Vector2 startPosition;
        public Vector2 radius;
        public Canvas canvas;
        public UnityEngine.Camera camera;
    }
}
