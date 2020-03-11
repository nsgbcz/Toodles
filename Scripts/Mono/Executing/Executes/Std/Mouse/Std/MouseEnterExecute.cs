using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class MouseEnterExecute : MouseExecute, IMouseEnter
    {
        private void OnMouseEnter()
        {
            Action();
        }
    }
}