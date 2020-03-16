using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Triggers2D
{
    public class TriggerStay2DAdapter : Trigger2DAdapterBase<ITriggerStay2D>
    {
        protected override bool Action(Collider2D coll)
        {
            return Value.OnTriggerStay2D(coll);
        }
    }
}
