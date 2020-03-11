using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class DisableExecute : Execute
    {
        private void OnDisable()
        {
            base.Action();
        }
    }
}
