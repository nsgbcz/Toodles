using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Triggers2D
{
    public class TriggerExit2DAdapter : Trigger2DAdapterBase<ITriggerExit2D>
    {
        protected override bool Action(Collider2D coll)
        {
            return Value.OnTriggerExit2D(coll);
        }
    }
}
