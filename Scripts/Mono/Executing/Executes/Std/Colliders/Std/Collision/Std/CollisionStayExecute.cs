using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    public class CollisionStayExecute : CollisionExecute, ICollisionStay
    {
        private void OnCollisionStay(Collision coll)
        {
            OnCollision(coll);
        }

        bool ICollisionStay.OnCollisionStay(Collision coll)
        {
            return OnCollision(coll);
        }
    }
}
