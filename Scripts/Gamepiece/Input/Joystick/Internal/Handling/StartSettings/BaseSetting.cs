using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Gamepiece.Input.Joystick
{
    public struct BaseSetting : IStartSetting
    {
        public void Set(Visual visual, ref InternalSettings settings)
        {
            var background = visual.Background;
            var handle = visual.Handle;

            Vector2 center = new Vector2(0.5f, 0.5f);

            var midAnch = Vector2.zero;
            var anch = background.anchorMin;
            midAnch.x = (anch.x + anch.y) / 2f;
            anch = background.anchorMax;
            midAnch.y = (anch.x + anch.y) / 2f;
            anch = center - anch;
            settings.startPosition = background.anchoredPosition -= anch * visual.Base.rect.size;

            background.anchorMin = center;
            background.anchorMax = center;
            background.pivot = center;

            handle.anchorMin = center;
            handle.anchorMax = center;
            handle.pivot = center;
            handle.anchoredPosition = Vector2.zero;
        }
    }
}