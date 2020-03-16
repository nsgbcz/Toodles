using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    public class MouseDragExecute : MouseExecute, IMouseDrag
    {
        private void OnMouseDrag()
        {
            OnMouse();
        }

        bool IMouseDrag.OnMouseDrag()
        {
            return OnMouse();
        }
    }
}