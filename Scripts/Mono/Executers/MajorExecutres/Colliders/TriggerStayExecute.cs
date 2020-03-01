using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class TriggerStayExecute : TriggerExecute
    {
        private void OnTriggerStay(Collider coll)
        {
            StayAction(coll);
        }
    }
}
