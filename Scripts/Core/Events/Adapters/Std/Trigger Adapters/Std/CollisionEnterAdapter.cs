using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Triggers
{
    public class TriggerEnterAdapter : TriggerAdapterBase<ITriggerEnter>
    {
        protected override bool Action(Collider coll)
        {
            return Value.OnTriggerEnter(coll);
        }
    }
}
