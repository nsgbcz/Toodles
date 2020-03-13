using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes 
{
    public class TriggerExecute : ConcretCollExecute<Collider, ITrigger>, ITrigger
    {
        public bool OnTrigger(Collider coll)
        {
            if (filter.Filter(coll))
            {
                if (execute != null && execute.OnTrigger(coll))
                {
                    Destroy(this);
                    return true;
                }
            }
            return false;
        }
    }
}