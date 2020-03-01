using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class MouseDownExecute : MouseExecute
    {
        private void OnMouseDown()
        {
            base.Action();
        }
    }
}