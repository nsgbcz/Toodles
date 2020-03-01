using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class DisableExecute : MainExecute
    {
        private void OnDisable()
        {
            base.Action();
        }
    }
}
