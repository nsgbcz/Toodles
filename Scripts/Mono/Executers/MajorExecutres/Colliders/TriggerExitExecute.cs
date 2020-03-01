using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class TriggerExitExecute : TriggerExecute
    {
        private void OnTriggerExit(Collider coll)
        {
            ExitAction(coll);
        }
    }
}
