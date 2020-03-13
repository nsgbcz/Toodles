using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class MouseUpExecute : MouseExecute, IMouseUp
    {
        private void OnMouseUp()
        {
            OnMouse();
        }

        bool IMouseUp.OnMouseUp()
        {
            return OnMouse();
        }
    }
}