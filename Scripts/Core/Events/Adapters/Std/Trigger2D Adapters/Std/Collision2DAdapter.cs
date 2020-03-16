using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Triggers2D
{
    public class Trigger2DAdapter : Trigger2DAdapterBase<ITrigger2D>
    {
        protected override bool Action(Collider2D coll)
        {
            return Value.OnTrigger2D(coll);
        }
    }
}
