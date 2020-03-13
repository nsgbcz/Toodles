using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
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