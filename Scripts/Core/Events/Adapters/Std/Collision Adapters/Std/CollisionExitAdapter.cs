using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Collisions
{
    public class CollisionExitAdapter : CollisionAdapterBase<ICollisionExit>
    {
        protected override bool Action(UnityEngine.Collision coll)
        {
            return Value.OnCollisionExit(coll);
        }
    }
}
