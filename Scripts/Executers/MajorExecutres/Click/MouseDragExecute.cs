using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class MouseDragExecute : MouseExecute
    {
        private void OnMouseDrag()
        {
            base.Action();
        }
    }
}