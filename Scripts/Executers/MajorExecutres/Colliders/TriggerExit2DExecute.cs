using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class TriggerExit2DExecute : Trigger2DExecute
    {
        private void OnTriggerExit2D(Collider2D coll)
        {
            ExitAction(coll);
        }
    }
}
