using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class MouseUpExecute : MouseExecute
    {
        private void OnMouseUp()
        {
            base.Action();
        }
    }
}