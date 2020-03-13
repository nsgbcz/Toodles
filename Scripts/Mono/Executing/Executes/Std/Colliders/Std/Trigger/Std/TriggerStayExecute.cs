using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class TriggerStayExecute : TriggerExecute, ITriggerStay
    {
        private void OnTriggerStay(Collider coll)
        {
            OnTrigger(coll);
        }

        bool ITriggerStay.OnTriggerStay(Collider coll)
        {
            return OnTrigger(coll);
        }
    }
}
