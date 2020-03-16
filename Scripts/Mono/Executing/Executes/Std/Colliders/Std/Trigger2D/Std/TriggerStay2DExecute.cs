using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    public class TriggerStay2DExecute : Trigger2DExecute, ITriggerStay2D
    {
        private void OnTriggerStay2D(Collider2D coll)
        {
            OnTrigger2D(coll);
        }

        bool ITriggerStay2D.OnTriggerStay2D(Collider2D coll)
        {
            return OnTrigger2D(coll);
        }
    }
}
