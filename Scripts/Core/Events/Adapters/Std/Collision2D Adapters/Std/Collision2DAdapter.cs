using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Collisions2D
{
    public class Collision2DAdapter : Collision2DAdapterBase<ICollision2D>
    {
        protected override bool Action(UnityEngine.Collision2D coll)
        {
            return Value.OnCollision2D(coll);
        }
    }
}
