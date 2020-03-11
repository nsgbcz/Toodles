using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class FixedUpdateExecute : Execute
    {
        private void FixedUpdate()
        {
            base.Action();
        }
    }
}
