using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class TriggerExit2DExecute : Trigger2DExecute, ITriggerExit2D 
    {
        private void OnTriggerExit2D(Collider2D coll)
        {
            Action(coll);
        }
    }
}
