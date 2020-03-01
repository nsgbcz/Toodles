using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class TriggerStay2DExecute : Trigger2DExecute
    {
        private void OnTriggerStay2D(Collider2D coll)
        {
            StayAction(coll);
        }
    }
}
