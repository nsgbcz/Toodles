using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Gamepiece.Input.Joystick
{
    public class Visual
    {
        [Required]
        public RectTransform Base;
        [Required]
        public RectTransform Background;
        [Required]
        public RectTransform Handle;
    }
}
