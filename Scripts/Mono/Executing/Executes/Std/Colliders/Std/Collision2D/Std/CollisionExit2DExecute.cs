using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class CollisionExit2DExecute : Collision2DExecute, ICollisionExit2D
    {
        private void OnCollisionExit2D(Collision2D coll)
        {
            OnCollision2D(coll);
        }

        bool ICollisionExit2D.OnCollisionExit2D(Collision2D coll)
        {
            return OnCollision2D(coll);
        }
    }
}
