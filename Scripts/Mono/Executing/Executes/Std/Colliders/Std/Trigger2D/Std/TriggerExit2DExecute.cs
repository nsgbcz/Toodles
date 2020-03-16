using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    public class TriggerExit2DExecute : Trigger2DExecute, ITriggerExit2D 
    {
        private void OnTriggerExit2D(Collider2D coll)
        {
            OnTrigger2D(coll);
        }

        bool ITriggerExit2D.OnTriggerExit2D(Collider2D coll)
        {
            return OnTrigger2D(coll);
        }
    }
}
