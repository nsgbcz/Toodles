using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Sirenix.Serialization;
using Sirenix.OdinInspector;
using System;

namespace Toodles.Gamepiece.Input.Joystick
{
    public struct Dynamic : IHandleBegin
    {
        public void Handle(Visual visual, InternalSettings settings, Vector2 position)
        {
            visual.Background.anchoredPosition = ScreenPointToAnchoredPosition();

            Vector2 ScreenPointToAnchoredPosition()
            {
                if (RectTransformUtility.ScreenPointToLocalPointInRectangle(visual.Base, position, settings.camera, out Vector2 localPoint))
                {
                    Vector2 pivotOffset = visual.Base.pivot * visual.Base.sizeDelta;
                    return localPoint - (visual.Background.anchorMax * visual.Base.sizeDelta) + pivotOffset;
                }
                return Vector2.zero;
            }
        }
    }
}