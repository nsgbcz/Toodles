using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class MouseUpAsButtonExecute : MouseExecute
    {
        private void OnMouseUpAsButton()
        {
            base.Action();
        }
    }
}