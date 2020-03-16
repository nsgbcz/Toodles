using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Collisions
{
    public class CollisionAdapter : CollisionAdapterBase<ICollision>
    {
        protected override bool Action(UnityEngine.Collision coll)
        {
            return Value.OnCollision(coll);
        }
    }
}
