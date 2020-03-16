using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    public class MouseDownExecute : MouseExecute, IMouseDown
    {
        private void OnMouseDown()
        {
            OnMouse();
        }

        bool IMouseDown.OnMouseDown()
        {
            return OnMouse();
        }
    }
}