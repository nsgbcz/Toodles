using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Collisions2D
{
    public class CollisionStay2DAdapter : Collision2DAdapterBase<ICollisionStay2D>
    {
        protected override bool Action(UnityEngine.Collision2D coll)
        {
            return Value.OnCollisionStay2D(coll);
        }
    }
}
