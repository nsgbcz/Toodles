using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class MouseUpAsButtonExecute : MouseExecute, IMouseUpAsButton
    {
        private void OnMouseUpAsButton()
        {
            Action();
        }
    }
}