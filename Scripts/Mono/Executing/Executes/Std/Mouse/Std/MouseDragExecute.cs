using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class MouseDragExecute : MouseExecute, IMouseDrag
    {
        private void OnMouseDrag()
        {
            Action();
        }
    }
}