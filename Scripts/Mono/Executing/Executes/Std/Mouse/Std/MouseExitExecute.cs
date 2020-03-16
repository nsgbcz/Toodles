using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    public class MouseExitExecute : MouseExecute, IMouseExit
    {
        private void OnMouseExit()
        {
            OnMouse();
        }

        bool IMouseExit.OnMouseExit()
        {
            return OnMouse();
        }
    }
}