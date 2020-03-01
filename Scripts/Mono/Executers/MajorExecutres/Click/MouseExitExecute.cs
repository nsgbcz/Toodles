using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class MouseExitExecute : MouseExecute
    {
        private void OnMouseExit()
        {
            base.Action();
        }
    }
}