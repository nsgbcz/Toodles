using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Triggers
{
    public class TriggerExitAdapter : TriggerAdapterBase<ITriggerExit>
    {
        protected override bool Action(Collider coll)
        {
            return Value.OnTriggerExit(coll);
        }
    }
}
