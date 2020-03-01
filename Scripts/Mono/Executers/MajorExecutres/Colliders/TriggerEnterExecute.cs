using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executers
{
    public class TriggerEnterExecute : TriggerExecute
    {
        private void OnTriggerEnter(Collider coll)
        {
            EnterAction(coll);
        }
    }
}
