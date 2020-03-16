using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
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