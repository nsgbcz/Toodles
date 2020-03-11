using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class TriggerEnterExecute : TriggerExecute, ITriggerEnter
    {
        private void OnTriggerEnter(Collider coll)
        {
            Action(coll);
        }
    }
}
