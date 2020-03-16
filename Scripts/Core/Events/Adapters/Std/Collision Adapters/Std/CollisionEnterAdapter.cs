using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Collisions
{
    public class CollisionEnterAdapter : CollisionAdapterBase<ICollisionEnter>
    {
        protected override bool Action(UnityEngine.Collision coll)
        {
            return Value.OnCollisionEnter(coll);
        }
    }
}
