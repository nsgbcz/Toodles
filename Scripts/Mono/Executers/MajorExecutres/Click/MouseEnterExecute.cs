using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class MouseEnterExecute : MouseExecute
    {
        private void OnMouseEnter()
        {
            base.Action();
        }
    }
}