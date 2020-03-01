using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class LateUpdateExecute : MainExecute
    {
        private void LateUpdate()
        {
            base.Action();
        }
    }
}
