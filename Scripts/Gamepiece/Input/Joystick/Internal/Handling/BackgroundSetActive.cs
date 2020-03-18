using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Gamepiece.Input.Joystick
{
    public class BackgroundSetActive : IStartSetting, IHandleBegin, IHandleEnd
    {
        [SerializeField, HideLabel]
        bool Value = true;

        public void Handle(Visual visual, InternalSettings settings)
        {
            visual.Background.gameObject.SetActive(Value);
        }

        public void Handle(Visual visual, InternalSettings settings, Vector2 position)
        {
            visual.Background.gameObject.SetActive(Value);
        }

        public void Set(Visual visual, ref InternalSettings settings)
        {
            visual.Background.gameObject.SetActive(Value);
        }
    }
}