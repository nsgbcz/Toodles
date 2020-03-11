using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class LateUpdateExecute : Execute
    {
        private void LateUpdate()
        {
            base.Action();
        }
    }
}
