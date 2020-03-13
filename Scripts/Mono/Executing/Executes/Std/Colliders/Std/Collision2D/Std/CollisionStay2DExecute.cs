using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Toodles.Executes
{
    public class CollisionStay2DExecute : Collision2DExecute, ICollisionStay2D
    {
        private void OnCollisionStay2D(Collision2D coll)
        {
            OnCollision2D(coll);
        }

        bool ICollisionStay2D.OnCollisionStay2D(Collision2D coll)
        {
            return OnCollision2D(coll);
        }
    }
}
