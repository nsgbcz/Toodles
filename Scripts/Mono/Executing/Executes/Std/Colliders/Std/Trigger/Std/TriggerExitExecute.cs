﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    public class TriggerExitExecute : TriggerExecute, ITriggerExit
    {
        private void OnTriggerExit(Collider coll)
        {
            OnTrigger(coll);
        }

        bool ITriggerExit.OnTriggerExit(Collider coll)
        {
            return OnTrigger(coll);
        }
    }
}
