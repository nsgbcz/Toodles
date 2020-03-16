using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Mono
{
    public class CollisionExitExecute : CollisionExecute, ICollisionExit
    {
        private void OnCollisionExit(Collision coll)
        {
            OnCollision(coll);
        }

        bool ICollisionExit.OnCollisionExit(Collision coll)
        {
            return OnCollision(coll);
        }
    }
}
