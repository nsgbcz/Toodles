using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class TriggerExitExecute : TriggerExecute, ITriggerExit
    {
        private void OnTriggerExit(Collider coll)
        {
            Action(coll);
        }
    }
}
