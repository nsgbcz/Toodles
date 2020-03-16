using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Toodles.Core.Adapters.Collisions
{
    public class CollisionStayAdapter : CollisionAdapterBase<ICollisionStay>
    {
        protected override bool Action(UnityEngine.Collision coll)
        {
            return Value.OnCollisionStay(coll);
        }
    }
}
