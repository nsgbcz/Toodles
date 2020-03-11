using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Executes 
{
    public class TriggerExecute : ConcretCollExecute<Collider, ITrigger>, ITrigger
    {
        public bool Action(Collider coll)
        {
            if (filter.Filter(coll))
            {
                if (execute != null && execute.Action(coll))
                {
                    Destroy(this);
                    return true;
                }
            }
            return false;
        }
    }
}