using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    public class MouseUpAsButtonExecute : MouseExecute, IMouseUpAsButton
    {
        private void OnMouseUpAsButton()
        {
            OnMouse();
        }
        public bool OnMouseClick()
        {
            return OnMouse();
        }

    }
}