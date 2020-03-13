using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class MouseOverExecute : MouseExecute, IMouseOver
    {
        private void OnMouseOver()
        {
            OnMouse();
        }

        bool IMouseOver.OnMouseOver()
        {
            return OnMouse();
        }
    }
}