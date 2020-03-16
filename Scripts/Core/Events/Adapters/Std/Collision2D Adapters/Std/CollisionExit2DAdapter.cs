using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Collisions2D
{
    public class CollisionExit2DAdapter : Collision2DAdapterBase<ICollisionExit2D>
    {
        protected override bool Action(UnityEngine.Collision2D coll)
        {
            return Value.OnCollisionExit2D(coll);
        }
    }
}
