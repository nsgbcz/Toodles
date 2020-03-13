using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class TriggerEnterExecute : TriggerExecute, ITriggerEnter
    {
        private void OnTriggerEnter(Collider coll)
        {
            OnTrigger(coll);
        }

        bool ITriggerEnter.OnTriggerEnter(Collider coll)
        {
            return OnTrigger(coll);
        }
    }
}
