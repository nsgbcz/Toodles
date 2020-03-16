using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Collisions2D
{
    public class CollisionEnter2DAdapter : Collision2DAdapterBase<ICollisionEnter2D>
    {
        protected override bool Action(UnityEngine.Collision2D coll)
        {
            return Value.OnCollisionEnter2D(coll);
        }
    }
}
