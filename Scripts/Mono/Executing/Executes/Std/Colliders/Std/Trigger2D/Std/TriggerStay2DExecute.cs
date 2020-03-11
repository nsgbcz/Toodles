using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class TriggerStay2DExecute : Trigger2DExecute, ITriggerStay2D
    {
        private void OnTriggerStay2D(Collider2D coll)
        {
            Action(coll);
        }
    }
}
