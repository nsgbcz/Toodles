using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class MouseOverExecute : MouseExecute
    {
        private void OnMouseOver()
        {
            base.Action();
        }
    }
}