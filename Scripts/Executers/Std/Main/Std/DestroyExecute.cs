using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class DestroyExecute : MainExecute
    {
        private void OnDestroy()
        {
            base.Action();
        }
    }
}
