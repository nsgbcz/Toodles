using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Triggers
{
    public class TriggerStayAdapter : TriggerAdapterBase<ITriggerStay>
    {
        protected override bool Action(Collider coll)
        {
            return Value.OnTriggerStay(coll);
        }
    }
}
